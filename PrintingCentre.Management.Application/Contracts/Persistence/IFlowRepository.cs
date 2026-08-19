using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Contracts.Persistence
{
    public interface IFlowRepository : IAsyncRepository<Flow>
    {
        Task<IReadOnlyList<Flow>> GetAllWithSequencesAsync();
        Task<Flow?> GetByIdWithSequencesAsync(Guid id);
        Task ReplaceSequencesAsync(Flow flow, List<FlowSequence> newSequences);
        Task<IReadOnlyList<Flow>> GetByCompanyIdAsync(Guid companyId);
        Task<bool> IsFlowNameUnique(Guid companyId, string name);
        Task<bool> IsFlowNameUnique(Guid companyId, string name, Guid excludeId);
    }
}
