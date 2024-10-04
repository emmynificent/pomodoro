using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Pomodoro.Data;
using Pomodoro.Dto;
using Pomodoro.Interface;
using Pomodoro.Models;
using Pomodoro.Repository;

namespace Pomodoro.Controller;

[Route("api/[controller]")]
[ApiController]


public class AssignmentController: ControllerBase
{
    private readonly IAssignmentRespository _assignmentRepository;
    private readonly IMapper _mapper;

    public AssignmentController(IAssignmentRespository assignmentRespository, IMapper mapper)
    {
        _assignmentRepository = assignmentRespository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAssignments()
    {
        var assignments = _assignmentRepository.GetAssignments();
        return Ok(assignments);

    }

    [HttpGet("{assignmentId}")]

    public IActionResult GetAssignment(int assignmentId)
    {
        //var assignment = _assignmentRepository.GetAssignment(assignmentId);
        if(!_assignmentRepository.AssignmentExist(assignmentId))
        {
            return NotFound($"{assignmentId} not found");
        }        
       var assignment = _assignmentRepository.GetAssignment(assignmentId);
        return Ok(assignment);
        
    }
    [HttpPost]
    public IActionResult CreateAssignment([FromBody] AssignmentDto assignmentDto)
    {
        if(assignmentDto == null)
            return BadRequest();
        var assignments = _assignmentRepository.GetAssignments().Where(a=> a.AssignmentTitle.Trim()== assignmentDto.AssignmentTitle.Trim()).FirstOrDefault();
        
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var assignmentMap = _mapper.Map<Assignment>(assignmentDto);
        if(!_assignmentRepository.CreateAssignment(assignmentMap))
            return NotFound();
        return Ok();
    }

    [HttpPut ("{assignmentId}")]
    public IActionResult UpdateAssignment(int assignmentId, [FromBody] AssignmentDto updateAssignment)
    {
        // var search = _assignmentRepository.AssignmentExist(Id);
        if(updateAssignment == null)
            return BadRequest();
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        if(!_assignmentRepository.AssignmentExist(assignmentId))
            return NotFound("This ID does not exist");
        var assignmentMap = _mapper.Map<Assignment>(updateAssignment);
        if(!_assignmentRepository.UpdateAssignment(assignmentMap))
            return BadRequest("Something went wrong");
        return NoContent();
    }
    [HttpDelete("{assignmentId}")]
    public IActionResult DeleteAssignment(int assignmentId)
    {
        if(!_assignmentRepository.AssignmentExist(assignmentId))
            return BadRequest();
        var deleteassignment = _assignmentRepository.GetAssignment(assignmentId);

        _assignmentRepository.DeleteAssignment(deleteassignment);
        _assignmentRepository.Save();
        return Ok();
    }

    [HttpGet("reminderbyassignmentid{assignmentId}")]
    public IActionResult GetReminders(int assignmentId){

        if (assignmentId == null)
            return BadRequest();
        var reminders = _assignmentRepository.GetRemindersByAssignmentId(assignmentId);
        return Ok(reminders);
    }

    //reminders under one assignment

}
