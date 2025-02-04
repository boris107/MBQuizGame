using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class AnswerHistory
    {        
        public int AnswerHistoryId { get; set; }
        public int SessionId { get; set; }
        public int PlayerId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public DateTime DateTimeAnswered { get; set; } = DateTime.Now;
        [Required]
        [ForeignKey(nameof(SessionId))]
        public Session GameSession { get; set; }
        public Player? Player { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

    }
}
