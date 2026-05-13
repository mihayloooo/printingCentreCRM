using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Companies.Commands.CreateCompany;

namespace PrintingCentre.Management.WebApp.Components.Pages.Companies
{
    public partial class CompanyAdd
    {
        [SupplyParameterFromForm]
        public CreateCompanyCommand Company { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Company ??= new();
        }

        protected async Task HandleValidSubmit()
        {
            await Mediator.Send(Company);
            StatusClass = "alert-success";
            Message = "Company added successfully.";
            IsSaved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/companyoverview");
        }
    }
}

