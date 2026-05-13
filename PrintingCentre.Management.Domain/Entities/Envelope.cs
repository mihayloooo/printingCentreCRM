using PrintingCentre.Management.Domain.Common;

namespace PrintingCentre.Management.Domain.Entities
{
    public class Envelope : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string EnvelopeUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityInStock { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public ICollection<FlowSequence> FlowSequences { get; set; } = default!;
        public ICollection<WorkOrderSequenceEnvelope> WorkOrderSequenceEnvelopes { get; set; } = default!;
    }
}
