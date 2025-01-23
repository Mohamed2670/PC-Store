using AutoMapper;
using ServerSide.Data;
using ServerSide.Dto.BuildDtos;
using ServerSide.Model;
using ServerSide.Repository;

namespace ServerSide.Service
{
    public class BuildService(BuildRepository _repository, IMapper _mapper)
    {
        public async Task<ICollection<BuildReadDto>> GetAllBuildsByUserId(int userId)
        {
            var builds = await _repository.GetBuildsByUserId(userId);
            var buildsReadDtos = _mapper.Map<ICollection<BuildReadDto>>(builds);
            return buildsReadDtos;
        }
        public async Task<ICollection<BuildReadDto>?> GetAllBuilds()
        {
            var builds = await _repository.GetAll();
            var buildsReadDtos = _mapper.Map<ICollection<BuildReadDto>>(builds);
            return buildsReadDtos;
        }
        public async Task<BuildReadDto?> GetBuildById(int id)
        {
            var build = await _repository.GetById(id);
            var buildReadDto = _mapper.Map<BuildReadDto>(build);
            return buildReadDto;
        }
        public async Task<BuildReadDto?> AddBuild(BuildAddDto buildAddDto)
        {
            var build = _mapper.Map<Build>(buildAddDto);
            var buildAdded = await _repository.Add(build);
            var buildReadDto = _mapper.Map<BuildReadDto>(buildAdded);
            return buildReadDto;
        }
        public async Task<BuildReadDto?> UpdateBuild(BuildUpdateDto buildUpdateDto)
        {
            var build = await _repository.GetById(buildUpdateDto.Id);
            if (build == null)
            {
                return null;
            }
            var buildUpdated =await _repository.Update( _mapper.Map(buildUpdateDto, build));
            var buildReadDto  = _mapper.Map<BuildReadDto>(buildUpdated);
            return buildReadDto;

        }
        public async Task<BuildReadDto?> DeleteBuildById(int id)
        {
            var build = await _repository.GetById(id);
            if (build == null)
            {
                return null;
            }
            await _repository.Delete(build.Id);
            var buildReadDto = _mapper.Map<BuildReadDto>(build);
            return buildReadDto;
        }

    }
}