namespace PrintingCentre.Management.Domain.Entities
{
    public class WorkOrderSequenceTemplate
    {
        public Guid Id { get; set; }

        public Guid WorkOrderSequenceId { get; set; }
        public WorkOrderSequence WorkOrderSequence { get; set; } = default!;

        public Guid PrintTemplateId { get; set; }
        public PrintTemplate PrintTemplate { get; set; } = default!;

        public int PrintedPages { get; set; }
    }
}
