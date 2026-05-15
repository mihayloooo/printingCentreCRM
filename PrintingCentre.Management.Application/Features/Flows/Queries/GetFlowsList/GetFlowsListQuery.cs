using MediatR;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList
{
    public class GetFlowsListQuery : IRequest<List<FlowListVm>>
    {
    }
}
