using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int PlayerNumber { get; set; }
        [Column(TypeName = "LONGTEXT(24)")]
        public string PlayerName { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("SessionId")]
        public int SessionId { get; set; }
        public Session? Session { get; set; }
    }
}