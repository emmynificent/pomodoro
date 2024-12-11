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
    public IActionResult GetUsers()
    {
        var users = _userRepository.GetUsers();
        return Ok(users);
    }

    // this return a single user information
    [HttpGet ("userId")]
    public IActionResult GetUser(string userId)
    {
        if (!_userRepository.UserExist(userId))
            return NotFound();

        var user = _userRepository.GetUser(userId);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(UserDto userDto)
    {
        if (userDto == null)
            return BadRequest();
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var userMap = _mapper.Map<User>(userDto);
        if(!_userRepository.CreateUser(userMap))
            return NotFound();
        return Created();
    }

    //this is to get the assignments assigned to a single user
    [HttpGet("GetAssignmentsByUserId")]
    public IActionResult GetAssignmentsByUserId(string userId)
    {
        if(!_userRepository.UserExist(userId))
            return NotFound();
        var assignmentByUserId = _userRepository.GetAssignments(userId);
        if(assignmentByUserId == null)
            return NotFound("This user has no assignment!");
        return Ok(assignmentByUserId);

    }

}