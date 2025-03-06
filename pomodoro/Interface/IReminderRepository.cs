using Pomodoro.Models;

namespace Pomodoro.Interface;
public interface IReminderRepository
{
    ICollection<Reminder> GetReminders();
    Reminder GetReminder(int Id);
    bool CreateReminder(Reminder reminder);
    bool UpdateReminder (Reminder reminder);
    bool DeleteReminder(Reminder reminder);
    bool ReminderExist(int Id);
    bool Save();

}