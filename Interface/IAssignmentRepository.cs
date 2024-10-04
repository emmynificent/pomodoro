using Pomodoro.Models;

namespace Pomodoro.Interface;
public interface IAssignmentRespository
{
    ICollection<Assignment> GetAssignments();
    Assignment GetAssignment (int Id);
    bool CreateAssignment (Assignment assignment);
    bool AssignmentExist (int Id);
    bool DeleteAssignment (Assignment assignment);
    bool UpdateAssignment (Assignment assignment);
    ICollection<Reminder> GetRemindersByAssignmentId(int Id); // this is to get the reminders associated with this assignment.
    bool Save();

}