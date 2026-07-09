namespace UniversityMovieApp.ViewModels;

public class MovieWatchViewModel
{
    public required string OriginalName { get; set; }
    public string? TranslatedName { get; set; }
    public required string VideoUrl { get; set; }
}