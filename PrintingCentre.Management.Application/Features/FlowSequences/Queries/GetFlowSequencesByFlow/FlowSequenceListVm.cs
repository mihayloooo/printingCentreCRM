using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequencesByFlow
{
    public class FlowSequenceListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public Guid FlowId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
