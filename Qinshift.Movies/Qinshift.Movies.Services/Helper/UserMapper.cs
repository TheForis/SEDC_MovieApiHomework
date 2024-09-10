using Microsoft.IdentityModel.Tokens;
using Qinshift.Movies.DomainModels;
using Qinshift.Movies.DTOs;
using Qinshift.Movies.Services.Implementation;
using System.IdentityModel.Tokens.Jwt;

namespace Qinshift.Movies.Services.Helper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var generatedToken = TokenHelper.GenerateToken(user);
            return  new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Token = tokenHandler.WriteToken(generatedToken)
            };
        }
        public static User ToUser(CreateUserDto user)
        {
            var hashedPassword = UserService.PasswordHash(user.Password);
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = hashedPassword
            };
        }

    }
}
