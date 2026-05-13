using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.CreatePrintTemplate;

namespace PrintingCentre.Management.WebApp.Components.Pages
{
    public partial class PrintTemplateAdd
    {
        [SupplyParameterFromForm]
        public CreatePrintTemplateCommand PrintTemplate { get; set; } = new();

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            PrintTemplate ??= new();
        }

        protected async Task HandleValidSubmit()
        {
            await Mediator.Send(PrintTemplate);
            StatusClass = "alert-success";
            Message = "Print template added successfully.";
            IsSaved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/templates");
        }
    }
}
