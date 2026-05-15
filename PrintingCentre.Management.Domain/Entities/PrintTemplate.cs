using PrintingCentre.Management.Domain.Common;

namespace PrintingCentre.Management.Domain.Entities
{
    public class PrintTemplate : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string TemplateUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityInStock { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public ICollection<FlowSequencePrintTemplate> FlowSequencePrintTemplates { get; set; } = default!;
        public ICollection<WorkOrderSequenceTemplate> WorkOrderSequenceTemplates { get; set; } = default!;
    }
}
