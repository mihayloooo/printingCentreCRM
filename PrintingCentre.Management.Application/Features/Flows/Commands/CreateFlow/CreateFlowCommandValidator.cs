using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.CreateFlow
{
    public class CreateFlowCommandValidator : AbstractValidator<CreateFlowCommand>
    {
        private readonly IFlowRepository _flowRepository;

        public CreateFlowCommandValidator(IFlowRepository flowRepository)
        {
            _flowRepository = flowRepository;

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(f => f.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(f => f)
                .MustAsync(FlowNameUnique)
                .WithMessage("A flow with the same name already exists for this company.");

            RuleFor(f => f.FlowSequences)
                .NotEmpty().WithMessage("At least one flow sequence is required.");

            RuleForEach(f => f.FlowSequences).ChildRules(sequence =>
            {
                sequence.RuleFor(fs => fs.Name)
                    .NotEmpty().WithMessage("Sequence name is required.")
                    .MaximumLength(50).WithMessage("Sequence name must not exceed 50 characters.");

                sequence.RuleFor(fs => fs.PrintSide)
                    .IsInEnum().WithMessage("Print side is not valid.");

                sequence.RuleFor(fs => fs.ColorMode)
                    .IsInEnum().WithMessage("Color mode is not valid.");

                sequence.RuleFor(fs => fs.ShipmentType)
                    .IsInEnum().WithMessage("Shipment type is not valid.");
            });
        }

        private async Task<bool> FlowNameUnique(CreateFlowCommand command, CancellationToken token)
        {
            return !await _flowRepository.IsFlowNameUnique(command.CompanyId, command.Name);
        }
    }
}
