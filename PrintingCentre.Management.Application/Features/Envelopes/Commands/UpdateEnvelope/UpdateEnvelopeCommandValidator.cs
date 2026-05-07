using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope
{
    public class UpdateEnvelopeCommandValidator : AbstractValidator<UpdateEnvelopeCommand>
    {
        private readonly IEnvelopeRepository _envelopeRepository;

        public UpdateEnvelopeCommandValidator(IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;

            RuleFor(e => e.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(12).WithMessage("{PropertyName} must not exceed 12 characters.");

            RuleFor(e => e.EnvelopeUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(e => e.QuantityInStock)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");

            RuleFor(e => e)
                .MustAsync(EnvelopeCodeUnique)
                .WithMessage("An envelope with the same code already exists.");
        }

        private async Task<bool> EnvelopeCodeUnique(UpdateEnvelopeCommand e, CancellationToken token)
        {
            return !await _envelopeRepository.IsEnvelopeCodeUnique(e.Code, e.Id);
        }
    }
}

