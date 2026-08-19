using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList
{
    public class GetFlowsListQueryHandler : IRequestHandler<GetFlowsListQuery, List<FlowListVm>>
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IMapper _mapper;

        public GetFlowsListQueryHandler(IFlowRepository flowRepository, IMapper mapper)
        {
            _flowRepository = flowRepository;
            _mapper = mapper;
        }

        public async Task<List<FlowListVm>> Handle(GetFlowsListQuery request, CancellationToken cancellationToken)
        {
            var allFlows = (await _flowRepository.GetAllWithSequencesAsync()).OrderBy(f => f.Name);
            return _mapper.Map<List<FlowListVm>>(allFlows);
        }
    }
}
