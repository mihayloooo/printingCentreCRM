namespace PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail
{
    public class PrintTemplateDetailVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string TemplateUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public bool IsActive { get; set; }
    }
}

