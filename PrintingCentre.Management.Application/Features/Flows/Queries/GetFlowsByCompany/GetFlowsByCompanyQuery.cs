using MediatR;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsByCompany
{
    public class GetFlowsByCompanyQuery : IRequest<List<FlowListVm>>
    {
        public Guid CompanyId { get; set; }
    }
}
