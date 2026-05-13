using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail;

namespace PrintingCentre.Management.WebApp.Components.Pages
{
    public partial class PrintTemplateEdit
    {
        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid PrintTemplateId { get; set; }
        public PrintTemplateDetailVm PrintTemplateDetail { get; set; } = new();

        [SupplyParameterFromForm]
        public UpdatePrintTemplateCommand PrintTemplateToUpdate { get; set; } = new();

        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            PrintTemplateDetail = await Mediator.Send(new GetPrintTemplateDetailQuery { Id = PrintTemplateId });
            PrintTemplateToUpdate = Mapper.Map<UpdatePrintTemplateCommand>(PrintTemplateDetail);
        }

        protected async Task HandleValidSubmit()
        {
            PrintTemplateToUpdate.Id = PrintTemplateId;
            await Mediator.Send(PrintTemplateToUpdate);
            StatusClass = "alert-success";
            Message = "Print template updated successfully.";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/templates");
        }
    }
}
