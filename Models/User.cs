using Microsoft.AspNetCore.Identity;
namespace Pomodoro.Models;

public class User :IdentityUser
{
    //public int Id {get; set;} 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName {get; set;}
    //public string email {get; set;}
    public ICollection<Assignment>? Assignments { get; set; }
    
}