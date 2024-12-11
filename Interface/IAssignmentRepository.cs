using Pomodoro.Dto;
using Pomodoro.Models;

namespace Pomodoro.Interface;
public interface IAssignmentRepository
{
    ICollection<Assignment> GetAssignments();
    Assignment GetAssignment (int AssignmentId);
    bool CreateAssignment (Assignment assignment);
    bool AssignmentExist (int AssignmentId);
    bool DeleteAssignment (Assignment assignment);
    bool UpdateAssignment (Assignment assignment);
    ICollection<Reminder> GetRemindersByAssignmentId(int AsssignmentId); 
    // this is to get the reminders associated with this assignment.
    ICollection<Assignment> GetAssignmentByUserId(string userId);
    bool Save();

}   
