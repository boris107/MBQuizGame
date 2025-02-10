using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int PlayerNumber { get; set; }
        [MaxLength(24)]
        [Column(TypeName = "VARCHAR(24)")]
        public string PlayerName { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User CurrentUser { get; set; }
        public int SessionId { get; set; }
        public Session GameSession { get; set; }
    }
}