﻿using AmourLink.Recommendation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmourLink.Recommendation.Data.Context.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PRIMARY");

        builder.ToTable("user");
        
        builder.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

        builder.Property(e => e.Id)
            .HasColumnName("user_id")
            .HasColumnType("binary(16)");
        builder.Property(e => e.CreatedTime)
            .HasColumnType("timestamp");
        builder.Property(e => e.Email)
            .HasMaxLength(45);
        builder.Property(typeof(string), "password")
            .HasMaxLength(255)
            .IsRequired();
    }
}