using MediatR;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.UpdateFlow
{
    public class UpdateFlowCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public List<UpdateFlowSequenceData> FlowSequences { get; set; } = new();
    }
}
