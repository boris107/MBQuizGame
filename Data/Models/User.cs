using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User
    {        
        public int UserId { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string? Password { get; set; }
        public UserPrivelege Privilege { get; set; }
        public enum UserPrivelege
        {
            Guest,
            User,
            Admin
        }
    }
}