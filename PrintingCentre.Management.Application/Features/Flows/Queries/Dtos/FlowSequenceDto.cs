using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.Dtos
{
    public class FlowSequenceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }
        public List<PrintTemplateDto> Templates { get; set; } = new();
        public List<EnvelopeDto> Envelopes { get; set; } = new();
    }
}
