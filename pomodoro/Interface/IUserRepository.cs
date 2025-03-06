using Pomodoro.Models;
using Pomodoro.Dto;

namespace Pomodoro.Interface;
public interface IUserRepository
{
    Task<ICollection<UserDto>> GetUsersAsync();
    //Task<User> GetUserAsync(string UserId);
    Task<User> CreateUserAsync(User user);

    Task<User> GetUserbyIdAsync(string userId);
    Task<User> GetUserbyEmailAsync(string email);
    bool DeleteUser(User user);
    bool UpdateUser(User user);
    Task<User> UserExist(string UserEmail);
    bool Save();
    Task<ICollection<AssignmentDto>> GetAssignmentsAsync (string userId);
    Task<ICollection<AssignmentDto>> GetAssignmentByUserEmailAsync(string userMail);
}