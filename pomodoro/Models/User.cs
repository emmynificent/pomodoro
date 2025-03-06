using Microsoft.AspNetCore.Identity;
namespace Pomodoro.Models;

public class User :IdentityUser
{
    //public string Id {get; set;} 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    //public string? UserName {get; set;}

    public ICollection<Assignment>? Assignments { get; set; }
    
}