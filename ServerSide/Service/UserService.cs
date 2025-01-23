using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ServerSide.Dto.UserDtos;
using ServerSide.Model;
using ServerSide.Repository;

namespace ServerSide.Service
{
    public class UserService(UserRepository _repository, IMapper _mapper, JwtOptions jwtOptions)
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
        public async Task<UserReadDto?> UpdateUser(UserUpdateDto userUpdateDto, string email)
        {
            var user = await _repository.GetByEmail(email);
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
        public async Task<string?> Login(UserLoginDto userLoginDto)
        {
            var user = await _repository.GetByEmail(userLoginDto.Email);
            if (user == null)
            {
                return null;
            }
            
            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                return null;
            }

            return TokenGenerate(user);
        }
        public string TokenGenerate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new(ClaimTypes.Email,user.Email),
                    new(ClaimTypes.Role,user.Role.ToString()),
                    new("StoreId",user.StoreId.ToString())
                })
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
    }
}