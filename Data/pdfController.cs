using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Text;
using System.Text.Json;

namespace Construlink.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        [HttpPost("gerar")]
        public IActionResult Gerar([FromBody] PdfRequest request)
        {
            using var doc = new PdfDocument();
            var page = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 12);

            double y = 40;
            gfx.DrawString(request.Titulo, new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black,
                new XRect(0, y, page.Width, page.Height), XStringFormats.TopCenter);
            y += 40;

            foreach (var linha in request.Linhas)
            {
                gfx.DrawString(linha, font, XBrushes.Black,
                    new XRect(40, y, page.Width - 80, page.Height), XStringFormats.TopLeft);
                y += 20;
            }

            using var ms = new MemoryStream();
            doc.Save(ms, false);
            var bytes = ms.ToArray();

            return File(bytes, "application/pdf", $"{request.FicheiroNome}.pdf");
        }
    }

    public class PdfRequest
    {
        public string Titulo { get; set; }
        public List<string> Linhas { get; set; }
        public string FicheiroNome { get; set; }
    }
}
