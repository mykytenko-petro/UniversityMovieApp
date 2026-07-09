namespace UniversityMovieApp.Services;

public interface IMediaService
{
    Task<string> UploadFile(IFormFile file);

    string GetUrl();
}

public sealed class DevelopmentMediaService : IMediaService
{
    private readonly string _targetFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media");

    public string GetUrl()
    {
        return "media/";
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new FileNotFoundException();
        }

        if (!Directory.Exists(_targetFolder))
        {
            Directory.CreateDirectory(_targetFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(_targetFolder, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"{uniqueFileName}";
    }
}

// TODO: Add Cloudinary support
public sealed class CloudinaryMediaService : IMediaService
{
    public string GetUrl()
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadFile(IFormFile file)
    {
        throw new NotImplementedException();
    }
}