using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Data;
using Pomodoro.Dto;
using Pomodoro.Interface;
using Pomodoro.Models;

namespace Pomodoro.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    //private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    //this is dependency injection
    public UserController(IMapper mapper, IUserRepository userRepository)
    {
        //_userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;

    }

    //Get all users
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await  _userRepository.GetUsersAsync();
        return Ok(users);
    }

    // this return a single user information
    [HttpGet ("email")]
    public async Task<IActionResult> GetUser(string email)
    {
        var  retriveUser = await _userRepository.GetUserbyEmailAsync(email);
        if (retriveUser == null)
            return NotFound();

        var user = await _userRepository.GetUserbyEmailAsync(email);
        return Ok(user);
    }

    //this is to get the assignments assigned to a single user
    // there might be a need to change from user Id to using user email.
    
    [HttpGet("GetAssignmentsByUserId")]
    public async Task<IActionResult> GetAssignmentsByUserId(string userId)
    {
        var user = await _userRepository.GetUserbyIdAsync(userId);
        if(user==null)
            return NotFound();
        var assignmentByUserId = await _userRepository.GetAssignmentsAsync(userId);
        if(assignmentByUserId == null)
            return NotFound("This user has no assignment!");
        return Ok(assignmentByUserId);
    }

    [HttpGet("GetAssignmentbyUserEmail")]
    public async Task<IActionResult> GetAssignmentbyUserEmail(string userEmail)
    {
        var mail = await _userRepository.UserExist(userEmail);
        if(mail == null)
            return NotFound();
        
        var assignments = await _userRepository.GetAssignmentByUserEmailAsync(userEmail);
        if(assignments == null)
        {
            return NotFound();
        }
        return Ok(assignments);
    }

}