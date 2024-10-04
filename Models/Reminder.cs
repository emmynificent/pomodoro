namespace Pomodoro.Models;
public class Reminder
{
    public int Id {get; set;}
    public int assignmentId {get; set;}
    public Assignment assignment {get; set;}
    public DateTime reminder_time{get; set;}
    public bool Notification {get; set;} = false;

}