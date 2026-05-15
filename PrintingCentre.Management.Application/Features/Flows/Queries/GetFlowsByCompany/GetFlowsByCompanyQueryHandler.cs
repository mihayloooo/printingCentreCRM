using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsList;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowsByCompany
{
    public class GetFlowsByCompanyQueryHandler : IRequestHandler<GetFlowsByCompanyQuery, List<FlowListVm>>
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IMapper _mapper;

        public GetFlowsByCompanyQueryHandler(IFlowRepository flowRepository, IMapper mapper)
        {
            _flowRepository = flowRepository;
            _mapper = mapper;
        }

        public async Task<List<FlowListVm>> Handle(GetFlowsByCompanyQuery request, CancellationToken cancellationToken)
        {
            var flows = (await _flowRepository.GetByCompanyIdAsync(request.CompanyId)).OrderBy(f => f.Name);
            return _mapper.Map<List<FlowListVm>>(flows);
        }
    }
}
