using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequenceDetail
{
    public class FlowSequenceDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public Guid FlowId { get; set; }
    }
}
