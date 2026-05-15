using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList;

namespace PrintingCentre.Management.WebApp.Components.DetailQuickView
{
    public partial class FlowDetailsQuickViewPopup
    {
        [Parameter]
        public FlowListVm? Flow { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        private async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
