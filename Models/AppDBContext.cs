using Microsoft.EntityFrameworkCore;

namespace UniversityMovieApp.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}