using AutoMapper;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>()
        .ForMember(d => d.CategoryId, opt => opt.MapFrom(source => source.Category));
        CreateMap<ProductViewModel, Product>()
        .ForMember(d => d.Category, opt => opt.MapFrom(source => source.CategoryId));
        CreateMap<Service, ServiceViewModel>();
        CreateMap<ServiceViewModel, Service>();
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();


    }
}
