namespace PrintingCentre.Management.Domain.Entities
{
    public class FlowSequencePrintTemplate
    {
        public Guid Id { get; set; }

        public Guid FlowSequenceId { get; set; }
        public FlowSequence FlowSequence { get; set; } = default!;

        public Guid PrintTemplateId { get; set; }
        public PrintTemplate PrintTemplate { get; set; } = default!;
    }
}
