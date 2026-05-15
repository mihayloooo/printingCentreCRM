using MediatR;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.CreateFlow
{
    public class CreateFlowCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public Guid CompanyId { get; set; }
        public List<CreateFlowSequenceData> FlowSequences { get; set; } = new();
    }
}
