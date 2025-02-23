﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Models;

namespace Data.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        const int MaxLengthAnswerText = 1000;
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.AnswerText)
           .HasMaxLength(MaxLengthAnswerText)
           .HasColumnType($"VARCHAR({MaxLengthAnswerText})");

            builder.HasOne(a => a.CurrentQuestion)
                   .WithMany(q => q.Answers)  // Один вопрос может иметь много ответов
                   .HasForeignKey(a => a.QuestionId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            // Устанавливаем индекс для улучшения производительности запросов
            builder.HasIndex(ah => new { ah.QuestionId});
        }
    }
}
