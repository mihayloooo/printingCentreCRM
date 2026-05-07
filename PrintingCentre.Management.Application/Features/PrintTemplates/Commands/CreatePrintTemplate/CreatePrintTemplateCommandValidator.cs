using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Commands.CreatePrintTemplate
{
    public class CreatePrintTemplateCommandValidator : AbstractValidator<CreatePrintTemplateCommand>
    {
        private readonly IPrintTemplateRepository _printTemplateRepository;

        public CreatePrintTemplateCommandValidator(IPrintTemplateRepository printTemplateRepository)
        {
            _printTemplateRepository = printTemplateRepository;

            RuleFor(pt => pt.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(12).WithMessage("{PropertyName} must not exceed 12 characters.");

            RuleFor(pt => pt.TemplateUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(pt => pt.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(pt => pt)
                .MustAsync(PrintTemplateCodeUnique)
                .WithMessage("A print template with the same code already exists.");
        }

        private async Task<bool> PrintTemplateCodeUnique(CreatePrintTemplateCommand e, CancellationToken token)
        {
            // Repo returns true when a match exists (consistent with existing Company logic).
            return !await _printTemplateRepository.IsPrintTemplateCodeUnique(e.Code);
        }
    }
}

