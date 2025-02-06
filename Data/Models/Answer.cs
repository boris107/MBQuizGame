using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }        
        public string AnswerText { get; set; } = string.Empty;
        public int QuestionId { get; set; }        
        public Question CurrentQuestion { get; set; }
    }
}