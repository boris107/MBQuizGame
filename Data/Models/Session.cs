namespace Data.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string Status { get; set; }
        public enum SessionStatus
        {
            Waiting,
            Active,
            Ended
        }
    }
}