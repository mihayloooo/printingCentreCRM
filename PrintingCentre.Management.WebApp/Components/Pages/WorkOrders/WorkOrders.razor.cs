using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.WorkOrders.Queries.GetWorkOrdersList;

namespace PrintingCentre.Management.WebApp.Components.Pages.WorkOrders
{
    public partial class WorkOrders
    {
        public List<WorkOrderListVm> WorkOrdersList { get; set; } = default!;
        private WorkOrderListVm? _selectedWorkOrder;

        [Inject]
        public IMediator Mediator { get; set; }

        protected async override Task OnInitializedAsync()
        {
            WorkOrdersList = await Mediator.Send(new GetWorkOrdersListQuery());
        }

        public void ShowQuickViewPopup(WorkOrderListVm workOrder)
        {
            _selectedWorkOrder = workOrder;
        }

        private void ClosePopup()
        {
            _selectedWorkOrder = null;
        }
    }
}
