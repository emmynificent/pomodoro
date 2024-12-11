using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pomodoro.Data;
using Pomodoro.Interface;
using AutoMapper;
using Pomodoro.Models;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Dto;

namespace Pomodoro.Repository;
public class UserRepository : IUserRepository
{
    private readonly AssignmentDbContext _assignmentDbContext;
    private readonly IMapper _mapper;

    public UserRepository(AssignmentDbContext assignmentDbContext, IMapper mapper)
    {
        _assignmentDbContext = assignmentDbContext;
        _mapper = mapper;
    }

    public bool CreateUser(User user)
    {
        _assignmentDbContext.Users.Add(user);
        //var createMap = _mapper.Map<UserDto>();
        return Save();
    }

    public bool DeleteUser(User user)
    {
        _assignmentDbContext.Users.Remove(user);
        return Save();
    }

    public User GetUser(string  UserId)
    {
        
        var user = _assignmentDbContext.Users.Where(u => u.Id == UserId).FirstOrDefault();
        return user;
    }

    public ICollection<UserDto> GetUsers()
    {
        var users = _assignmentDbContext.Users.ToList();
        var userMap = _mapper.Map<List<UserDto>>(users);
        return userMap;
    }

    public bool UserExist(string UserId)
    {
        return _assignmentDbContext.Users.Any(u => u.Id == UserId);
        
    }

    public bool Save()
    {
        var saved = _assignmentDbContext.SaveChanges();
        return saved > 0? true : false;
    }

    public bool UpdateUser(User user)
    {
        _assignmentDbContext.Users.Update(user);
        return Save();
    }
    //Getting assignment by userId (assignments owner by the giving user Id)
    public ICollection<AssignmentDto> GetAssignments(string userId)
    {
        var assignments = _assignmentDbContext.Assignments
        .Include(a => a.assignmentOwner)
        .Where(a=> a.UserId == userId).ToList();

        var assignmentDto = _mapper.Map<List<AssignmentDto>>(assignments);
        return assignmentDto;
    }
}