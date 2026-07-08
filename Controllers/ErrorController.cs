using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniversityMovieApp.Models;

namespace UniversityMovieApp.Controllers;

[Route("")]
public class ErrorController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}