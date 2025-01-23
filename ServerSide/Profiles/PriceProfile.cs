using AutoMapper;
using ServerSide.Model;

namespace ServerSide.Dto.PriceDtos
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<Price, PriceAddDto>();
            CreateMap<Price, PriceReadDto>();
            CreateMap<Price, PriceUpdateDto>();
            CreateMap<PriceAddDto, Price>();
            CreateMap<PriceReadDto, Price>();
            CreateMap<PriceUpdateDto, Price>();
        }
    }
}