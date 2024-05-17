﻿// <auto-generated />
using System;
using AmourLink.Recommendation.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmourLink.Recommendation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240512170224_ChangedPreferenceEntity")]
    partial class ChangedPreferenceEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Degree", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("degree_id");

                    b.Property<string>("DegreeType")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("degree_type");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("school_name");

                    b.Property<DateTime>("StartYear")
                        .HasColumnType("datetime")
                        .HasColumnName("start_year");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("degree", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Hobbie", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("hobbie_id");

                    b.Property<string>("HobbieName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("hobbie_name");

                    b.Property<byte[]>("UserDetailsId")
                        .IsRequired()
                        .HasColumnType("binary(16)")
                        .HasColumnName("user_details_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("UserDetailsId")
                        .HasDatabaseName("ix_hobbie_user_details_id");

                    b.ToTable("hobbie", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Language", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("language_id");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("language_name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("language", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Music", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("music_id");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("artist_name");

                    b.Property<string>("SpotifyId")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22)")
                        .HasColumnName("spotify_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("music", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Picture", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("picture_id");

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("timestamp")
                        .HasColumnName("added_time");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("picture_url");

                    b.Property<byte[]>("UserDetailsId")
                        .IsRequired()
                        .HasColumnType("binary(16)")
                        .HasColumnName("user_details_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("UserDetailsId")
                        .HasDatabaseName("ix_picture_user_details_id");

                    b.ToTable("picture", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Preference", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("preference_id");

                    b.Property<float>("CompabilityPreference")
                        .HasColumnType("float")
                        .HasColumnName("compability_preference");

                    b.Property<decimal>("DistanceRange")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("distance_range");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("gender");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int")
                        .HasColumnName("max_age");

                    b.Property<int>("MinAge")
                        .HasColumnType("int")
                        .HasColumnName("min_age");

                    b.Property<byte[]>("UserId")
                        .IsRequired()
                        .HasColumnType("binary(16)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_preference_user_id");

                    b.ToTable("preference", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("email");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "email_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("ix_user_email");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.UserDetails", b =>
                {
                    b.Property<byte[]>("Id")
                        .HasColumnType("binary(16)")
                        .HasColumnName("user_id");

                    b.Property<uint>("Age")
                        .HasColumnType("int unsigned")
                        .HasColumnName("age");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext")
                        .HasColumnName("bio");

                    b.Property<byte[]>("DegreeId")
                        .HasColumnType("binary(16)")
                        .HasColumnName("degree_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("gender");

                    b.Property<int?>("Height")
                        .HasColumnType("int")
                        .HasColumnName("height");

                    b.Property<float?>("LastLocationLatitude")
                        .HasColumnType("float")
                        .HasColumnName("last_location_latitude");

                    b.Property<float?>("LastLocationLongitude")
                        .HasColumnType("float")
                        .HasColumnName("last_location_longitude");

                    b.Property<string>("LastName")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("last_name");

                    b.Property<byte[]>("MusicId")
                        .HasColumnType("binary(16)")
                        .HasColumnName("music_id");

                    b.Property<string>("Nationality")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nationality");

                    b.Property<string>("Occupation")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("occupation");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("DegreeId")
                        .HasDatabaseName("ix_user_details_degree_id");

                    b.HasIndex("MusicId")
                        .HasDatabaseName("ix_user_details_music_id");

                    b.ToTable("user_details", (string)null);
                });

            modelBuilder.Entity("language_user_details", b =>
                {
                    b.Property<byte[]>("language_id")
                        .HasColumnType("binary(16)")
                        .HasColumnName("language_id");

                    b.Property<byte[]>("user_details_id")
                        .HasColumnType("binary(16)")
                        .HasColumnName("user_details_id");

                    b.HasKey("language_id", "user_details_id")
                        .HasName("pk_language_user_details");

                    b.HasIndex("user_details_id")
                        .HasDatabaseName("ix_language_user_details_user_details_id");

                    b.ToTable("language_user_details", (string)null);
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Hobbie", b =>
                {
                    b.HasOne("AmourLink.Recommendation.Data.Entities.UserDetails", "UserDetails")
                        .WithMany("Hobbies")
                        .HasForeignKey("UserDetailsId")
                        .IsRequired()
                        .HasConstraintName("fk_user_account_hobbie_user_details1");

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Picture", b =>
                {
                    b.HasOne("AmourLink.Recommendation.Data.Entities.UserDetails", "UserDetails")
                        .WithMany("Pictures")
                        .HasForeignKey("UserDetailsId")
                        .IsRequired()
                        .HasConstraintName("fk_picture_user_details1");

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Preference", b =>
                {
                    b.HasOne("AmourLink.Recommendation.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_preference_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.UserDetails", b =>
                {
                    b.HasOne("AmourLink.Recommendation.Data.Entities.Degree", "Degree")
                        .WithMany("UserDetails")
                        .HasForeignKey("DegreeId")
                        .HasConstraintName("fk_user_details_degree1");

                    b.HasOne("AmourLink.Recommendation.Data.Entities.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("AmourLink.Recommendation.Data.Entities.UserDetails", "Id")
                        .IsRequired()
                        .HasConstraintName("fk_user_details_user_account1");

                    b.HasOne("AmourLink.Recommendation.Data.Entities.Music", "Music")
                        .WithMany("UserDetails")
                        .HasForeignKey("MusicId")
                        .HasConstraintName("fk_user_details_music1");

                    b.Navigation("Degree");

                    b.Navigation("Music");

                    b.Navigation("User");
                });

            modelBuilder.Entity("language_user_details", b =>
                {
                    b.HasOne("AmourLink.Recommendation.Data.Entities.Language", null)
                        .WithMany()
                        .HasForeignKey("language_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_language_has_user_details_language1");

                    b.HasOne("AmourLink.Recommendation.Data.Entities.UserDetails", null)
                        .WithMany()
                        .HasForeignKey("user_details_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_language_has_user_details_user_details1");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Degree", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.Music", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.User", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("AmourLink.Recommendation.Data.Entities.UserDetails", b =>
                {
                    b.Navigation("Hobbies");

                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
