using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;
using PrintingCentre.Management.Application.Exceptions;
using PrintingCentre.Management.Domain.Entities;

namespace PrintingCentre.Management.Application.Features.FlowSequences.Queries.GetFlowSequenceDetail
{
    public class GetFlowSequenceDetailQueryHandler : IRequestHandler<GetFlowSequenceDetailQuery, FlowSequenceDetailVm>
    {
        private readonly IFlowSequenceRepository _flowSequenceRepository;
        private readonly IMapper _mapper;

        public GetFlowSequenceDetailQueryHandler(IFlowSequenceRepository flowSequenceRepository, IMapper mapper)
        {
            _flowSequenceRepository = flowSequenceRepository;
            _mapper = mapper;
        }

        public async Task<FlowSequenceDetailVm> Handle(GetFlowSequenceDetailQuery request, CancellationToken cancellationToken)
        {
            var flowSequence = await _flowSequenceRepository.GetByIdAsync(request.Id);

            if (flowSequence == null)
                throw new NotFoundException(nameof(FlowSequence), request.Id);

            return _mapper.Map<FlowSequenceDetailVm>(flowSequence);
        }
    }
}
