namespace PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList
{
    public class PrintTemplateListVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string TemplateUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

