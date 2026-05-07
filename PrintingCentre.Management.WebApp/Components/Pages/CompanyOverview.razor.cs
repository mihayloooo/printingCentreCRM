using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList;

namespace PrintingCentre.Management.WebApp.Components.Pages
{
    public partial class CompanyOverview
    {
        public List<CompanyListVm> Companies { get; set; } = default!;
        private CompanyListVm? _selectedCompany;

        //[Parameter]
        //public EventCallback<CompanyListVm> CompanyQuickViewClicked { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Companies = await Mediator.Send(new GetCompaniesListQuery());
        }

        public void ShowQuickViewPopup(CompanyListVm company)
        {
            _selectedCompany = company;
        }

        private void ClosePopup()
        {
            _selectedCompany = null;
        }
    }
}
