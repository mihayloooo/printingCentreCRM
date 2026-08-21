using Microsoft.EntityFrameworkCore;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Persistence.Repositories
{
    public class WorkOrderRepository : BaseRepository<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(PrintingCentreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<WorkOrder>> GetAllWithSequencesAsync()
        {
            return await _dbContext.WorkOrders
                .Include(w => w.WorkOrderSequences)
                    .ThenInclude(ws => ws.WorkOrderSequenceTemplates)
                        .ThenInclude(wst => wst.PrintTemplate)
                .Include(w => w.WorkOrderSequences)
                    .ThenInclude(ws => ws.WorkOrderSequenceEnvelopes)
                        .ThenInclude(wse => wse.Envelope)
                .ToListAsync();
        }

        public async Task<WorkOrder?> GetByIdWithSequencesAsync(Guid id)
        {
            return await _dbContext.WorkOrders
                .Include(w => w.WorkOrderSequences)
                    .ThenInclude(ws => ws.WorkOrderSequenceTemplates)
                        .ThenInclude(wst => wst.PrintTemplate)
                .Include(w => w.WorkOrderSequences)
                    .ThenInclude(ws => ws.WorkOrderSequenceEnvelopes)
                        .ThenInclude(wse => wse.Envelope)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task ReplaceSequencesAsync(WorkOrder workOrder, List<WorkOrderSequence> newSequences)
        {
            _dbContext.WorkOrderSequences.RemoveRange(workOrder.WorkOrderSequences);
            _dbContext.WorkOrderSequences.AddRange(newSequences);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<WorkOrder>> GetByCompanyIdAsync(Guid companyId)
        {
            return await _dbContext.WorkOrders
                .Where(w => w.Flow.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<bool> IsCodeUnique(string code)
        {
            var matches = _dbContext.WorkOrders.Any(w => w.Code.Equals(code));
            return Task.FromResult(matches);
        }

        public Task<bool> IsCodeUnique(string code, Guid excludeId)
        {
            var matches = _dbContext.WorkOrders.Any(w => w.Code.Equals(code) && w.Id != excludeId);
            return Task.FromResult(matches);
        }
    }
}
