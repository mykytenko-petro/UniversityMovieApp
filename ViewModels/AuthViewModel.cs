namespace UniversityMovieApp.ViewModels;

public class AuthViewModel
{
    public LoginViewModel? Login { get; set; }
    public RegisterViewModel? Register { get; set; }
}

public class LoginViewModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class RegisterViewModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}