namespace Pomodoro.Models;
public class Notification
{
    public int Id {get; set;}
    public string? NotificationName {get; set;}
    public string? NotificationSound {get; set;}
    public ICollection<Reminder> Reminders {get; set;} 

}
