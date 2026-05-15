using FluentValidation;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.UpdateFlow
{
    public class UpdateFlowCommandValidator : AbstractValidator<UpdateFlowCommand>
    {
        private readonly IFlowRepository _flowRepository;

        public UpdateFlowCommandValidator(IFlowRepository flowRepository)
        {
            _flowRepository = flowRepository;

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(f => f)
                .MustAsync(FlowNameUnique)
                .WithMessage("A flow with the same name already exists for this company.");
        }

        private async Task<bool> FlowNameUnique(UpdateFlowCommand command, CancellationToken token)
        {
            return !await _flowRepository.IsFlowNameUnique(command.CompanyId, command.Name, command.Id);
        }
    }
}
