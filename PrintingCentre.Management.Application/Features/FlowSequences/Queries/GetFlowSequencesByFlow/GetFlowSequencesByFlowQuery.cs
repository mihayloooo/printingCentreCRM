using MediatR;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequencesByFlow
{
    public class GetFlowSequencesByFlowQuery : IRequest<List<FlowSequenceListVm>>
    {
        public Guid FlowId { get; set; }
    }
}
