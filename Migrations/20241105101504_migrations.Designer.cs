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
    [Migration("20241105101504_migrations")]
    partial class migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

                    b.Property<string>("AssignmentOwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssignmentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SetReminder")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentOwnerId");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentCreated = new DateTime(2024, 11, 5, 11, 15, 2, 217, DateTimeKind.Local).AddTicks(4097),
                            AssignmentDescription = "",
                            AssignmentTitle = "Chemistry",
                            DueDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SetReminder = false,
                            UserId = "1",
                            priority = 1
                        },
                        new
                        {
                            Id = 2,
                            AssignmentCreated = new DateTime(2024, 11, 5, 11, 15, 2, 217, DateTimeKind.Local).AddTicks(4193),
                            AssignmentDescription = "",
                            AssignmentTitle = "Physics",
                            DueDate = new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SetReminder = false,
                            UserId = "1",
                            priority = 1
                        },
                        new
                        {
                            Id = 3,
                            AssignmentCreated = new DateTime(2024, 11, 5, 11, 15, 2, 217, DateTimeKind.Local).AddTicks(4196),
                            AssignmentDescription = "",
                            AssignmentTitle = "Go",
                            DueDate = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SetReminder = false,
                            UserId = "1",
                            priority = 1
                        });
                });

            modelBuilder.Entity("Pomodoro.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NotificationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationSound")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NotificationName = "HighReminders",
                            NotificationSound = "high.mp3"
                        },
                        new
                        {
                            Id = 2,
                            NotificationName = "Ringer",
                            NotificationSound = "bloodonme.mp3"
                        },
                        new
                        {
                            Id = 3,
                            NotificationName = "Raise Up!",
                            NotificationSound = "up.mp3"
                        });
                });

            modelBuilder.Entity("Pomodoro.Models.Owner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d2613830-fced-41c9-84bc-aa2d2686a8dd",
                            Email = "testuser@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Sam",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedUserName = "Username",
                            PasswordHash = "AQAAAAIAAYagAAAAEG0a6hedZclUdNfr68dEEbGYrvOP3Gj8HDjAtJNBcOwG7KfAUoxEK0y61qGxTEnSag==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0732192c-7ef9-4e90-8bb2-8f4b3b3491c3",
                            TwoFactorEnabled = false,
                            UserName = "test@gmail.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "db09c90a-4879-4aa6-a3ad-eb717aa8f1fa",
                            Email = "checkBoy@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Check",
                            LastName = "Sam",
                            LockoutEnabled = false,
                            NormalizedUserName = "CheckBoy",
                            PasswordHash = "AQAAAAIAAYagAAAAEFT6hZwKF60CuM8yzCLaTQhN1EmXLBVGgBe3cjo8sVHI/GCfz9nrWm4Fb6RVhwhT9Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9d1c8c72-3a9b-4440-8079-9a3689587971",
                            TwoFactorEnabled = false,
                            UserName = "checkBoy"
                        });
                });

            modelBuilder.Entity("Pomodoro.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsNotificationSet")
                        .HasColumnType("bit");

                    b.Property<int?>("NotificationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReminderTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("NotificationId");

                    b.ToTable("Reminders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentId = 1,
                            IsNotificationSet = false,
                            ReminderTime = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AssignmentId = 3,
                            IsNotificationSet = true,
                            NotificationId = 1,
                            ReminderTime = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            AssignmentId = 3,
                            IsNotificationSet = true,
                            NotificationId = 2,
                            ReminderTime = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Pomodoro.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pomodoro.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pomodoro.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pomodoro.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pomodoro.Models.Assignment", b =>
                {
                    b.HasOne("Pomodoro.Models.Owner", "AssignmentOwner")
                        .WithMany("Assignments")
                        .HasForeignKey("AssignmentOwnerId");

                    b.Navigation("AssignmentOwner");
                });

            modelBuilder.Entity("Pomodoro.Models.Reminder", b =>
                {
                    b.HasOne("Pomodoro.Models.Assignment", "Assignment")
                        .WithMany("Reminders")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pomodoro.Models.Notification", "Notification")
                        .WithMany("Reminders")
                        .HasForeignKey("NotificationId");

                    b.Navigation("Assignment");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("Pomodoro.Models.Assignment", b =>
                {
                    b.Navigation("Reminders");
                });

            modelBuilder.Entity("Pomodoro.Models.Notification", b =>
                {
                    b.Navigation("Reminders");
                });

            modelBuilder.Entity("Pomodoro.Models.Owner", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}