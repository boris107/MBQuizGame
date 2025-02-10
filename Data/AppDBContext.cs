using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Configurations;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<AnswerHistory> AnswerHistories { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }             
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());            
            modelBuilder.ApplyConfiguration(new SessionConfiguration());            
            modelBuilder.ApplyConfiguration(new AnswerHistoryConfiguration());            
        }
    }
}
