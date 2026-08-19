namespace PrintingCentre.Management.Domain.Entities
{
    public class FlowSequenceEnvelope
    {
        public Guid Id { get; set; }

        public Guid FlowSequenceId { get; set; }
        public FlowSequence FlowSequence { get; set; } = default!;

        public Guid EnvelopeId { get; set; }
        public Envelope Envelope { get; set; } = default!;
    }
}
