namespace Pomodoro.Models;

public class AuthResponse
{
    public string Token {get; set;}
    public bool Result {get; set;}
    public List<string>? Error {get; set;}
}