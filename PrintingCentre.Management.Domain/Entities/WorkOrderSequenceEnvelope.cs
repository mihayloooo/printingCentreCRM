namespace PrintingCentre.Management.Domain.Entities
{
    public class WorkOrderSequenceEnvelope
    {
        public Guid Id { get; set; }

        public Guid WorkOrderSequenceId { get; set; }
        public WorkOrderSequence WorkOrderSequence { get; set; } = default!;

        public Guid EnvelopeId { get; set; }
        public Envelope Envelope { get; set; } = default!;

        public int EnvelopedItems { get; set; }
    }
}
