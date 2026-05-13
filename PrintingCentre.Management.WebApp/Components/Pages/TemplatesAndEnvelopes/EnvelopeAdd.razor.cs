using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.CreateEnvelope;

namespace PrintingCentre.Management.WebApp.Components.Pages.TemplatesAndEnvelopes
{
    public partial class EnvelopeAdd
    {
        [SupplyParameterFromForm]
        public CreateEnvelopeCommand Envelope { get; set; } = new();

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Envelope ??= new();
        }

        protected async Task HandleValidSubmit()
        {
            await Mediator.Send(Envelope);
            StatusClass = "alert-success";
            Message = "Envelope added successfully.";
            IsSaved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/templates&envelopes?tab=envelopes");
        }
    }
}

