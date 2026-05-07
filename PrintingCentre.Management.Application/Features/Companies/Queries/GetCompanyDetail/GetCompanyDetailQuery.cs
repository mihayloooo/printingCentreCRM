using MediatR;

namespace PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail
{
    public class GetCompanyDetailQuery : IRequest<CompanyDetailVm>
    {
        public Guid Id { get; set; }
    }
}
