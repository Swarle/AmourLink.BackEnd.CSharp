﻿using AmourLink.Recommendation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmourLink.Recommendation.Data.Context.EntityConfiguration;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PRIMARY");
        
        builder.ToTable("language");
        
        builder.Property(e => e.Id)
            .HasColumnName("language_id");
        builder.Property(e => e.LanguageName)
            .HasMaxLength(45);

        builder.HasMany(d => d.UserDetails)
            .WithMany(p => p.Languages)
            .UsingEntity("user_details_language",
                l => l.HasOne(typeof(UserDetails))
                    .WithMany()
                    .HasForeignKey("user_id"),
                r => r.HasOne(typeof(Language))
                    .WithMany()
                    .HasForeignKey("language_id"));
    }
}