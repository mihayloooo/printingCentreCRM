using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList;
using PrintingCentre.Management.Application.Features.Flows.Commands.CreateFlow;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList;

namespace PrintingCentre.Management.WebApp.Components.Pages.Flows
{
    public partial class FlowAdd
    {
        [SupplyParameterFromForm]
        public CreateFlowCommand Flow { get; set; } = default!;

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<CompanyListVm> Companies { get; set; } = new();
        public List<PrintTemplateListVm> PrintTemplates { get; set; } = new();
        public List<EnvelopeListVm> Envelopes { get; set; } = new();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool IsSaved = false;

        protected override async Task OnInitializedAsync()
        {
            Flow ??= new();
            if (Flow.FlowSequences.Count == 0)
                Flow.FlowSequences.Add(NewSequence());

            Companies = await Mediator.Send(new GetCompaniesListQuery());
            PrintTemplates = await Mediator.Send(new GetPrintTemplatesListQuery());
            Envelopes = await Mediator.Send(new GetEnvelopesListQuery());
        }

        private static CreateFlowSequenceData NewSequence()
        {
            var seq = new CreateFlowSequenceData();
            seq.Templates.Add(new CreateFlowSequenceTemplateData());
            seq.Envelopes.Add(new CreateFlowSequenceEnvelopeData());
            return seq;
        }

        protected void AddSequence()
        {
            Flow.FlowSequences.Add(NewSequence());
        }

        protected void RemoveSequence(int index)
        {
            Flow.FlowSequences.RemoveAt(index);
        }

        protected void AddTemplate(int seqIndex)
        {
            Flow.FlowSequences[seqIndex].Templates.Add(new CreateFlowSequenceTemplateData());
        }

        protected void RemoveTemplate(int seqIndex, int tmplIndex)
        {
            Flow.FlowSequences[seqIndex].Templates.RemoveAt(tmplIndex);
        }

        protected void AddEnvelope(int seqIndex)
        {
            Flow.FlowSequences[seqIndex].Envelopes.Add(new CreateFlowSequenceEnvelopeData());
        }

        protected void RemoveEnvelope(int seqIndex, int envIndex)
        {
            Flow.FlowSequences[seqIndex].Envelopes.RemoveAt(envIndex);
        }

        protected async Task HandleValidSubmit()
        {
            await Mediator.Send(Flow);
            StatusClass = "alert-success";
            Message = "Flow added successfully.";
            IsSaved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/flowoverview");
        }
    }
}
