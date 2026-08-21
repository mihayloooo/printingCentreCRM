using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.WorkOrders.Queries.GetWorkOrdersList;

namespace PrintingCentre.Management.WebApp.Components.DetailQuickView
{
    public partial class WorkOrderDetailsQuickViewPopup
    {
        [Parameter]
        public WorkOrderListVm? WorkOrder { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        private async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
