using Pomodoro.Interface;
using Pomodoro.Data;
using Pomodoro.Models;
using Pomodoro.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Pomodoro.Repository;
public class AssignmentRepository : IAssignmentRepository
{
    private readonly AssignmentDbContext _assignmentDbContext;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public AssignmentRepository(AssignmentDbContext context, IMapper mapper, IUserRepository userRepository)
    {
        _assignmentDbContext = context;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public bool AssignmentExist(int id)
    {
        return _assignmentDbContext.Assignments.Any(a=> a.Id == id);
    }

    public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
    {
        
        await _assignmentDbContext.AddAsync(assignment);
        await _assignmentDbContext.SaveChangesAsync();
        return assignment;

    }

    public async Task<Assignment> DeleteAssignment(Assignment assignment)
    {
        _assignmentDbContext.Remove(assignment);
        await _assignmentDbContext.SaveChangesAsync();

        return assignment;
    }

    public async Task<Assignment> GetAssignmentAsync(int Id)
    {
        var assignment = await _assignmentDbContext.Assignments
        .Include(a=>a.Owner)
        .Where(a=> a.Id ==Id).FirstOrDefaultAsync();
        return assignment;
    }

    public async Task<ICollection<Assignment>> GetAssignmentByUserId(string userId)
    {
        var assignmentByUser = await _assignmentDbContext.Users
        .Where(u => u.Id == userId)
        .Select(a=> a.Assignments)
        .FirstOrDefaultAsync();
        return assignmentByUser;
    }

    public async Task<ICollection<Assignment>> GetAssignmentsAsync()
    {
        var assignment = await _assignmentDbContext.Assignments
         .Include(a => a.Owner)
         .ToListAsync();

        return assignment;
    }

    public async Task<ICollection<Assignment>> GetAssignmentsByUserEmailAsync(string userMail)
    {
        var assignment = await _assignmentDbContext.Assignments
        .Include(a=>a.Owner)
        .Where(a=> a.Owner.Email == userMail).ToListAsync();

        return assignment;
    }

    // public ICollection<Reminder> GetRemindersByAssignmentId(int assignmentId)
    // {
    //     //var reminder = _assignmentDbContext.Reminders.Where(a => a.Id == Id).FirstOrDefault();
    //     //return _assignmentDbContext.Reminders.Where(r=> r.Id == Id).Select(r=> r.assignment).FirstOrDefault();
    //     var reminders = _assignmentDbContext.Assignments.Where(a=> a.Id == assignmentId).Select(a => a.Reminders).FirstOrDefault();
    //     //var remindersMap = _mapper.Map<List<Reminder>>(reminders);
    //     return reminders;
        
    //     //return reminders
    // }


    public bool Save()
    {
        var saved = _assignmentDbContext.SaveChanges();
            return saved > 0 ? true : false;
    }

    public async Task<bool> UpdateAssignment(Assignment assignment)
    {
        _assignmentDbContext.Update(assignment);
        await _assignmentDbContext.SaveChangesAsync();
        return Save();

        
    }

    
}