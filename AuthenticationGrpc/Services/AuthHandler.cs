using AuthenticationGrpc.Db;
using AuthenticationGrpc.Model;

namespace AuthenticationGrpc.Services
{
    public class AuthHandler
    {
        private UserDbContext userContext;
        public AuthHandler()
        {
            this.userContext = new UserDbContext(); 
        }

        public User? findUser(string username)
        {
            return userContext.users?.Where(user=>user.UserName == username).FirstOrDefault();
        }

        public void createUser(string username,string password)
        {
            User user = new User
            {
                Id = new Guid(),
                UserName = username,
                Password = password
            };
            userContext.users?.Add(user);
            userContext.SaveChangesAsync();
        }

        public bool verifyUser(string username,string password)
        {
            var user = findUser(username);
            if (user!=null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false ;
        }

    }
}
