using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Models;

namespace Data.Configurations
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

            // Один Session содержит множество историй
            builder.HasMany(s => s.AnswerHistories)
                   .WithOne(ah => ah.GameSession) // У AnswerHistory есть связь с сессией
                   .HasForeignKey(ah => ah.SessionId) 
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
