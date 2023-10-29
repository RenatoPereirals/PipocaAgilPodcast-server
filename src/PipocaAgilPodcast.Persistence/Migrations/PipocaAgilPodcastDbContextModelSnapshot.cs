﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PipocaAgilPodcast.Persistence.Models;

#nullable disable

namespace PipocaAgilPodcast.Persistence.Migrations
{
    [DbContext(typeof(PipocaAgilPodcastDbContext))]
    partial class PipocaAgilPodcastDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PipocaAgilPodcast.Domain.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ActivityDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ActivityType")
                        .HasColumnType("integer");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActivityHistory");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.ActivityStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityLogId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalActivities")
                        .HasColumnType("integer");

                    b.Property<int>("TotalComments")
                        .HasColumnType("integer");

                    b.Property<int>("TotalLikes")
                        .HasColumnType("integer");

                    b.Property<int>("TotalShares")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActivityLogId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Statisticss");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InterestLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.UserActivityLog", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ActivityLogId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "ActivityLogId");

                    b.HasIndex("ActivityLogId");

                    b.ToTable("UsersActivitiesLogs");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.ActivityStatistics", b =>
                {
                    b.HasOne("PipocaAgilPodcast.Domain.ActivityLog", "UsersActivitiesLogs")
                        .WithMany()
                        .HasForeignKey("ActivityLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PipocaAgilPodcast.Domain.User", "User")
                        .WithOne("Statistics")
                        .HasForeignKey("PipocaAgilPodcast.Domain.ActivityStatistics", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UsersActivitiesLogs");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.Interest", b =>
                {
                    b.HasOne("PipocaAgilPodcast.Domain.User", "User")
                        .WithOne("Interests")
                        .HasForeignKey("PipocaAgilPodcast.Domain.Interest", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.UserActivityLog", b =>
                {
                    b.HasOne("PipocaAgilPodcast.Domain.ActivityLog", "UsersActivitiesLogs")
                        .WithMany("UsersActivitiesLogs")
                        .HasForeignKey("ActivityLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PipocaAgilPodcast.Domain.User", "Users")
                        .WithMany("UsersActivitiesLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");

                    b.Navigation("UsersActivitiesLogs");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.ActivityLog", b =>
                {
                    b.Navigation("UsersActivitiesLogs");
                });

            modelBuilder.Entity("PipocaAgilPodcast.Domain.User", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Statistics");

                    b.Navigation("UsersActivitiesLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
