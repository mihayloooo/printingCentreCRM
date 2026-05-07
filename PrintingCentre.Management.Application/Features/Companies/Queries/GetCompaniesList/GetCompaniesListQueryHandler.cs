using AutoMapper;
using MediatR;
using PrintingCentre.Management.Application.Contracts.Persistence;

namespace PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery, List<CompanyListVm>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public GetCompaniesListQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<List<CompanyListVm>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var allCompanies = (await _companyRepository.ListAllAsync()).OrderBy(c => c.Code);
            return _mapper.Map<List<CompanyListVm>>(allCompanies);
        }
    }
}
