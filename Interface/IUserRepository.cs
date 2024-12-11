using Pomodoro.Dto;
using Pomodoro.Models;

namespace Pomodoro.Interface;
public interface IUserRepository
{
    ICollection<UserDto> GetUsers();
    User GetUser(string UserId);
    bool CreateUser(User user);
    bool DeleteUser(User user);
    bool UpdateUser(User user);
    bool UserExist(string UserId);
    bool Save();
    ICollection<AssignmentDto> GetAssignments (string userId);

}