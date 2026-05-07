using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail
{
    public class GetCompanyDetailQueryHandler : IRequestHandler<GetCompanyDetailQuery, CompanyDetailVm>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyDetailQueryHandler(
            IMapper mapper,
            ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDetailVm> Handle(GetCompanyDetailQuery request, CancellationToken cancellationToken)
        {
            var @company = await _companyRepository.GetByIdAsync(request.Id);
            var companyDetailDto = _mapper.Map<CompanyDetailVm>(@company);

            return companyDetailDto;
        }
    }
}
