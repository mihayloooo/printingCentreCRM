using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using System.Linq;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList
{
    public class GetPrintTemplatesListQueryHandler : IRequestHandler<GetPrintTemplatesListQuery, List<PrintTemplateListVm>>
    {
        private readonly IPrintTemplateRepository _printTemplateRepository;
        private readonly IMapper _mapper;

        public GetPrintTemplatesListQueryHandler(IPrintTemplateRepository printTemplateRepository, IMapper mapper)
        {
            _printTemplateRepository = printTemplateRepository;
            _mapper = mapper;
        }

        public async Task<List<PrintTemplateListVm>> Handle(GetPrintTemplatesListQuery request, CancellationToken cancellationToken)
        {
            var allPrintTemplates = (await _printTemplateRepository.ListAllAsync()).OrderBy(pt => pt.Code);
            return _mapper.Map<List<PrintTemplateListVm>>(allPrintTemplates);
        }
    }
}

