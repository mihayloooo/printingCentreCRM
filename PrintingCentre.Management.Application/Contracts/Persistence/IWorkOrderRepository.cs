using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Contracts.Persistence
{
    public interface IWorkOrderRepository : IAsyncRepository<WorkOrder>
    {
        Task<IReadOnlyList<WorkOrder>> GetAllWithSequencesAsync();
        Task<WorkOrder?> GetByIdWithSequencesAsync(Guid id);
        Task ReplaceSequencesAsync(WorkOrder workOrder, List<WorkOrderSequence> newSequences);
        Task<IReadOnlyList<WorkOrder>> GetByCompanyIdAsync(Guid companyId);
        Task<bool> IsCodeUnique(string code);
        Task<bool> IsCodeUnique(string code, Guid excludeId);
    }
}
