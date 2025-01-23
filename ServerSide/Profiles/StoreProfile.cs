using AutoMapper;
using ServerSide.Model;

namespace ServerSide.Dto.StoreDtos
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreAddDto>();
            CreateMap<Store, StoreReadDto>();
            CreateMap<Store, StoreUpdateDto>();
            CreateMap<StoreAddDto, Store>();
            CreateMap<StoreReadDto, Store>();
            CreateMap<StoreUpdateDto, Store>();
        }
    }
}