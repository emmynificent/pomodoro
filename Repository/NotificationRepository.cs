using Microsoft.AspNetCore.Authorization.Infrastructure;
using Pomodoro.Data;
using Pomodoro.Interface;
using Pomodoro.Models;

namespace Pomodoro.Repository;
public class NotificationRepository : INotificationRepository
{
    private readonly AssignmentDbContext _assignmentDbContext;
    public NotificationRepository(AssignmentDbContext assignmentDbContext)
    {
        _assignmentDbContext = assignmentDbContext;
    }

    public bool CreateNotification(Notification notification)
    {

        _assignmentDbContext.Notifications.Add(notification);
        return Save();
    }

    public bool DeleteNotification(Notification notification)
    {
        _assignmentDbContext.Remove(notification);
        return Save();
    }

    public Notification GetNotification(int NotificationId)
    {
        var notification = _assignmentDbContext.Notifications.Where(n=>n.Id == NotificationId).FirstOrDefault();
        return notification;

    }

    public ICollection<Notification> GetNotifications()
    {
        return _assignmentDbContext.Notifications.ToList();

    }

    public ICollection<Reminder> GetReminderByNotification(int NotificationId)
    {
        var reminder = _assignmentDbContext.Notifications.Where(r=> r.Id == NotificationId).Select(r => r.Reminders).FirstOrDefault();
        return reminder;
    }

    public bool NotificationExist(int Id)
    {
        return _assignmentDbContext.Notifications.Any(n=> n.Id == Id);
    }

    public bool Save()
    {
        var saved = _assignmentDbContext.SaveChanges();
        return saved >0? true : false;
    }

    public bool UpdateNotification(Notification notification)
    {
       _assignmentDbContext.Notifications.Update(notification);
        return Save();
    }
}
