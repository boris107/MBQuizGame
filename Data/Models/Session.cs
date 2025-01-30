using System.Data.Common;
using System;

namespace Data.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string Status { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public DateTime DateTimeEnded { get; set; }
        public int CreatePlayerId { get; set; }
        public int WonPlayerId { get; set; }
        public enum SessionStatus
        {
            Waiting,
            Active,
            Ended
        }
    }
}