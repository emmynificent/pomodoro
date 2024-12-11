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
        var assignment =  _assignmentDbContext.Assignments
        .Include(a=>a.assignmentOwner)
        .Where(a=> a.Id ==Id).FirstOrDefault();
        return assignment;
    }

    public ICollection<Assignment> GetAssignmentByUserId(string userId)
    {
        var assignmentByUser =  _assignmentDbContext.Users
        .Where(u => u.Id == userId)
        .Select(a=> a.Assignments)
        .FirstOrDefault();

        return assignmentByUser;
    }

    public ICollection<Assignment> GetAssignments()
    {
        var assignment = _assignmentDbContext.Assignments
         .Include(a => a.assignmentOwner)
         .ToList();
        return assignment;
    }

    public ICollection<Reminder> GetRemindersByAssignmentId(int assignmentId)
    {
        //var reminder = _assignmentDbContext.Reminders.Where(a => a.Id == Id).FirstOrDefault();
        //return _assignmentDbContext.Reminders.Where(r=> r.Id == Id).Select(r=> r.assignment).FirstOrDefault();
        var reminders = _assignmentDbContext.Assignments.Where(a=> a.Id == assignmentId).Select(a => a.Reminders).FirstOrDefault();
        //var remindersMap = _mapper.Map<List<Reminder>>(reminders);
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
        _assignmentDbContext.Update(assignment);
        return Save();

    }

    
}