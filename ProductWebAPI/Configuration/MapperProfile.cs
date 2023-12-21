using AutoMapper;
using ProductCore.Models;
using ProductWebAPI.Models;

namespace ProductWebAPI.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.CreatedAt, 
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Product, ProductGetDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<ProductEditDto, Product>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<FingerprintBase, FingerprintDto>()
            //    .ForMember(dest => dest.FingerprintId,
            //        opt => opt.MapFrom(src => src.FprtId));
        }
    }
}
