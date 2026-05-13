using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Companies.Commands.CreateCompany;

namespace PrintingCentre.Management.WebApp.Components.Pages
{
    public partial class CompanyAdd
    {
        [SupplyParameterFromForm]
        public CreateCompanyCommand Company { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        protected string Message = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            Company ??= new();
        }

        protected async Task HandleValidSubmit()
        {
            await Mediator.Send(Company);
            IsSaved = true;
            Message = "Company added successfully.";
        }

        protected void HandleInvalidSubmit()
        {
        }
    }
}
