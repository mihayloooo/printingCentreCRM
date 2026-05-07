using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Envelopes.Commands.CreateEnvelope
{
    public class CreateEnvelopeCommandValidator : AbstractValidator<CreateEnvelopeCommand>
    {
        private readonly IEnvelopeRepository _envelopeRepository;

        public CreateEnvelopeCommandValidator(IEnvelopeRepository envelopeRepository)
        {
            _envelopeRepository = envelopeRepository;

            RuleFor(e => e.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(12).WithMessage("{PropertyName} must not exceed 12 characters.");

            RuleFor(e => e.EnvelopeUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(e => e)
                .MustAsync(EnvelopeCodeUnique)
                .WithMessage("An envelope with the same code already exists.");
        }

        private async Task<bool> EnvelopeCodeUnique(CreateEnvelopeCommand e, CancellationToken token)
        {
            // Repo returns true when a match exists (consistent with existing Company logic).
            return !await _envelopeRepository.IsEnvelopeCodeUnique(e.Code);
        }
    }
}

