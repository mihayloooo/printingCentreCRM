using MediatR;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Commands.CreateFlowSequence
{
    public class CreateFlowSequenceCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public Guid FlowId { get; set; }
    }
}
