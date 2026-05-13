using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList;

namespace PrintingCentre.Management.WebApp.Components.DetailQuickView
{
    public partial class PrintTemplateDetailQuickViewPopup
    {
        [Parameter]
        public PrintTemplateListVm? PrintTemplate { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        private async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}

