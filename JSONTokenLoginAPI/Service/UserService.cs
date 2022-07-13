using JSONTokenLoginAPI.Entities;

namespace JSONTokenLoginAPI.Service
{
    public interface IUserService
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        // List of user
        private List<User> _users = new List<User>
        {
            new User{
                Id = 1,
                FirstName = "mytest",
                LastName  = "user",
                Username  = "mytestuser",
                Password  = "test123"
            },
            new User
            {
                Id = 2,
                FirstName = "mytest2",
                LastName= "user2",
                Username = "test",
                Password = "test"
            }
        };
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
