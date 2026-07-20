using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversityMovieApp.ViewModels;

namespace UniversityMovieApp.Controllers;

[Route("auth")]
public class AuthController(
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager
) : Controller
{
    [HttpPost("register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(AuthViewModel model)
    {
        if (!ModelState.IsValid || model.Register is null)
            return Redirect("/");

        var user = new IdentityUser {
            UserName = model.Register.Email,
            Email = model.Register.Email
        };
        var result = await userManager.CreateAsync(user, model.Register.Password);

        if (result.Succeeded)
            await signInManager.SignInAsync(user, isPersistent: false);

        return Redirect("/");
    }

    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AuthViewModel model)
    {
        if (!ModelState.IsValid || model.Login is null)
            return Redirect("/");

        await signInManager.PasswordSignInAsync(
            model.Login.Email,
            model.Login.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );        

        return Redirect("/");
    }

    [HttpPost("logout")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return Redirect("/");
    }
}