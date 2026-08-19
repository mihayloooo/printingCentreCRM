using Microsoft.EntityFrameworkCore;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class FlowRepository : BaseRepository<Flow>, IFlowRepository
    {
        public FlowRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Flow>> GetAllWithSequencesAsync()
        {
            return await _dbContext.Flows
                .Include(f => f.FlowSequences)
                    .ThenInclude(fs => fs.FlowSequencePrintTemplates)
                        .ThenInclude(fspt => fspt.PrintTemplate)
                .Include(f => f.FlowSequences)
                    .ThenInclude(fs => fs.FlowSequenceEnvelopes)
                        .ThenInclude(fse => fse.Envelope)
                .ToListAsync();
        }

        public async Task<Flow?> GetByIdWithSequencesAsync(Guid id)
        {
            return await _dbContext.Flows
                .Include(f => f.FlowSequences)
                    .ThenInclude(fs => fs.FlowSequencePrintTemplates)
                        .ThenInclude(fspt => fspt.PrintTemplate)
                .Include(f => f.FlowSequences)
                    .ThenInclude(fs => fs.FlowSequenceEnvelopes)
                        .ThenInclude(fse => fse.Envelope)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task ReplaceSequencesAsync(Flow flow, List<FlowSequence> newSequences)
        {
            _dbContext.FlowSequences.RemoveRange(flow.FlowSequences);
            _dbContext.FlowSequences.AddRange(newSequences);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Flow>> GetByCompanyIdAsync(Guid companyId)
        {
            return await _dbContext.Flows
                .Where(f => f.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<bool> IsFlowNameUnique(Guid companyId, string name)
        {
            var matches = _dbContext.Flows.Any(f => f.CompanyId == companyId && f.Name.Equals(name));
            return Task.FromResult(matches);
        }

        public Task<bool> IsFlowNameUnique(Guid companyId, string name, Guid excludeId)
        {
            var matches = _dbContext.Flows.Any(f => f.CompanyId == companyId && f.Name.Equals(name) && f.Id != excludeId);
            return Task.FromResult(matches);
        }

    }
}
