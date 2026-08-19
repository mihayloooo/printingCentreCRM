using Microsoft.EntityFrameworkCore;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class FlowSequenceRepository : BaseRepository<FlowSequence>, IFlowSequenceRepository
    {
        public FlowSequenceRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<FlowSequence>> GetByFlowIdAsync(Guid flowId)
        {
            return await _dbContext.FlowSequences
                .Where(fs => fs.FlowId == flowId)
                .ToListAsync();
        }

        public Task<bool> IsFlowSequenceNameUnique(Guid flowId, string name)
        {
            var matches = _dbContext.FlowSequences.Any(fs => fs.FlowId == flowId && fs.Name.Equals(name));
            return Task.FromResult(matches);
        }

        public Task<bool> IsFlowSequenceNameUnique(Guid flowId, string name, Guid excludeId)
        {
            var matches = _dbContext.FlowSequences.Any(fs => fs.FlowId == flowId && fs.Name.Equals(name) && fs.Id != excludeId);
            return Task.FromResult(matches);
        }
    }
}
