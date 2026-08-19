using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Commands.CreateFlowSequence
{
    public class CreateFlowSequenceCommandValidator : AbstractValidator<CreateFlowSequenceCommand>
    {
        private readonly IFlowSequenceRepository _flowSequenceRepository;

        public CreateFlowSequenceCommandValidator(IFlowSequenceRepository flowSequenceRepository)
        {
            _flowSequenceRepository = flowSequenceRepository;

            RuleFor(fs => fs.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(fs => fs.FlowId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(fs => fs.PrintSide)
                .IsInEnum().WithMessage("{PropertyName} is not valid.");

            RuleFor(fs => fs.ColorMode)
                .IsInEnum().WithMessage("{PropertyName} is not valid.");

            RuleFor(fs => fs.ShipmentType)
                .IsInEnum().WithMessage("{PropertyName} is not valid.");

            RuleFor(fs => fs)
                .MustAsync(FlowSequenceNameUnique)
                .WithMessage("A flow sequence with the same name already exists for this flow.");
        }

        private async Task<bool> FlowSequenceNameUnique(CreateFlowSequenceCommand command, CancellationToken token)
        {
            return !await _flowSequenceRepository.IsFlowSequenceNameUnique(command.FlowId, command.Name);
        }
    }
}
