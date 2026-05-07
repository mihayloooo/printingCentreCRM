using MediatR;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Commands.CreatePrintTemplate
{
    public class CreatePrintTemplateCommand : IRequest<Guid>
    {
        public string Code { get; set; } = string.Empty;
        public string TemplateUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

