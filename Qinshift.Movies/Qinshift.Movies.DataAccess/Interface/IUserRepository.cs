using Qinshift.Movies.DomainModels;

namespace Qinshift.Movies.DataAccess.Interface
{
    public interface IUserRepository
    {
        User LoginUser(string userName, string password);
        void CreateUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUserById(int userId);
        void DeleteUser(User user);
    }
}
