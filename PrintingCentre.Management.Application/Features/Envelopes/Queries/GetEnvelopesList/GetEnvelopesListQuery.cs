using MediatR;

namespace PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList
{
    public class GetEnvelopesListQuery : IRequest<List<EnvelopeListVm>>
    {
    }
}

