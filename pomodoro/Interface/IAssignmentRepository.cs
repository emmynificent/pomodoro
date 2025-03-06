using Pomodoro.Dto;
using Pomodoro.Models;

namespace Pomodoro.Interface;
public interface IAssignmentRepository
{
    
    Task<ICollection<Assignment>> GetAssignmentsAsync();
    Task<Assignment> GetAssignmentAsync (int AssignmentId);
    Task<Assignment> CreateAssignmentAsync (Assignment assignment);
    bool AssignmentExist (int AssignmentId);
    Task<Assignment> DeleteAssignment (Assignment assignment);
    Task<bool> UpdateAssignment (Assignment assignment);
   // ICollection<Reminder> GetRemindersByAssignmentId(int AsssignmentId); 
    // this is to get the reminders associated with this assignment.
    Task<ICollection<Assignment>> GetAssignmentByUserId(string userId);
    Task<ICollection<Assignment>> GetAssignmentsByUserEmailAsync(string userEmail);
    bool Save();
}   