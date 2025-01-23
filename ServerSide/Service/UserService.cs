using AutoMapper;
using ServerSide.Dto.UserDtos;
using ServerSide.Model;
using ServerSide.Repository;

namespace ServerSide.Service
{
    public class UserService(UserRepository _repository, IMapper _mapper)
    {
        public async Task<UserReadDto> AddUser(UserAddDto userAddDto)
        {

            var user = _mapper.Map<User>(userAddDto);
            var userAdded = await _repository.Add(user);
            var userReadDto = _mapper.Map<UserReadDto>(userAdded);
            return userReadDto;
        }
        public async Task<ICollection<UserReadDto>?> GetAllUsers()
        {
            var users = await _repository.GetAll();
            var userReadDtos = _mapper.Map<ICollection<UserReadDto>>(users);
            return userReadDtos;
        }
        public async Task<UserReadDto?> GetUserById(int id)
        {
            var user = await _repository.GetById(id);
            var userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }
        public async Task<UserReadDto?> GetUserByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);
            var userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }
        public async Task<UserReadDto?> UpdateUser(UserUpdateDto userUpdateDto,string email)
        {
            var user  = await _repository.GetByEmail(email);
            if (user == null)
            {
                return null;
            }
            var userUpdated = await _repository.Update(_mapper.Map(userUpdateDto, user));
            var userReadDto = _mapper.Map<UserReadDto>(userUpdated);    
            return userReadDto;
                        
        }
        public async Task<UserReadDto?> DeleteUserById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                return null;
            }
            var userDeleted = await _repository.Delete(id);
            var userReadDto = _mapper.Map<UserReadDto>(userDeleted);
            return userReadDto;
        }
    }
}