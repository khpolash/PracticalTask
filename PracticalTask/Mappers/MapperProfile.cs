using AutoMapper;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;

namespace PracticalTask.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductVm, Product>();
        CreateMap<Product, ProductVm>()
            .ForMember(d => d.UnitName, opts => opts.MapFrom(src => src.ProductUnit.UnitName));

        CreateMap<ProductUnitVm, ProductUnit>().ReverseMap();
        CreateMap<IndividualCustomerVm, IndividualCustomer>().ReverseMap();
        CreateMap<CorporateCustomerVm, CorporateCustomer>().ReverseMap();

        CreateMap<MeetingMinutesMasterVm, MeetingMinutesMaster>()
            .ForMember(d => d.CorporateCustomer, opts => opts.Ignore())
            .ForMember(d => d.IndividualCustomer, opts => opts.Ignore())
            .ForMember(d => d.MeetingMinutesDetails, opts => opts.Ignore());

        CreateMap<MeetingMinutesMaster, MeetingMinutesMasterVm>()
            .ForMember(d => d.CorporateCustomerDropdown, opts => opts.Ignore())
            .ForMember(d => d.IndividualCustomerDropdown, opts => opts.Ignore())
            .ForMember(d => d.Products, opts => opts.Ignore())
            .ForMember(d => d.CorporateCustomerName, opts => opts.MapFrom(src => src.CorporateCustomer.CustomerName))
            .ForMember(d => d.IndividualCustomerName, opts => opts.MapFrom(src => src.IndividualCustomer.CustomerName));

        CreateMap<MeetingMinutesDetailsVm, MeetingMinutesDetails>()
            .ForMember(d => d.Product, opts => opts.Ignore())
            .ForMember(d => d.MeetingMinutesMaster, opts => opts.Ignore());

        CreateMap<MeetingMinutesDetails, MeetingMinutesDetailsVm>()
            .ForMember(d => d.ProductDropdown, opts => opts.Ignore())
            .ForMember(d => d.ProductName, opts => opts.MapFrom(src => src.Product.ProductName));

        AllowNullCollections = true;
    }
}
