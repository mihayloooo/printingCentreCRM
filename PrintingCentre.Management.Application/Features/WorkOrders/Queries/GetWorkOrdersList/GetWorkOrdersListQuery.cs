using MediatR;

namespace PrintingCentre.Management.Application.Features.WorkOrders.Queries.GetWorkOrdersList
{
    public class GetWorkOrdersListQuery : IRequest<List<WorkOrderListVm>>
    {
    }
}
