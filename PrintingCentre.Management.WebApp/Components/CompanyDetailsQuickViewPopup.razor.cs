using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList;

namespace PrintingCentre.Management.WebApp.Components
{
    public partial class CompanyDetailsQuickViewPopup
    {
        //private CompanyListVm? _company;

        [Parameter]
        public CompanyListVm? Company { get; set; }

        [Parameter]
        public EventCallback OnClose { get; set; }

        private async Task Close()
        {
            await OnClose.InvokeAsync();
        }
    }
}
