using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [MaxLength(1000)]
        [Column(TypeName = "VARCHAR(1000)")]
        public string QuestionName { get; set; }
        public int SessionId { get; set; }
        public int PlayerId { get; set; }
        public int CorrectAnswerId { get; set; }
        public Session GameSession { get; set; }
        public Answer? CorrectAnswer { get; set; }
        public Player? AskedQuestionPlayer { get; set; }
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}