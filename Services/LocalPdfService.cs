using Construlink.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using static Construlink.Pages.ControlePicagens.Picagens;

namespace Construlink.Services;

public class LocalPdfService : ILocalPdfService
{
    public Task<byte[]> GeraPdfAsync(IEnumerable<PicagemTratada> linhas, string titulo)
    {
        var pdfBytes = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);
                page.Content().Column(col =>
                {
                    col.Item().Text(titulo).FontSize(18).Bold();

                    col.Item().Table(t =>
                    {
                        t.ColumnsDefinition(c =>
                        {
                            c.ConstantColumn(80);
                            c.RelativeColumn();
                            c.ConstantColumn(60);
                            c.ConstantColumn(60);
                        });

                        t.Header(h =>
                        {
                            h.Cell().Text("Data");
                            h.Cell().Text("Colaborador");
                            h.Cell().Text("Entrada");
                            h.Cell().Text("Saída");
                        });

                        foreach (var l in linhas)
                        {
                            t.Cell().Text(l.Data?.ToString("dd-MM-yyyy"));
                            t.Cell().Text(l.Utilizadorid);
                            t.Cell().Text(l.Entrada?.ToString("HH:mm"));
                            t.Cell().Text(l.Saida?.ToString("HH:mm"));
                        }
                    });
                });
            });
        }).GeneratePdf();

        return Task.FromResult(pdfBytes);
    }
}
