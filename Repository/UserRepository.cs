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

    public async Task<User>  CreateUserAsync(User user)
    {

        try{
            await _assignmentDbContext.Users.AddAsync(user);
            await _assignmentDbContext.SaveChangesAsync();
            return user;
        }
        catch{
            return null;
        }
    }

    public bool DeleteUser(User user)
    {
        _assignmentDbContext.Remove(user);
        return Save();
    }

    public async Task<User> GetUserbyEmailAsync(string email)
    {
        
        var user = await _assignmentDbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

        return user;
    }

    public async Task<User> GetUserbyIdAsync(string userId)
    {
        
        var user = await _assignmentDbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

        return user;
    }
    public async Task<ICollection<UserDto>> GetUsersAsync()
    {
        var users = await _assignmentDbContext.Users.ToListAsync();
        var userMap = _mapper.Map<List<UserDto>>(users);
        return userMap;
    }

    // public async Task<User> UserExistAsync(string UserId)
    // {
    //     return await _assignmentDbContext.Users.Any(u => u.Id == UserId).ToListAsync();
    // }
    public async Task<User> UserExist(string email){
         var exist = await _assignmentDbContext.Users.FirstOrDefaultAsync(u=>u.Email == email);
         return exist;
        
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
    public async Task<ICollection<AssignmentDto>> GetAssignmentsAsync(string userId)
    {
        var assignments = await _assignmentDbContext.Assignments
        .Include(a => a.Owner)
        .Where(a=> a.UserId == userId).ToListAsync();

        var assignmentDto = _mapper.Map<List<AssignmentDto>>(assignments);
        return assignmentDto;
    }

    public async Task<ICollection<AssignmentDto>> GetAssignmentByUserEmailAsync(string userMail)
    {
       var assignments =  await _assignmentDbContext.Assignments
        .Include(a=> a.Owner)
        .Where(a=> a.Owner.UserName == userMail).ToListAsync();

        var assignmentbyEmailDto = _mapper.Map<List<AssignmentDto>>(assignments);
        return assignmentbyEmailDto;
    }
}