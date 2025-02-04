﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
    public class AnswerHistoryConfiguration : IEntityTypeConfiguration<AnswerHistory>
    {
        public void Configure(EntityTypeBuilder<AnswerHistory> builder)
        {
            // Дата создания с дефолтным значением UTC
            builder.Property(ah => ah.DateTimeAnswered)
                   .HasDefaultValueSql("NOW()")
                   .HasPrecision(0);

            // Один игрок создает историю ответа
            builder.HasOne(ah => ah.Player)
                   .WithMany() // Игрок может создать множетсво историй
                   .HasForeignKey(ah => ah.PlayerId)
                   .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление для Player

            // Вопрос имеет истории ответов игроков
            builder.HasOne(ah => ah.Question)
                   .WithMany() // Множество записей могут быть на этот вопрос
                   .HasForeignKey(ah => ah.QuestionId)
                   .OnDelete(DeleteBehavior.SetNull); // Устанавливаем NULL при удалении Question

            // Ответ имеет истории ответов игроков
            builder.HasOne(ah => ah.Answer)
                   .WithMany() // Множество записей могут быть на ответ
                   .HasForeignKey(ah => ah.AnswerId)
                   .OnDelete(DeleteBehavior.SetNull); // Устанавливаем NULL при удалении Answer

            // Один Session содержит много ответов
            builder.HasOne(ah => ah.GameSession)
                   .WithMany(s => s.AnswerHistories) // У Session есть коллекция AnswerHistories
                   .HasForeignKey(ah => ah.SessionId)
                   .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление для Session

            // Устанавливаем индекс для улучшения производительности запросов
            builder.HasIndex(ah => new { ah.PlayerId, ah.QuestionId, ah.AnswerId, ah.SessionId });

        }
    }
}
