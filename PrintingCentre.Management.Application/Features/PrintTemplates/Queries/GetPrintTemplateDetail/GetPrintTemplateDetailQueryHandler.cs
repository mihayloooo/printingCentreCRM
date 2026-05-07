using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail
{
    public class GetPrintTemplateDetailQueryHandler : IRequestHandler<GetPrintTemplateDetailQuery, PrintTemplateDetailVm>
    {
        private readonly IPrintTemplateRepository _printTemplateRepository;
        private readonly IMapper _mapper;

        public GetPrintTemplateDetailQueryHandler(IMapper mapper, IPrintTemplateRepository printTemplateRepository)
        {
            _mapper = mapper;
            _printTemplateRepository = printTemplateRepository;
        }

        public async Task<PrintTemplateDetailVm> Handle(GetPrintTemplateDetailQuery request, CancellationToken cancellationToken)
        {
            var printTemplate = await _printTemplateRepository.GetByIdAsync(request.Id);

            if (printTemplate == null)
            {
                throw new NotFoundException(nameof(PrintTemplate), request.Id);
            }

            return _mapper.Map<PrintTemplateDetailVm>(printTemplate);
        }
    }
}

