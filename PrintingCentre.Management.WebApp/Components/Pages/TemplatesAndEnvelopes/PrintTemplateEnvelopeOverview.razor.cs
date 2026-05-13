using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList;

namespace PrintingCentre.Management.WebApp.Components.Pages.TemplatesAndEnvelopes
{
    public partial class PrintTemplateEnvelopeOverview
    {
        [Inject]
        public IMediator Mediator { get; set; }

        public List<PrintTemplateListVm>? PrintTemplates { get; set; }
        public List<EnvelopeListVm>? Envelopes { get; set; }

        [SupplyParameterFromQuery(Name = "tab")]
        public string? Tab { get; set; }

        private PrintTemplateListVm? _selectedPrintTemplate;
        private EnvelopeListVm? _selectedEnvelope;
        private string _activeTab = "printTemplates";

        protected void SetActiveTab(string tab) => _activeTab = tab;

        public void ShowPrintTemplatePopup(PrintTemplateListVm template) => _selectedPrintTemplate = template;

        public void ShowEnvelopePopup(EnvelopeListVm envelope) => _selectedEnvelope = envelope;

        private void ClosePopup()
        {
            _selectedPrintTemplate = null;
            _selectedEnvelope = null;
        }

        protected override async Task OnInitializedAsync()
        {
            _activeTab = Tab ?? "printTemplates";
            PrintTemplates = await Mediator.Send(new GetPrintTemplatesListQuery());
            Envelopes = await Mediator.Send(new GetEnvelopesListQuery());
        }
    }
}

