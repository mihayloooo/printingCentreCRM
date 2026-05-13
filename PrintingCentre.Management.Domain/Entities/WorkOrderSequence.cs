namespace PrintingCentre.Management.Domain.Entities
{
    public class WorkOrderSequence
    {
        public Guid Id { get; set; }

        public Guid WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; } = default!;

        public Guid FlowSequenceId { get; set; }
        public FlowSequence FlowSequence { get; set; } = default!;

        public ICollection<WorkOrderSequenceTemplate> WorkOrderSequenceTemplates { get; set; } = default!;
        public ICollection<WorkOrderSequenceEnvelope> WorkOrderSequenceEnvelopes { get; set; } = default!;
    }
}
