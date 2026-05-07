using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using System.Linq;

namespace PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList
{
    public class GetEnvelopesListQueryHandler : IRequestHandler<GetEnvelopesListQuery, List<EnvelopeListVm>>
    {
        private readonly IEnvelopeRepository _envelopeRepository;
        private readonly IMapper _mapper;

        public GetEnvelopesListQueryHandler(IEnvelopeRepository envelopeRepository, IMapper mapper)
        {
            _envelopeRepository = envelopeRepository;
            _mapper = mapper;
        }

        public async Task<List<EnvelopeListVm>> Handle(GetEnvelopesListQuery request, CancellationToken cancellationToken)
        {
            var allEnvelopes = (await _envelopeRepository.ListAllAsync()).OrderBy(e => e.Code);
            return _mapper.Map<List<EnvelopeListVm>>(allEnvelopes);
        }
    }
}

