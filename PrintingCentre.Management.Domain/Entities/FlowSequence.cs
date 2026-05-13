using PrintingCentre.Management.Domain.Common;

namespace PrintingCentre.Management.Domain.Entities
{
    public class FlowSequence : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }

        public Guid FlowId { get; set; }
        public Flow Flow { get; set; } = default!;

        public ICollection<PrintTemplate> PrintTemplates { get; set; } = default!;
        public ICollection<Envelope> Envelopes { get; set; } = default!;
        public ICollection<WorkOrderSequence> WorkOrderSequences { get; set; } = default!;
    }
}
