using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class PostalCodeHelper
{
    /// <summary>
    /// Valida código-postal, localidade e localidade postal.
    /// Mostra toast vermelho se falhar.
    /// </summary>
    public static async Task<(string Mensagem, bool Sucesso)> ValidarAsync(DbContext db, IJSRuntime js, string? codigoPostal, string? localidade, string? localPostal)
    {
        string? mensagem = "Gravado com sucesso!";
        bool retorno = true;

        if (string.IsNullOrWhiteSpace(codigoPostal) || !Regex.IsMatch(codigoPostal, @"^\d{4}-\d{3}$"))
        {
            mensagem = "Gravado com sucesso. No entanto, o código-postal esta vazio ou mal formatado (1234-567). Por favor, verifique.";
            retorno = false;
        }
        else
        {
            var p = codigoPostal.Split('-');
            short num = short.Parse(p[0]);
            short ext = short.Parse(p[1]);

            var cp = await db.Set<CodigoPostal>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(c =>
                                  c.NumCodPostal == num &&
                                  c.ExtCodPostal == ext);

            if (cp is null)
            {
                mensagem = "Gravado com sucesso. No entanto, o código-postal é inexistente. Por favor, verifique.";
                retorno = false;
            }
            else
            {
                bool localOK = Igual(localidade, cp.NomeLocalidade);
                bool postalOK = Igual(localPostal, cp.DesigPostal);

                if (!localOK || !postalOK)
                {
                    mensagem = "Gravado com sucesso. No entanto, foi detetada uma inconsistência nos dados da morada. Por favor, verifique.";
                    retorno = false;
                }
            }
        }
         
        return (mensagem, retorno);

        /* helpers locais */
        static bool Igual(string? a, string? b) => Normal(a) == Normal(b);

        static string Normal(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";
            var n = s.Trim().ToUpperInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in n)
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            return sb.ToString();
        }
    }
}
