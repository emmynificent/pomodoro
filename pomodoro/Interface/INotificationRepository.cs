using Pomodoro.Models;

namespace Pomodoro.Interface;
public interface INotificationRepository
{
    ICollection<Notification> GetNotifications();
    Notification GetNotification(int NotificationId);
    bool CreateNotification (Notification notification);
    bool NotificationExist (int NotificationId);
    bool DeleteNotification (Notification notification);
    bool UpdateNotification (Notification notification);
    ICollection<Reminder> GetReminderByNotification(int NotificationId);
    bool Save();
}