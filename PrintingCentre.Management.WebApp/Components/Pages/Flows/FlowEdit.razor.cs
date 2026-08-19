using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList;
using PrintingCentre.Management.Application.Features.Flows.Commands.UpdateFlow;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowDetail;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList;

namespace PrintingCentre.Management.WebApp.Components.Pages.Flows
{
    public partial class FlowEdit
    {
        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid FlowId { get; set; }

        public FlowDetailVm FlowDetail { get; set; } = new();

        [SupplyParameterFromForm]
        public UpdateFlowCommand FlowToUpdate { get; set; } = new();

        public List<PrintTemplateListVm> PrintTemplates { get; set; } = new();
        public List<EnvelopeListVm> Envelopes { get; set; } = new();

        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            FlowDetail = await Mediator.Send(new GetFlowDetailQuery { Id = FlowId });
            FlowToUpdate = Mapper.Map<UpdateFlowCommand>(FlowDetail);
            if (FlowToUpdate.FlowSequences.Count == 0)
                FlowToUpdate.FlowSequences.Add(NewSequence());

            PrintTemplates = await Mediator.Send(new GetPrintTemplatesListQuery());
            Envelopes = await Mediator.Send(new GetEnvelopesListQuery());
        }

        private static UpdateFlowSequenceData NewSequence()
        {
            var seq = new UpdateFlowSequenceData();
            seq.Templates.Add(new UpdateFlowSequenceTemplateData());
            seq.Envelopes.Add(new UpdateFlowSequenceEnvelopeData());
            return seq;
        }

        protected void AddSequence()
        {
            FlowToUpdate.FlowSequences.Add(NewSequence());
        }

        protected void RemoveSequence(int index)
        {
            FlowToUpdate.FlowSequences.RemoveAt(index);
        }

        protected void AddTemplate(int seqIndex)
        {
            FlowToUpdate.FlowSequences[seqIndex].Templates.Add(new UpdateFlowSequenceTemplateData());
        }

        protected void RemoveTemplate(int seqIndex, int tmplIndex)
        {
            FlowToUpdate.FlowSequences[seqIndex].Templates.RemoveAt(tmplIndex);
        }

        protected void AddEnvelope(int seqIndex)
        {
            FlowToUpdate.FlowSequences[seqIndex].Envelopes.Add(new UpdateFlowSequenceEnvelopeData());
        }

        protected void RemoveEnvelope(int seqIndex, int envIndex)
        {
            FlowToUpdate.FlowSequences[seqIndex].Envelopes.RemoveAt(envIndex);
        }

        protected async Task HandleValidSubmit()
        {
            FlowToUpdate.Id = FlowId;
            FlowToUpdate.CompanyId = FlowDetail.CompanyId;
            await Mediator.Send(FlowToUpdate);
            StatusClass = "alert-success";
            Message = "Flow updated successfully.";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/flowoverview");
        }
    }
}
