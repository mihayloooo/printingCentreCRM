using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopeDetail;

namespace PrintingCentre.Management.WebApp.Components.Pages
{
    public partial class EnvelopeEdit
    {
        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid EnvelopeId { get; set; }
        public EnvelopeDetailVm EnvelopeDetail { get; set; } = new();

        [SupplyParameterFromForm]
        public UpdateEnvelopeCommand EnvelopeToUpdate { get; set; } = new();

        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            EnvelopeDetail = await Mediator.Send(new GetEnvelopeDetailQuery { Id = EnvelopeId });
            EnvelopeToUpdate = Mapper.Map<UpdateEnvelopeCommand>(EnvelopeDetail);
        }

        protected async Task HandleValidSubmit()
        {
            EnvelopeToUpdate.Id = EnvelopeId;
            await Mediator.Send(EnvelopeToUpdate);
            StatusClass = "alert-success";
            Message = "Envelope updated successfully.";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/templates?tab=envelopes");
        }
    }
}
