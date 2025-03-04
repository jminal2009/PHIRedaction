using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/redact")]
public class PHIRedactionController : ControllerBase
{
    private readonly RedactorService _redactorService;

    public PHIRedactionController(RedactorService redactorService)
    {
        _redactorService = redactorService;
    }
    [HttpPost]
    public async Task<IActionResult> RedactFiles([FromForm] List<IFormFile> files)
    {
        var outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ProcessedFiles");
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                var filePath = Path.Combine(outputDirectory, file.FileName.Replace(".txt", "_sanitized.txt"));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Process the file (e.g., redact PHI)
                var content = await System.IO.File.ReadAllTextAsync(filePath);
                var redactedContent = _redactorService.RedactPHI(content);
                await System.IO.File.WriteAllTextAsync(filePath, redactedContent);
            }
        }

        return Ok(new { message = "Files processed successfully!" });
    }

    
}