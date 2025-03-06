    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Pomodoro.Data;
    using Pomodoro.Dto;
    using Pomodoro.Interface;
    using Pomodoro.Models;
    using Pomodoro.Repository;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
    using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Pomodoro.Controller;

    //[Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

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
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            var assignments =  await _assignmentRepository.GetAssignmentsAsync();
            var assignmentMaps = _mapper.Map<List<AssignmentOutputDto>>(assignments);
            return Ok(assignmentMaps);
        }

// an idea, a web page that helps user generate lyrics to a song 

        [Authorize]
        [HttpGet("AssignmentbyId/{assignmentId}")]
        [ProducesResponseType(200, Type = typeof(Assignment))]
        public async Task<IActionResult> GetAssignment(int assignmentId)
        {   
                
            //this is getting the userId from the logged in token

            if(!_assignmentRepository.AssignmentExist(assignmentId))
            {
                return NotFound($"Assignment {assignmentId} not found");
            }        

        //retrieving the assignment, and checking if the assignment.userid is the same as the one retrived from the token
        var assignment = await _assignmentRepository.GetAssignmentAsync(assignmentId);
        

        var assignmnetDto = _mapper.Map<AssignmentDto>(assignment); 

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(assignmnetDto);
            
        }
        // there should be a check to see if the the userId even exist before the assignment is created.

        [Authorize]
        [HttpPost ("CreateAssignment")]
        public async Task<IActionResult> CreateAssignment([FromBody] AssignmentDto assignment)
        {
            if(assignment == null)
                return BadRequest();
            
            Console.WriteLine($"Received : {JsonSerializer.Serialize(assignment)}"); 
            
            var userId = User.FindFirst("Id")?.Value;
            if(string.IsNullOrEmpty(userId))
                return Unauthorized("user not authorized.");
            var userExists =  await _userRepository.GetUserbyIdAsync(userId);

            // var existingAsignment = await _assignmentRepository.GetAssignmentsAsync();
            // var existingAssignmentDto = existingAsignment.FirstOrDefault(assignment => assignment.AssignmentTitle.Trim()
            // .ToLower()== assignment.AssignmentTitle.Trim().ToLower() && assignment.UserId == userId);

            // if(existingAssignmentDto != null)
            //     return Conflict("An assignment with the same title already exist for this user");
            var assignmentMap = _mapper.Map<Assignment>(assignment);

             assignmentMap.UserId = userId;
            
            
            if(!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }
            var created = await _assignmentRepository.CreateAssignmentAsync(assignmentMap);

            return Ok("Assignment successfully created! ");
        }

        [Authorize]
        [HttpPut ("{assignmentId}")]
        public async Task<IActionResult> UpdateAssignment(int assignmentId, [FromBody] AssignmentInputDto updateAssignment)
        {
            // var search = _assignmentRexository.AssignmentExist(Id);
            if(updateAssignment == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if(!_assignmentRepository.AssignmentExist(assignmentId))
                return NotFound("This ID does not exist");
                
            var assignmentExist = await _assignmentRepository.GetAssignmentAsync(assignmentId);
            if(assignmentExist == null)
            {
                return NotFound("The assignment could not be found!");
            }

            _mapper.Map(updateAssignment, assignmentExist);
            if (!await _assignmentRepository.UpdateAssignment(assignmentExist)) 
            {
                return StatusCode(500, "An error occurred while updating the assignment.");
            }

            return NoContent();
        }
        [Authorize]
        [HttpDelete("{assignmentId}")]
        public async Task<IActionResult> DeleteAssignment(int assignmentId)
        {
            if(! _assignmentRepository.AssignmentExist(assignmentId))
                return BadRequest();
            var deleteassignment = await _assignmentRepository.GetAssignmentAsync(assignmentId);

           await _assignmentRepository.DeleteAssignment(deleteassignment);

            return Ok();
        }

        //reminders under one assignment
        [Authorize]
        [HttpGet("GetAssignmentByUserId")]
        public async Task<IActionResult> GetAssignmentByUserId(string userId)
        {
            var user = await _userRepository.GetUserbyIdAsync(userId);

            if(user == null)
                return NotFound("User does not exist");
            var assignmentByUser = await _assignmentRepository.GetAssignmentByUserId(userId);
            return Ok(assignmentByUser);
        }
    }
