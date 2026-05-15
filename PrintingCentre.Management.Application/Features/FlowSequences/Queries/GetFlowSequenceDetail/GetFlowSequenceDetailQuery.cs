using MediatR;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequenceDetail
{
    public class GetFlowSequenceDetailQuery : IRequest<FlowSequenceDetailVm>
    {
        public Guid Id { get; set; }
    }
}
