using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Dto;
public class UserDto
{
    [Required (ErrorMessage="Username is required")]
    public string Username {get; set;}
    [Required (ErrorMessage = "Email is required")]
    public string Email {get; set;}
    [Required (ErrorMessage = "Password is required")]
    public string Password {get; set;}
    [Compare ("Password", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword {get; set;}

    public string UserId{get; set;}

    
} 