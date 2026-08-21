namespace PrintingCentre.Management.Application.Features.WorkOrders.Queries.Dtos
{
    public class EnvelopeDto
    {
        public Guid EnvelopeId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EnvelopedItems { get; set; }
    }
}
