using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.WorkOrders.Queries.GetWorkOrdersList
{
    public class GetWorkOrdersListQueryHandler : IRequestHandler<GetWorkOrdersListQuery, List<WorkOrderListVm>>
    {
        private readonly IWorkOrderRepository _workOrderRepository;
        private readonly IMapper _mapper;

        public GetWorkOrdersListQueryHandler(IWorkOrderRepository workOrderRepository, IMapper mapper)
        {
            _workOrderRepository = workOrderRepository;
            _mapper = mapper;
        }

        public async Task<List<WorkOrderListVm>> Handle(GetWorkOrdersListQuery request, CancellationToken cancellationToken)
        {
            var allWorkOrders = (await _workOrderRepository.GetAllWithSequencesAsync()).OrderBy(w => w.Code);
            return _mapper.Map<List<WorkOrderListVm>>(allWorkOrders);
        }
    }
}
