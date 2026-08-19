using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.Flows.Queries.GetFlowDetail
{
    public class GetFlowDetailQueryHandler : IRequestHandler<GetFlowDetailQuery, FlowDetailVm>
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IMapper _mapper;

        public GetFlowDetailQueryHandler(IFlowRepository flowRepository, IMapper mapper)
        {
            _flowRepository = flowRepository;
            _mapper = mapper;
        }

        public async Task<FlowDetailVm> Handle(GetFlowDetailQuery request, CancellationToken cancellationToken)
        {
            var flow = await _flowRepository.GetByIdWithSequencesAsync(request.Id);

            if (flow == null)
                throw new NotFoundException(nameof(Flow), request.Id);

            return _mapper.Map<FlowDetailVm>(flow);
        }
    }
}
