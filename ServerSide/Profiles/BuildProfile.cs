using AutoMapper;
using ServerSide.Model;

namespace ServerSide.Dto.BuildDtos
{
    public class BuildProfile : Profile
    {
        public BuildProfile()
        {
            CreateMap<Build, BuildAddDto>();
            CreateMap<Build, BuildReadDto>();
            CreateMap<Build, BuildUpdateDto>();
            CreateMap<BuildAddDto, Build>();
            CreateMap<BuildReadDto, Build>();
            CreateMap<BuildUpdateDto, Build>();
        }
    }
}