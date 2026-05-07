using MediatR;

namespace PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompaniesListQuery : IRequest<List<CompanyListVm>>
    {
    }
}
