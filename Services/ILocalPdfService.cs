
using static global::Construlink.Pages.ControlePicagens.Picagens;

namespace Construlink.Services;

public interface ILocalPdfService
{
    Task<byte[]> GeraPdfAsync(IEnumerable<PicagemTratada> linhas, string titulo);
}

