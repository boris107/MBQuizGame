namespace Data.Models
{
    public class AnswerHistory
    {        
        public int AnswerHistoryId { get; set; }
        public int SessionId { get; set; }
        public int PlayerId { get; set; }
        public int QuetionId { get; set; }
        public int AnswerId { get; set; }
        public DateTime DateTimeAnswered { get; set; }
    }
}
