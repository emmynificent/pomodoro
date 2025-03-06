using AutoMapper;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Dto;
using Pomodoro.Interface;
using Pomodoro.Models;

namespace Pomodoro.Controller;

[Route("api/[controller]")]
[ApiController]

public class ReminderController: ControllerBase
{
    private readonly IReminderRepository _reminderRepository;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;
    public ReminderController(IReminderRepository reminderRepository, IAssignmentRepository assignmentRespository, IMapper mapper)
    {
        _reminderRepository = reminderRepository;
        _mapper = mapper;
        _assignmentRepository = assignmentRespository;
    }
    
    [HttpGet]
    public IActionResult GetReminders()
    {
        var reminders = _reminderRepository.GetReminders();
        return Ok(reminders);
    }
    
    [HttpGet("reminder/{reminderId}")]
    public IActionResult GetReminder(int reminderId)
    {
        if(!_reminderRepository.ReminderExist(reminderId))
        {
            return NotFound();
        }
        else{
            var reminder = _reminderRepository.GetReminder(reminderId);
            return Ok(reminder);
        }
    }

    [HttpPost]
    public IActionResult CreateReminder( ReminderDto reminderDto)
    {
        //you cant create a reminder without an assignment.
        // var assignmentReminder = _assignmentRepository.GetAssignment(assignmentId);
        // if(assignmentReminder==null)
        //     return BadRequest();
        
        if (reminderDto == null)
            return BadRequest();
        if(!_assignmentRepository.AssignmentExist(reminderDto.assignmentId))
            return NotFound($"{reminderDto.assignmentId} does not exist, as a rminder would not exist without an assignment");

        if(!ModelState.IsValid)
        { 
            return BadRequest(ModelState);
        }
        var reminderMap = _mapper.Map<Reminder>(reminderDto);
        if(!_reminderRepository.CreateReminder(reminderMap))
            return NotFound();
        return Ok();
    }
    [HttpPut("{reminderId}")]
    public IActionResult UpdateReminder(int reminderId,[FromBody] ReminderDto updateReminder)
    {
        if(updateReminder == null)
        if(_reminderRepository.ReminderExist(reminderId))
            return NotFound();
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var reminderMap = _mapper.Map<Reminder>(updateReminder);
        if(!_reminderRepository.UpdateReminder(reminderMap))
            return BadRequest();
        return NoContent();

    }
    [HttpDelete("{reminderId}")]
    public IActionResult DeleteReminder(int reminderId)
    {
        if(reminderId == null)
            return BadRequest();
        var reminderToDelete = _reminderRepository.GetReminder(reminderId);
        _reminderRepository.DeleteReminder(reminderToDelete);
        return Ok("Done!");
    }
}