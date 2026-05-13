using MediatR;

namespace PrintingCentre.Management.Application.Features.Envelopes.Commands.CreateEnvelope
{
    public class CreateEnvelopeCommand : IRequest<Guid>
    {
        public string Code { get; set; } = string.Empty;
        public string EnvelopeUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

