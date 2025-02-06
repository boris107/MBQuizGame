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
        [ForeignKey(nameof(SessionId))]
        public Session GameSession { get; set; }

        public int? CorrectAnswerId { get; set; }
        [ForeignKey(nameof(CorrectAnswerId))]
        public Answer? CorrectAnswer { get; set; }

        public int? PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public Player? AskedQuestionPlayer { get; set; }
    }
}