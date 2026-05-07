using MediatR;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList
{
    public class GetPrintTemplatesListQuery : IRequest<List<PrintTemplateListVm>>
    {
    }
}

