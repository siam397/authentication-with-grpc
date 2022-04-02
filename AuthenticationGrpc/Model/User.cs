using System.ComponentModel.DataAnnotations;

namespace AuthenticationGrpc.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? UserName { get; set; }    
        public string? Password { get; set; }
    }
}
