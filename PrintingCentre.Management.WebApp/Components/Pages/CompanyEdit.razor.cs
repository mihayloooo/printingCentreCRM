using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail;

namespace PrintingCentre.Management.WebApp.Components.Pages
{
    public partial class CompanyEdit
    {
        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid CompanyId { get; set; }
        public CompanyDetailVm CompanyDetail { get; set; } = new();

        [SupplyParameterFromForm]
        public UpdateCompanyCommand CompanyToUpdate { get; set; } = new();

        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            CompanyDetail = await Mediator.Send(new GetCompanyDetailQuery() { Id = CompanyId });
            CompanyToUpdate = Mapper.Map<UpdateCompanyCommand>(CompanyDetail);
        }

        protected async Task HandleValidSubmit()
        {
            CompanyToUpdate.CompanyId = CompanyId;
            await Mediator.Send(CompanyToUpdate);
            StatusClass = "alert-success";
            Message = "Company updated successfully.";
            Saved = true;
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/companyoverview");
        }
    }
}
