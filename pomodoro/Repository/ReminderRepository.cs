using Pomodoro.Data;
using Pomodoro.Interface;
using Pomodoro.Models;

namespace Pomodoro.Repository;
public class ReminderRepository : IReminderRepository
{
    private readonly AssignmentDbContext _assignmentDbContext;

    public ReminderRepository(AssignmentDbContext context)
    {
        _assignmentDbContext = context;
    }

    public bool CreateReminder(Reminder reminder)
    {
        _assignmentDbContext.Reminders.Add(reminder);
        return Save();
    }
    public bool DeleteReminder(Reminder reminder)
    {
        _assignmentDbContext.Remove(reminder);
        return Save();
    }

    public Reminder GetReminder(int Id)
    {
        var reminder = _assignmentDbContext.Reminders.Where(r=> r.Id == Id).FirstOrDefault();
        return reminder;
    }

    public ICollection<Reminder> GetReminders()
    {
        return _assignmentDbContext.Reminders.ToList();
        
    }

    public bool ReminderExist(int Id)
    {
        return _assignmentDbContext.Reminders.Any(r=>r.Id == Id);
    }

    public bool Save()
    {
        var saved = _assignmentDbContext.SaveChanges();
            return saved > 0 ? true : false;
    }

    public bool UpdateReminder(Reminder reminder)
    {
        _assignmentDbContext.Reminders.Update(reminder);
        return Save();
    }
}