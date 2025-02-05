using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.Models
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        const int MaxLengthSessionName = 100;
        public void Configure(EntityTypeBuilder<Session> builder)
        {                        
            // Ограничение на название сессии
            builder.Property(s => s.SessionName)
                   .HasColumnType($"VARCHAR({MaxLengthSessionName})")
                   .HasMaxLength(MaxLengthSessionName);

            // Enum хранится как int
            builder.Property(s => s.Status)
                   .HasConversion<int>();

            // Дата создания с дефолтным значением UTC
            builder.Property(s => s.DateTimeCreated)
                   .HasDefaultValueSql("NOW()")
                   .HasPrecision(0);

            // Один игрок создаёт сессию
            builder.HasOne(s => s.CreateSessionPlayer)
                   .WithOne() // Игрок мощет создать только одну сессию
                   .HasForeignKey<Session>(s => s.CreatePlayerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Один игрок может быть победителем
            builder.HasOne(s => s.WonPlayer)
                   .WithOne() // Игрок может победить только в одной сессии
                   .HasForeignKey<Session>(s => s.WonPlayerId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Один Session содержит много игроков
            builder.HasMany(s => s.Players)
                   .WithOne(p => p.GameSession) // У игрока есть связь с сессией
                   .HasForeignKey(p => p.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Один Session содержит множество историй
            builder.HasMany(s => s.AnswerHistories)
                   .WithOne(ah => ah.GameSession) // У AnswerHistory есть связь с сессией
                   .HasForeignKey(ah => ah.SessionId) 
                   .OnDelete(DeleteBehavior.Cascade);

            // Устанавливаем индекс для улучшения производительности запросов
            builder.HasIndex(s => new { s.CreatePlayerId, s.WonPlayerId});
        }
    }
}
