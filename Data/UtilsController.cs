using Microsoft.AspNetCore.Mvc;

namespace Construlink.Data;

[Route("api/[controller]")]
[ApiController]
public class UtilsController : ControllerBase
{
    private readonly string _imgRoot;
    private readonly string _docsRoot;
    private readonly IWebHostEnvironment _env;

    public UtilsController(IConfiguration cfg, IWebHostEnvironment env)
    {
        _env = env;
        _imgRoot = Path.Combine(env.WebRootPath, cfg["Paths:Images"]);
        _docsRoot = Path.Combine(env.WebRootPath, cfg["Paths:Docs"]);

        Directory.CreateDirectory(_imgRoot);
        Directory.CreateDirectory(_docsRoot);
    }

    /* ---------- GET IMAGE ---------- */
    [HttpGet("GetImage/{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        // procura ficheiro que comece pelo prefixo (ex.:  123_*.png)
        var match = Directory.EnumerateFiles(_imgRoot, $"{Path.GetFileNameWithoutExtension(fileName)}_*")
                             .FirstOrDefault();

        if (match is null)
            return PhysicalFile(Path.Combine(_env.WebRootPath, "images", "DefaultImg.png"), "image/png");

        var mime = match.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                   ? "image/jpeg" : "image/png";

        return PhysicalFile(match, mime);
    }

    /* ---------- GET COLABORADOR FILE ---------- */
    [HttpGet("GetColaboradorFile/{fileName}")]
    public IActionResult GetColaboradorFile(string fileName)
    {
        var safePath = Path.GetFullPath(Path.Combine(_docsRoot, fileName));
        if (!safePath.StartsWith(_docsRoot, StringComparison.OrdinalIgnoreCase))
            return BadRequest("Nome de ficheiro inválido");
        if (!System.IO.File.Exists(safePath))
            return NotFound();

        var ext = Path.GetExtension(safePath).ToLowerInvariant();
        var mime = ext switch
        {
            ".pdf" => "application/pdf",
            ".doc" => "application/msword",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            _ => "application/octet-stream"
        };

        return PhysicalFile(safePath, mime, Path.GetFileName(safePath));
    }
}
