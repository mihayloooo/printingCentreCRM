using MediatR;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail
{
    public class GetPrintTemplateDetailQuery : IRequest<PrintTemplateDetailVm>
    {
        public Guid Id { get; set; }
    }
}

