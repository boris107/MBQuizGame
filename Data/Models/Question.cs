namespace Data.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public int SessionId { get; set; }
        public int PlayerId { get; set; }
        public int CorrectAnswerId { get; set; }
    }
}