using AutoMapper;
using ServerSide.Model;

namespace ServerSide.Dto.ProductDtos
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductAddDto>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductReadDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}