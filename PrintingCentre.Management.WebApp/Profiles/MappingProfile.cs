using AutoMapper;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail;

namespace PrintingCentre.Management.WebApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<CompanyDetailVm, UpdateCompanyCommand>().ReverseMap();
        }
    }
}
