﻿using AmourLink.Recommendation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmourLink.Recommendation.Data.Context.EntityConfiguration;

public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PRIMARY");

        builder.ToTable("picture");
        
        builder.Property(e => e.Id)
            .HasColumnName("picture_id")
            .HasColumnType("binary(16)");
        builder.Property(e => e.TimeAdded)
            .HasColumnType("datetime(6)");
        builder.Property(e => e.PictureUrl)
            .HasMaxLength(255);
        builder.Property(e => e.UserDetailsId)
            .HasColumnType("binary(16)");

        builder.HasOne(d => d.UserDetails)
            .WithMany(p => p.Pictures)
            .HasForeignKey(d => d.UserDetailsId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_picture_user_details1");
    }
}