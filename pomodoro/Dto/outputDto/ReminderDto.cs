namespace Pomodoro.Dto;
public class ReminderDto
{
    public int Id {get; set;}
    public int assignmentId {get; set;}

    public DateTime reminder_time{get; set;}
    public bool Notification {get; set;} = false;
}