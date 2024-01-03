using AutoMapper;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>().ReverseMap();
        CreateMap<ProductViewModel, Product>().ReverseMap();
        CreateMap<Service, ServiceViewModel>().ReverseMap();
        CreateMap<ServiceViewModel, Service>().ReverseMap();

    }
}
