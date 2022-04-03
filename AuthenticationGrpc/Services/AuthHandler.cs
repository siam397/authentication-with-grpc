using AuthenticationGrpc.Db;
using AuthenticationGrpc.Model;
using System.Security.Cryptography;
using System.Text;

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
                Password = ComputeSha256Hash(password)
            };
            userContext.users?.Add(user);
            userContext.SaveChangesAsync();
        }

        public bool verifyUser(string username,string password)
        {
            var user = findUser(username);
            if (user!=null)
            {
                if (user.Password == ComputeSha256Hash(password))
                {
                    return true;
                }
            }
            return false ;
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString());
                }
                return builder.ToString();
            }
        }

    }
}
