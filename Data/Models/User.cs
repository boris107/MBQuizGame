using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User
    {        
        public int UserId { get; set; }
        [MaxLength(24)]
        [Column(TypeName = "VARCHAR(24)")]
        public string UserName { get; set; } = string.Empty;
        public string? Password { get; set; }
        public UserPrivelege Privilege { get; set; }        
    }
    public enum UserPrivelege
    {
        Guest,
        User,
        Admin
    }
}