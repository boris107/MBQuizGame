using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class AppDbContext : DbContext
    {
        const string _connString = "Server=localhost;user=root;password=Omega42;database=testMQQuizGame";
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<AnswerHistory> AnswerHistories { get; set; } = null!;
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connString, new MySqlServerVersion(new Version(5, 7, 22, 0)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerHistoryConfiguration());            
            modelBuilder.ApplyConfiguration(new AnswerHistoryConfiguration());            
        }
    }
}
