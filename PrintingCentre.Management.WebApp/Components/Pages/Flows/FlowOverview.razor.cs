using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList;

namespace PrintingCentre.Management.WebApp.Components.Pages.Flows
{
    public partial class FlowOverview
    {
        public List<FlowListVm> Flows { get; set; } = default!;
        private FlowListVm? _selectedFlow;

        [Inject]
        public IMediator Mediator { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Flows = await Mediator.Send(new GetFlowsListQuery());
        }

        public void ShowQuickViewPopup(FlowListVm flow)
        {
            _selectedFlow = flow;
        }

        private void ClosePopup()
        {
            _selectedFlow = null;
        }
    }
}
