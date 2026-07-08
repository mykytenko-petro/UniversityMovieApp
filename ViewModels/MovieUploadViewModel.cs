using System.ComponentModel.DataAnnotations;

namespace UniversityMovieApp.ViewModels;

public class MovieUploadViewModel
{
    public required string OriginalName { get; set; }
    public string? TranslatedName { get; set; }

    [Required(ErrorMessage = "Please select a video file to upload.")]
    public required IFormFile VideoFile { get; set; }
}