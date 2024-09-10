using Qinshift.Movies.DataAccess.Interface;
using Qinshift.Movies.DomainModels;

namespace Qinshift.Movies.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {
        MovieAppDbContext _dbContext;
        public UserRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateUser(User user)
        {
            if (user != null && _dbContext.Users.SingleOrDefault(x=> x.UserName == user.UserName) == null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            else { throw new Exception("User already exists!"); }
        }

        public void DeleteUser(User user)
        {
            if(user != null && _dbContext.Users.Find(user) == null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            else { throw new Exception("Error occured. User not deleted!"); }
        }

        public void DeleteUserById(int userId)
        {
            var userToDelete = _dbContext.Users.Find(userId);
            if (userToDelete != null) 
            {
                DeleteUser(userToDelete);
                _dbContext.SaveChanges();
            }
            else { throw new Exception("Error occured. User not deleted!"); }
        }

        public User LoginUser(string userName, string password)
        {
            var loggedUser = _dbContext.Users.SingleOrDefault(x=> x.UserName == userName && x.Password == password);
            return loggedUser;
        }

        public void UpdateUser(int id, User user)
        {
            var userToEdit = _dbContext.Users.Find(id);
            if (userToEdit != null) 
            {
                userToEdit.UserName = user.UserName;
                userToEdit.Password = user.Password;
                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;

                _dbContext.SaveChanges();
            }
            else { throw new Exception("Error occured. Contact HR"); }

        }
    }
}
