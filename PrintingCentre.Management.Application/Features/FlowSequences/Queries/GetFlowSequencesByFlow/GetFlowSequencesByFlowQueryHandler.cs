using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequencesByFlow
{
    public class GetFlowSequencesByFlowQueryHandler : IRequestHandler<GetFlowSequencesByFlowQuery, List<FlowSequenceListVm>>
    {
        private readonly IFlowSequenceRepository _flowSequenceRepository;
        private readonly IMapper _mapper;

        public GetFlowSequencesByFlowQueryHandler(IFlowSequenceRepository flowSequenceRepository, IMapper mapper)
        {
            _flowSequenceRepository = flowSequenceRepository;
            _mapper = mapper;
        }

        public async Task<List<FlowSequenceListVm>> Handle(GetFlowSequencesByFlowQuery request, CancellationToken cancellationToken)
        {
            var sequences = (await _flowSequenceRepository.GetByFlowIdAsync(request.FlowId)).OrderBy(fs => fs.Name);
            return _mapper.Map<List<FlowSequenceListVm>>(sequences);
        }
    }
}
