using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Models;

public class Assignment
{
    public int Id {get; set;}
    public string? AssignmentTitle {get; set;}
    public string? AssignmentDescription{get; set;}
    public DateTime AssignmentCreated {get; set;} = DateTime.Now;
    public DateTime DueDate{get; set;}
    //public DateTime ReminderTime {get; set;}
    public Priority priority {get; set;}
    public bool SetReminder {get; set;} = false;
    public ICollection<Reminder>? Reminders {get; set;}
    public string UserId {get; set;}
    public User Owner {get; set;} 
}

public enum Priority
{
    low,
    medium,
    high
}
