using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Commands.CreatePrintTemplate
{
    public class CreatePrintTemplateCommandHandler : IRequestHandler<CreatePrintTemplateCommand, Guid>
    {
        private readonly IPrintTemplateRepository _printTemplateRepository;
        private readonly IMapper _mapper;

        public CreatePrintTemplateCommandHandler(IPrintTemplateRepository printTemplateRepository, IMapper mapper)
        {
            _printTemplateRepository = printTemplateRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePrintTemplateCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePrintTemplateCommandValidator(_printTemplateRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var printTemplate = _mapper.Map<PrintTemplate>(request);

            await _printTemplateRepository.AddAsync(printTemplate);

            return printTemplate.Id;
        }
    }
}

