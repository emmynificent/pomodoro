using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Models;

namespace Pomodoro.Data;
public class AssignmentDbContext : IdentityDbContext<User>
{
    public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options)
    {

    }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    //public DbSet<User> users {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        var hasher = new PasswordHasher<User>();

        var user1 = new User
        {
            Id = "1",
            UserName = "test@gmail.com",
            NormalizedUserName = "Username",
            Email = "testuser@gmail.com",
            FirstName = "Sam",
            LastName = "Doe",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Passcode123!")

        };
        var user2 = new User
        {
            Id = "2",
            UserName = "checkBoy",
            NormalizedUserName = "CheckBoy",
            Email = "checkBoy@gmail.com",
            FirstName = "Check",
            LastName = "Sam",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Password@220")

        };
        modelBuilder.Entity<User>().HasData(user1, user2);

        modelBuilder.Entity<Reminder>()
        .HasOne(r => r.Assignment)
        .WithMany(a => a.Reminders)
        .HasForeignKey(r => r.AssignmentId)
        .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Assignment>().HasData(
            new Assignment()
            {
                Id = 1,
                AssignmentTitle = "Chemistry",
                AssignmentDescription = "",
                DueDate = new DateTime(2024, 01, 01),
                priority = Priority.medium,
                UserId = "1",
            },
            new Assignment()
            {
                Id = 2,
                AssignmentTitle = "Physics",
                AssignmentDescription = "",
                DueDate = new DateTime(2024, 01, 21),
                priority = Priority.medium,
                UserId = "1",
            },
            new Assignment()
            {
                Id = 3,
                AssignmentTitle = "Go",
                AssignmentDescription = "",
                DueDate = new DateTime(2024, 05, 01),
                priority = Priority.medium,
                UserId = "1",
            }
        );
        modelBuilder.Entity<Reminder>().HasData(
            new Reminder()
            {
                Id = 1,
                AssignmentId = 1,
                ReminderTime = new DateTime(2024, 04, 12),
                IsNotificationSet = false,
            },
            new Reminder()
            {
                Id = 2,
                AssignmentId = 3,
                ReminderTime = new DateTime(2024, 04, 12),
                IsNotificationSet = true,
                NotificationId = 1

            },
            new Reminder()
            {
                Id = 4,
                AssignmentId = 3,
                ReminderTime = new DateTime(2024, 04, 12),
                IsNotificationSet = true,
                NotificationId = 2
            }
        );
        modelBuilder.Entity<Notification>().HasData(
            new Notification()
            {
                Id = 1,
                NotificationName = "HighReminders",
                NotificationSound = "high.mp3"

            },
            new Notification()
            {
                Id = 2,
                NotificationName = "Ringer",
                NotificationSound = "bloodonme.mp3"
            },
            new Notification()
            {
                Id = 3,
                NotificationName = "Raise Up!",
                NotificationSound = "up.mp3"
            }
        );
    }
}