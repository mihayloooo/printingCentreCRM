using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate
{
    public class UpdatePrintTemplateCommandValidator : AbstractValidator<UpdatePrintTemplateCommand>
    {
        private readonly IPrintTemplateRepository _printTemplateRepository;

        public UpdatePrintTemplateCommandValidator(IPrintTemplateRepository printTemplateRepository)
        {
            _printTemplateRepository = printTemplateRepository;

            RuleFor(pt => pt.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(12).WithMessage("{PropertyName} must not exceed 12 characters.");

            RuleFor(pt => pt.TemplateUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(pt => pt.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(pt => pt.QuantityInStock)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");

            RuleFor(pt => pt)
                .MustAsync(PrintTemplateCodeUnique)
                .WithMessage("A print template with the same code already exists.");
        }

        private async Task<bool> PrintTemplateCodeUnique(UpdatePrintTemplateCommand e, CancellationToken token)
        {
            return !await _printTemplateRepository.IsPrintTemplateCodeUnique(e.Code, e.Id);
        }
    }
}

