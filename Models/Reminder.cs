namespace Pomodoro.Models;
public class Reminder
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    public DateTime ReminderTime { get; set; }
    public bool IsNotificationSet { get; set; } = false;
    public Notification? Notification { get; set; }
    public int? NotificationId { get; set; }

}