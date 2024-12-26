using Qinshift.Movies.DataAccess.Interface;
using Qinshift.Movies.DTOs;
using Qinshift.Movies.Services.Helper;
using Qinshift.Movies.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Qinshift.Movies.DomainModels;

namespace Qinshift.Movies.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepo = userRepository;
            _mapper = mapper;}

        public int CreateUser(CreateUserDto userDto)
        {
            if (userDto.UserName != null && userDto.Password != null)
            {
                _userRepo.CreateUser(UserMapper.ToUser(userDto));
                return 1;
            }
            else { throw new Exception("You cannot leave empty fields!"); }
        }

        public void DeleteUser(UserDto userToDelete)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int userIdToDelete)
        {
            throw new NotImplementedException();
        }

        public void EditUser(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }

        public UserDto LogInUser(string username, string password)
        {
            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                throw new Exception("You must enter username and password!");
            }
            var result = _userRepo.LoginUser(username, PasswordHash(password));
            if (result == null){
                throw new Exception("Username and/or password do not match!");
            }
            else 
            {
                //var resultToDto = UserMapper.ToUserDto(result);
                var resultToDto = _mapper.Map<User, UserDto>(result);
                return resultToDto;
            }
        }

        public static string PasswordHash (string password)
        {
            MD5 md5CryptoService = MD5.Create();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            byte[] hashBytes = md5CryptoService.ComputeHash(passwordBytes);

            string hashedPassword = Encoding.ASCII.GetString(hashBytes);
            return hashedPassword;

        }
    }
}
