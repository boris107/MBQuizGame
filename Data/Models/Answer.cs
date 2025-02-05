using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [MaxLength(1000)]
        [Column(TypeName = "VARCHAR(1000)")]
        public string AnswerText { get; set; } = string.Empty;
        public int QuestionId { get; set; }        
        public Question CurrentQuestion { get; set; }
    }
}