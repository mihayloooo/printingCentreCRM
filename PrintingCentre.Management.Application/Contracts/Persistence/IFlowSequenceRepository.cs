using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Contracts.Persistence
{
    public interface IFlowSequenceRepository : IAsyncRepository<FlowSequence>
    {
        Task<IReadOnlyList<FlowSequence>> GetByFlowIdAsync(Guid flowId);
        Task<bool> IsFlowSequenceNameUnique(Guid flowId, string name);
        Task<bool> IsFlowSequenceNameUnique(Guid flowId, string name, Guid excludeId);
    }
}
