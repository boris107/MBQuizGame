using System.Data.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string? SessionName { get; set; }
        public SessionStatus Status { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeStarted { get; set; }
        public DateTime? DateTimeEnded { get; set; }
        public int? CreatePlayerId { get; set; }
        public Player? CreateSessionPlayer { get; set; }
        public int? WonPlayerId { get; set; }        
        public ICollection<AnswerHistory> AnswerHistories { get; set; } = new HashSet<AnswerHistory>();
    }

    public enum SessionStatus
    {
        Waiting,
        Active,
        Ended
    }
}