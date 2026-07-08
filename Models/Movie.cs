namespace UniversityMovieApp.Models;

public class Movie
{
    public int Id {get; set;}

    public required string OriginalName {get; set;}
    public string? TranslatedName {get; set;}

    public required string VideoUrl { get; set; }
}