using Pomodoro.Interface;
using Pomodoro.Data;
using Pomodoro.Models;

namespace Pomodoro.Repository;
public class AssignmentRepository : IAssignmentRespository
{
    private readonly AssignmentDbContext _assignmentDbContext;

    public AssignmentRepository(AssignmentDbContext context)
    {
        _assignmentDbContext = context;
    }


    public bool AssignmentExist(int id)
    {
        return _assignmentDbContext.Assignments.Any(a=> a.Id == id);
    }

    public bool CreateAssignment(Assignment assignment)
    {
        _assignmentDbContext.Assignments.Add(assignment);
        return Save();

    }

    public bool DeleteAssignment(Assignment assignment)
    {
        _assignmentDbContext.Remove(assignment);
        return Save();
    }

    public Assignment GetAssignment(int Id)
    {
        var assignment =  _assignmentDbContext.Assignments.Where(a=> a.Id ==Id).FirstOrDefault();
        return assignment;
    }

    public ICollection<Assignment> GetAssignments()
    {
        return _assignmentDbContext.Assignments.ToList();
    }

    public ICollection<Reminder> GetRemindersByAssignmentId(int assignmentId)
    {
        //var reminder = _assignmentDbContext.Reminders.Where(a => a.Id == Id).FirstOrDefault();
        //return _assignmentDbContext.Reminders.Where(r=> r.Id == Id).Select(r=> r.assignment).FirstOrDefault();
        var reminders = _assignmentDbContext.Assignments.Where(a=> a.Id == assignmentId).Select(a => a.Reminders).FirstOrDefault();
        return reminders;
        
        //return reminders
    }

    public bool Save()
    {
        var saved = _assignmentDbContext.SaveChanges();
            return saved > 0 ? true : false;
    }

    public bool UpdateAssignment(Assignment assignment)
    {
        _assignmentDbContext.Assignments.Update(assignment);
        return Save();

    }
}