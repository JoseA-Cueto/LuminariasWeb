using AutoMapper;
using LuminariasWeb.sln.Models;
using LuminariasWeb.sln.ViewModels;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageFile.PhysicalPath));

        CreateMap<ProductViewModel, Product>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

        CreateMap<Category, CategoryViewModel>();
        CreateMap<CategoryViewModel, Category>();

        CreateMap<Service, ServiceViewModel>();
        CreateMap<ServiceViewModel, Service>();

        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();

        CreateMap<ImageFile, ImageFilesViewModel>();
        CreateMap<ImageFilesViewModel, ImageFile>();

       
    }
}

