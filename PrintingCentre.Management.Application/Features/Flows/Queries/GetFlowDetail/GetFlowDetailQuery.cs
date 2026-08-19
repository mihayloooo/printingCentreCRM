using MediatR;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowDetail
{
    public class GetFlowDetailQuery : IRequest<FlowDetailVm>
    {
        public Guid Id { get; set; }
    }
}
