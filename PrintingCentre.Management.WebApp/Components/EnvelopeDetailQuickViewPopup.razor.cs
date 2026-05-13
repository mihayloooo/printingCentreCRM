using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList;

namespace PrintingCentre.Management.WebApp.Components
{
    public partial class EnvelopeDetailQuickViewPopup
    {
        [Parameter]
        public EnvelopeListVm? Envelope { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        private async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
