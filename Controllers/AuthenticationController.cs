using Configuration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Models;
using Pomodoro.Dto;
using Dto;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Pomodoro.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController: ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly JwtConfig _jwtConfig;

    public AuthenticationController(UserManager<User> userManager, IOptions<JwtConfig> jwtConfig)
    {
        _userManager = userManager;
        _jwtConfig =jwtConfig.Value;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto requestDto)
    {
        //checing if the email exist already
        if(ModelState.IsValid){
            var email_exist = await _userManager.FindByEmailAsync(requestDto.Email);
            if (email_exist != null)
            {
                return BadRequest(new AuthResponse()
                {
                    Result = false,
                    Error = new List<string>()
                    {
                        "Provided email already exist"
                    }
                });
            }
            // creating the a new user
            var new_user = new User()
            {
                Email = requestDto.Email,
                UserName = requestDto.Email,
            };
            var is_Created = await _userManager.CreateAsync(new_user, requestDto.Password);
            if(is_Created.Succeeded)
            {
                //Generate the token
                var token = GenerateJwtTokken(new_user);
                return Ok(new AuthResponse()
                {
                    Result = true,
                    Token = token,
                });

            }
            return BadRequest(new AuthResponse()
            {
                Error = new List<string>()
                {
                    "Server Error"
                },
                Result = false
            });

        }
        return BadRequest();
    }
    private string GenerateJwtTokken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var Key =  Encoding.UTF8.GetBytes(_jwtConfig.Secret);
        //Token Desciptor

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
          Subject = new ClaimsIdentity(new []{
            new Claim("Id", user.Id),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            //new Claim(JwtRegisteredClaimNames.)
          }),
          Expires = DateTime.Now.AddHours(1),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }
// to be valued means to be given an impression that you are not easily replaceable
    //login 
    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
    {
        if(ModelState.IsValid)
        {
            //check if user exist
            var user_exist = await _userManager.FindByEmailAsync(loginUser.Email);
            if(user_exist != null)
            {
                var is_correct =await _userManager.CheckPasswordAsync(user_exist, loginUser.Password);
                if(!is_correct)
                {
                    return BadRequest(new AuthResponse()
                    {
                        Error = new List<string> {
                            "Invalid Request",
                        },
                        Result = false,

                    });
                }

                var jwtToken = GenerateJwtTokken(user_exist);
                return Ok(new AuthResponse()
                {
                    Result = true,
                    Token = jwtToken

                });

            }
            return BadRequest(new AuthResponse()
            {
                Error = new List<string>()
                {
                    "Invalid credential"
                },
                Result = false

            });

        }
        return BadRequest(new AuthResponse()
            {
                Error = new List<string>()
                {
                    "Login Error"
                },
                Result = false,
            });



    }

    [Route("Users")]
    [HttpGet]
    public ActionResult GetUser()
    {
        var existing_user = _userManager.Users;
    
        return Ok (existing_user);
    
    }

    // [Route ("Logout")]
    // [HttpPost]
    // public async Task<IActionResult> Logout()
    // {

    // }


}