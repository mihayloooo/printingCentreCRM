namespace PrintingCentre.Management.Application.Features.Flows.Queries.Dtos
{
    public class PrintTemplateDto
    {
        public Guid PrintTemplateId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
