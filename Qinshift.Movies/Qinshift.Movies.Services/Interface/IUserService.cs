using Qinshift.Movies.DTOs;

namespace Qinshift.Movies.Services.Interface
{
    public interface IUserService
    {
        UserDto LogInUser (string username, string password);
        int CreateUser (CreateUserDto userDto);
        void EditUser (CreateUserDto userDto);
        void DeleteUser(UserDto userToDelete);
        void DeleteUserById(int userIdToDelete);
    }
}
