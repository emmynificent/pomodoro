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
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public AssignmentController(IAssignmentRepository assignmentRespository, IMapper mapper, IUserRepository userRepository)
    {
        _assignmentRepository = assignmentRespository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetAssignments()
    {
        var assignments =_assignmentRepository.GetAssignments();
        var assignmentMaps = _mapper.Map<List<AssignmentOutputDto>>(assignments);
        return Ok(assignmentMaps);
        //return Ok(assignmentMaps);

    }

    [HttpGet("{assignmentId}")]
    [ProducesResponseType(200, Type = typeof(Assignment))]
    [ProducesResponseType(404)]

    public IActionResult GetAssignment(int assignmentId)
    {
        //var assignment = _assignmentRepository.GetAssignment(assignmentId);
        if(!_assignmentRepository.AssignmentExist(assignmentId))
        {
            return NotFound($"{assignmentId} not found");
        }        
       var assignment = _mapper.Map<AssignmentDto>(_assignmentRepository.GetAssignment(assignmentId));
       if(!ModelState.IsValid)
       {
            return BadRequest(ModelState);

       }
        return Ok(assignment);
        
    }


    [HttpPost]

    // there should be a check to see if the the userId even exist before the assignment is created.
    public IActionResult CreateAssignment([FromBody] AssignmentDto assignment)
    {
        if(assignment == null)
            return BadRequest();
        var assignments = _assignmentRepository.GetAssignments().Where(a=> a.AssignmentTitle.Trim()== assignment.AssignmentTitle.Trim()).FirstOrDefault();
        
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var assignmentMap = _mapper.Map<Assignment>(assignment);
        if(!_assignmentRepository.CreateAssignment(assignmentMap))
            return NotFound();
        return Ok();
    }


    [HttpPut ("{assignmentId}")]
    public IActionResult UpdateAssignment(int assignmentId, [FromBody] AssignmentInputDto updateAssignment)
    {
        // var search = _assignmentRepository.AssignmentExist(Id);
        if(updateAssignment == null)
            return BadRequest();
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_assignmentRepository.AssignmentExist(assignmentId))
            return NotFound("This ID does not exist");
            
        var assignmentExist = _assignmentRepository.GetAssignment(assignmentId);
        if(assignmentExist == null)
        {
            return NotFound("The assignment could not be found!");
        }

        _mapper.Map(updateAssignment, assignmentExist);

        if(!_assignmentRepository.UpdateAssignment(assignmentExist))

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
    [HttpGet("GetAssignmentByUserId")]
    public IActionResult GetAssignmentByUserId(string userId)
    {
        if(!_userRepository.UserExist(userId))
            return NotFound("User does not exist");
        var assignmentByUser = _assignmentRepository.GetAssignmentByUserId(userId);
        return Ok(assignmentByUser);
    }



}
