using Microsoft.EntityFrameworkCore;
using Pomodoro.Models;

namespace Pomodoro.Data;
public class AssignmentDbContext: DbContext
{
    public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options)
    {
        
    }
    public DbSet<Assignment> Assignments{get; set;}
    public DbSet<Reminder> Reminders {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>().HasData(

            new Assignment(){
                Id = 1,
                AssignmentTitle = "Chemistry",
                AssignmentDescription = "",
                DueDate = new DateTime(2024, 01, 01),
                priority = Priority.medium
            },
            new Assignment(){
                Id = 2,
                AssignmentTitle = "Physics",
                AssignmentDescription = "",
                DueDate = new DateTime(2024,01, 21),
                priority = Priority.medium
            },
            new Assignment(){
                Id = 3,
                AssignmentTitle = "Go",
                AssignmentDescription = "",
                DueDate = new DateTime(2024,05,01),
                priority = Priority.medium
            }
        );
        modelBuilder.Entity<Reminder>().HasData(
            new Reminder(){
                Id = 1,
                assignmentId = 1,
                reminder_time  = new DateTime(2024, 04, 12),
                Notification = false
            },
            new Reminder(){
                Id = 2,
                assignmentId = 3,
                reminder_time  = new DateTime(2024,04, 12),
                Notification = true,
            }


        );

            
    }
}