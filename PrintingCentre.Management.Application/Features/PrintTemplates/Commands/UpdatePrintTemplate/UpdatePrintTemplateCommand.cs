using MediatR;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate
{
    public class UpdatePrintTemplateCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string TemplateUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public bool IsActive { get; set; }
    }
}

