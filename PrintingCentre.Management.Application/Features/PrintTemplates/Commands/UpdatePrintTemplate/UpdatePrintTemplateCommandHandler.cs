using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate
{
    public class UpdatePrintTemplateCommandHandler : IRequestHandler<UpdatePrintTemplateCommand>
    {
        private readonly IPrintTemplateRepository _printTemplateRepository;
        private readonly IMapper _mapper;

        public UpdatePrintTemplateCommandHandler(IPrintTemplateRepository printTemplateRepository, IMapper mapper)
        {
            _printTemplateRepository = printTemplateRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePrintTemplateCommand request, CancellationToken cancellationToken)
        {
            var printTemplateToUpdate = await _printTemplateRepository.GetByIdAsync(request.Id);

            if (printTemplateToUpdate == null)
            {
                throw new NotFoundException(nameof(PrintTemplate), request.Id);
            }

            var validator = new UpdatePrintTemplateCommandValidator(_printTemplateRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, printTemplateToUpdate, typeof(UpdatePrintTemplateCommand), typeof(PrintTemplate));

            await _printTemplateRepository.UpdateAsync(printTemplateToUpdate);
        }
    }
}

