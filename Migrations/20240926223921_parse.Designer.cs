﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pomodoro.Data;

#nullable disable

namespace pomodoro.Migrations
{
    [DbContext(typeof(AssignmentDbContext))]
    [Migration("20240926223921_parse")]
    partial class parse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pomodoro.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AssignmentCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("AssignmentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentCreated = new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9456),
                            AssignmentDescription = "",
                            AssignmentTitle = "Chemistry",
                            DueDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            priority = 1
                        },
                        new
                        {
                            Id = 2,
                            AssignmentCreated = new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9479),
                            AssignmentDescription = "",
                            AssignmentTitle = "Physics",
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022),
                            priority = 1
                        },
                        new
                        {
                            Id = 3,
                            AssignmentCreated = new DateTime(2024, 9, 26, 23, 39, 20, 749, DateTimeKind.Local).AddTicks(9487),
                            AssignmentDescription = "",
                            AssignmentTitle = "Go",
                            DueDate = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            priority = 1
                        });
                });

            modelBuilder.Entity("Pomodoro.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Notification")
                        .HasColumnType("bit");

                    b.Property<int>("assignmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("reminder_time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("assignmentId");

                    b.ToTable("Reminder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Notification = false,
                            assignmentId = 1,
                            reminder_time = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Notification = true,
                            assignmentId = 3,
                            reminder_time = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Pomodoro.Models.Reminder", b =>
                {
                    b.HasOne("Pomodoro.Models.Assignment", "assignment")
                        .WithMany()
                        .HasForeignKey("assignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("assignment");
                });
#pragma warning restore 612, 618
        }
    }
}