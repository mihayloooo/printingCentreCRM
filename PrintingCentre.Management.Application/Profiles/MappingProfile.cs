using AutoMapper;
using PrintingCentre.Management.Application.Features.Companies.Commands.CreateCompany;
using PrintingCentre.Management.Application.Features.Companies.Commands.UpdateCompany;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompaniesList;
using PrintingCentre.Management.Application.Features.Companies.Queries.GetCompanyDetail;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.CreateEnvelope;
using PrintingCentre.Management.Application.Features.Envelopes.Commands.UpdateEnvelope;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopesList;
using PrintingCentre.Management.Application.Features.Envelopes.Queries.GetEnvelopeDetail;
using PrintingCentre.Management.Domain.Entities;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.CreatePrintTemplate;
using PrintingCentre.Management.Application.Features.PrintTemplates.Commands.UpdatePrintTemplate;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplatesList;
using PrintingCentre.Management.Application.Features.PrintTemplates.Queries.GetPrintTemplateDetail;

namespace PrintingCentre.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Company, CompanyListVm>().ReverseMap();
            CreateMap<Company, CompanyDetailVm>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();

            CreateMap<PrintTemplate, PrintTemplateListVm>().ReverseMap();
            CreateMap<PrintTemplate, PrintTemplateDetailVm>().ReverseMap();
            CreateMap<PrintTemplate, CreatePrintTemplateCommand>().ReverseMap();
            CreateMap<PrintTemplate, UpdatePrintTemplateCommand>().ReverseMap();

            CreateMap<Envelope, EnvelopeListVm>().ReverseMap();
            CreateMap<Envelope, EnvelopeDetailVm>().ReverseMap();
            CreateMap<Envelope, CreateEnvelopeCommand>().ReverseMap();
            CreateMap<Envelope, UpdateEnvelopeCommand>().ReverseMap();
        }
    }
}
