using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Flows.Commands.UpdateFlow
{
    public class UpdateFlowSequenceData
    {
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
        public PrintSide PrintSide { get; set; }
        public ColorMode ColorMode { get; set; }
        public ShipmentType ShipmentType { get; set; }

        public List<UpdateFlowSequenceTemplateData> Templates { get; set; } = new();
        public List<UpdateFlowSequenceEnvelopeData> Envelopes { get; set; } = new();
    }
}
