using Microsoft.AspNetCore.Mvc;
using UniversityMovieApp.Models;
using UniversityMovieApp.Services;
using UniversityMovieApp.ViewModels;

namespace UniversityMovieApp.Controllers;

[Route("")]
public class MovieController(IMediaService mediaService, AppDbContext dbContext) : Controller
{
    private readonly IMediaService _mediaService = mediaService;
    private readonly AppDbContext _dbContext = dbContext;

    [HttpGet("{id:int}")]
    public IActionResult Watch([FromRoute] int id)
    {
        return View();
    }

    [HttpGet("upload")]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost("upload")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(MovieUploadViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            string videoUrl = await _mediaService.UploadFile(model.VideoFile);

            var movie = new Movie
            {
                OriginalName = model.OriginalName,
                TranslatedName = model.TranslatedName,
                VideoUrl = videoUrl
            };

            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Watch", new { id = movie.Id });
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", $"An error occurred while uploading the movie: {e.Message}");
            return View(model);
        }
    }
}