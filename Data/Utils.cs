using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Forms;
using System.Xml.Linq;
using System.Globalization;
using System.Reflection;
using Construlink.Models;


namespace Construlink.Data
{
    public class Utils
    {
        public Dictionary<string, string> Parametros;
        public Dictionary<string, object> AgSession;
        public const long MaxSizeAllowedInputFiles = 20 * 1024 * 1024; // 20 MB


        public string titlePageDoc = string.Empty;
        private readonly IConfiguration _cfg;

        public Utils(IConfiguration cfg)
        {
            _cfg = cfg;

            Parametros = new Dictionary<string, string>
            {
                ["nomeAplicacao"] = "Construlink",
                ["folderPath"] = _cfg["Files:BasePath"]!,   // C:\Users\bfs-b\Desktop\Construlink
                ["url"] = _cfg["Files:BaseUrl"]!,    // https://construlink.pt/
                ["folderPathHttp"] = _cfg["Files:BaseUrl"]!
            };

            AgSession = new Dictionary<string, object>();
            titlePageDoc = string.Empty;
        }


        //Gera password
        private static readonly Random random = new Random();
        public static string GeneratePassword(int length, bool includeLowercase = true, bool includeUppercase = true, bool includeNumeric = true, bool includeSpecial = true)
        {
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numericChars = "0123456789";
            const string specialChars = "!@#$%^&*";

            string charSet = "";

            if (includeLowercase) charSet += lowercaseChars;
            if (includeUppercase) charSet += uppercaseChars;
            if (includeNumeric) charSet += numericChars;
            if (includeSpecial) charSet += specialChars;

            if (string.IsNullOrEmpty(charSet))
                throw new ArgumentException("At least one character set must be included.");

            return new string(Enumerable.Repeat(charSet, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // 1) HASH NOVO – usa o salt que meteste nos user–secrets
        public static string Hash(string pwd, IConfiguration cfg)
        {
            string salt = cfg["Security:Salt"]
                          ?? throw new InvalidOperationException(
                                 "Security:Salt não definido em User-Secrets");
            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(
                            Encoding.UTF8.GetBytes(salt + pwd));
            return BitConverter.ToString(bytes)
                               .Replace("-", "")
                               .ToUpperInvariant();
        }

        



        //Log do utilizador (auditoria)
        public static void UserLog(int user, string coisas)
        {
            BaseControleContext dbContext = new BaseControleContext();
            dbContext.CrmAuditoria.Add(new CrmAuditorium { Utilizadorid = user, Data = DateTime.Now, Comportamento = coisas });
            dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }

        public async Task UserLogAsync(int user, string coisas)
        {
            BaseControleContext dbContext = new BaseControleContext();
            dbContext.CrmAuditoria.Add(new CrmAuditorium { Utilizadorid = user, Data = DateTime.Now, Comportamento = coisas });
            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }

        //email
        public async Task<bool> SendEmailAsync(string to, string subject, string bodyHtml)
        {
            var smtp = _cfg.GetSection("Smtp");

            var mail = new MailMessage
            {
                From = new MailAddress(smtp["User"]!),
                Subject = subject,
                Body = bodyHtml,
                IsBodyHtml = true
            };
            mail.To.Add(to);

            ServicePointManager.ServerCertificateValidationCallback = (_, _, _, _) => true;

            using var client = new SmtpClient(smtp["Host"], int.Parse(smtp["Port"]!))
            {
                Credentials = new NetworkCredential(smtp["User"], smtp["Pass"]),
                EnableSsl = true
            };

            await client.SendMailAsync(mail);
            return true;
        }



        //verifica protocolo HTTP ou HTTPS
        public static bool CheckProtocol(string pagina)
        {
            var uri = new Uri(pagina);
            var isHttps = uri.Scheme == Uri.UriSchemeHttps;

            if (isHttps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> CheckProtocolAsync(string pagina)
        {
            var uri = new Uri(pagina);
            var isHttps = uri.Scheme == Uri.UriSchemeHttps;

            if (isHttps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //envia uma cor random
        public string GetRandomColor()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 256);
            int g = rnd.Next(0, 256);
            int b = rnd.Next(0, 256);
            return $"rgba({r},{g},{b},1.0)";
        }

        //verifica email
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Return true if strIn is in valid e-mail format
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static string GetSvgPathData(string servidor, string tipo, string icone)
        {
            string svgFileName = $"{icone}.svg";

            string basePath;
            if (servidor.ToLower() == "web")
            {
                basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "fontawesome", "svgs", tipo);
            }
            else
            {
                basePath = Path.Combine(servidor, tipo);
            }

            string filePath = Path.Combine(basePath, svgFileName);

            if (!File.Exists(filePath))
            {
                return $"Arquivo não encontrado: {filePath}";
            }

            try
            {
                var doc = XDocument.Load(filePath);
                var svgElement = doc.Root;
                var pathElement = svgElement?.Descendants().FirstOrDefault(e => e.Name.LocalName == "path");

                if (pathElement == null)
                {
                    return "Atributo 'path' não encontrado no SVG";
                }

                string pathData = pathElement.Attribute("d")?.Value ?? "Atributo 'd' não encontrado";
                string viewBox = svgElement?.Attribute("viewBox")?.Value ?? "0 0 24 24";

                return $@"<svg style=""width:24px;height:24px"" viewBox=""{viewBox}"">
                    <path fill=""currentColor"" d=""{pathData}"" />
                </svg>";
            }
            catch (Exception ex)
            {
                return $"Erro ao processar o arquivo SVG: {ex.Message}";
            }
        }

        public bool isEmailValidoNaoRepetido(string email, int id)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Return true if strIn is in valid e-mail format
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
                {
                    return false;
                }

                using (var dbContext = new BaseControleContext())
                {
                    bool emailExiste = dbContext.CrmUtilizadors
                        .Any(u => u.Email.ToLower() == email.ToLower() && u.Id != id);

                    return !emailExiste;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
        private string DomainMapper(Match match)
        {
            // Use IdnMapping class to convert Unicode domain names.
            var idn = new IdnMapping();
            // Pull out and process domain name (throws ArgumentException on invalid)
            string domainName = idn.GetAscii(match.Groups[2].Value);
            return match.Groups[1].Value + domainName;
        }

        //calcular preço iliquido
        public decimal CalcIliquido(decimal qt, decimal price, decimal desconto)
        {
            decimal iliquido = 0;

            iliquido = qt * price - desconto; //desconto já calculado

            return iliquido;
        }

        //calcular desconto
        public decimal CalcDesconto(decimal qt, decimal price, decimal desconto)
        {
            decimal totDesconto = 0;

            totDesconto = qt * (price * desconto / 100);

            return totDesconto;
        }

        //calcula preço total
        public decimal CalcTotalPreco(decimal totPreco, decimal iva)
        {
            decimal calcTotPreco = 0;

            calcTotPreco = totPreco + totPreco * (iva / 100);

            return calcTotPreco;
        }

        //Gerar Lote 
        public string GerarLote()
        {
            string lote = string.Empty;

            Random random = new Random();
            int numeroAleatorio = random.Next(1, 10000); // Gera um número aleatório de 10 a 9999

            lote = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month + "/" + numeroAleatorio.ToString();

            return lote;
        }

        //sistema de pastas e subpastas dos artigos
        public void CreateFolders(string codigo, string tipo)
        {
            string productPath = Path.Combine(Parametros["folderPath"], tipo, codigo);
            if (!Directory.Exists(productPath))
            {
                Directory.CreateDirectory(productPath);
            }

            if (tipo == "artigos")
            {
                string productPath1 = Path.Combine(Parametros["folderPath"], tipo, codigo, "CertificadosMaterial");
                if (!Directory.Exists(productPath1))
                {
                    Directory.CreateDirectory(productPath1);
                }
                string productPath2 = Path.Combine(Parametros["folderPath"], tipo, codigo, "DesenhosTecnicos");
                if (!Directory.Exists(productPath2))
                {
                    Directory.CreateDirectory(productPath2);
                }
                string productPath3 = Path.Combine(Parametros["folderPath"], tipo, codigo, "DocumentosAssociados");
                if (!Directory.Exists(productPath3))
                {
                    Directory.CreateDirectory(productPath3);
                }
                string productPath4 = Path.Combine(Parametros["folderPath"], tipo, codigo, "Esquemas");
                if (!Directory.Exists(productPath4))
                {
                    Directory.CreateDirectory(productPath4);
                }
                string productPath5 = Path.Combine(Parametros["folderPath"], tipo, codigo, "FolhaRosto");
                if (!Directory.Exists(productPath5))
                {
                    Directory.CreateDirectory(productPath5);
                }
                string productPath6 = Path.Combine(Parametros["folderPath"], tipo, codigo, "Qualidade");
                if (!Directory.Exists(productPath6))
                {
                    Directory.CreateDirectory(productPath6);
                }
                string productPath7 = Path.Combine(Parametros["folderPath"], tipo, codigo, "Imagens");
                if (!Directory.Exists(productPath7))
                {
                    Directory.CreateDirectory(productPath7);
                }
                string productPath8 = Path.Combine(Parametros["folderPath"], tipo, codigo, "Diversos");
                if (!Directory.Exists(productPath8))
                {
                    Directory.CreateDirectory(productPath8);
                }
            }
        }

        public List<FileSystemEntry> GetFoldersAndFiles(string codigoartigo, string tipo, string pasta, string subpasta)
        {
            string directoryPath = Path.Combine(Parametros["folderPath"], tipo, codigoartigo, pasta, subpasta);
            string father = pasta;
            if (subpasta != "")
            {
                father = subpasta;
            }

            List<FileSystemEntry> entries = new List<FileSystemEntry>();

            if (Directory.Exists(directoryPath))
            {
                try
                {
                    //directorias
                    foreach (var directory in Directory.GetDirectories(directoryPath))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(directory);
                        entries.Add(new FileSystemEntry { Name = dirInfo.Name, Path = dirInfo.FullName, IsFile = false, FatherPath = father });
                    }

                    //ficheiros
                    foreach (var file in Directory.GetFiles(directoryPath))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        entries.Add(new FileSystemEntry { Name = fileInfo.Name, Path = fileInfo.FullName, IsFile = true, FatherPath = father });
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return entries;
        }
        public bool CreateFolder(string currentFolder, string newFolder)
        {
            try
            {
                string combined = currentFolder + "\\" + newFolder;
                if (!Directory.Exists(combined))
                {
                    Directory.CreateDirectory(combined);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteFolder(string currentFolder)
        {
            try
            {
                if (Directory.Exists(currentFolder))
                {
                    Directory.Delete(currentFolder, recursive: true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RenameFolder(string currentName, string newName)
        {
            try
            {
                string combined = currentName.Substring(0, currentName.LastIndexOf("\\")) + "\\" + newName;
                if (Directory.Exists(currentName))
                {
                    Directory.Move(currentName, combined);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteFile(string currentFile)
        {
            try
            {
                if (File.Exists(currentFile))
                {
                    File.Delete(currentFile);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SaveFile(string folder, IBrowserFile file)
        {
            try
            {
                // garante que a pasta existe
                Directory.CreateDirectory(folder);

                var fullPath = Path.Combine(folder, file.Name);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                await using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                await file.OpenReadStream(MaxSizeAllowedInputFiles).CopyToAsync(fs);

                return true;
            }
            catch
            {
                return false;   // em caso de erro devolve false
            }
        }


        public static async Task<string?> UploadImg(IBrowserFile file)
        {
            try
            {
                const string folder = @"C:\Conteudo";
                Directory.CreateDirectory(folder);

                var ext = Path.GetExtension(file.Name);
                var name = $"{Guid.NewGuid()}{ext}";
                var path = Path.Combine(folder, name);

                await using var fs = new FileStream(path, FileMode.Create);
                await file.OpenReadStream(MaxSizeAllowedInputFiles).CopyToAsync(fs);

                return name;                    // nome gerado para gravar na BD
            }
            catch
            {
                return null;                    // erro ⇒ devolve null
            }
        }



        //verifica url
        public bool IsValidUrl(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                          && uriResult.Host.Contains(".");
            return result;
        }

        public static string GetImgNameWithoutType(string imgName) => Path.GetFileNameWithoutExtension(imgName);
        public static string GetImgLocationFromName(string imgName) => $@"C:\Conteudo\{imgName}";
        public static string GetImgUrlFromName(string imgName) => $"http://217.112.85.215:8081/Conteudo/{imgName}";

        // substitui completamente a classe antiga
        public class ImgHolder
        {
            public IBrowserFile File { get; set; } = default!;   // ficheiro recebido do <InputFile>
            public byte[] FileBytes { get; set; } = Array.Empty<byte>();
        }


       

        
        public static List<CrmEmpresa> GetEmpresasFromUser(int userId)
        {
            try
            {
                using (var dbContext = new BaseControleContext())
                {
                    List<int> utilizadorEmpresasId = dbContext.UtilizadorEmpresas.Where(i => i.UtilizadorId == userId).Select(i => i.EmpresaId).ToList();
                    List<CrmEmpresa> listaEmpresas = dbContext.CrmEmpresas.Where(i => utilizadorEmpresasId.Contains(i.Id)).ToList();

                    return listaEmpresas;
                }
            }
            catch (Exception)
            {
                return new List<CrmEmpresa>();
            }
        }
        public static CultureInfo GetCultureInfoForDatePicker()
        {
            var culture = new CultureInfo("pt-PT");
            DateTimeFormatInfo formatInfo = culture.DateTimeFormat;
            formatInfo.AbbreviatedDayNames = new[] { "Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb" };
            formatInfo.DayNames = new[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" };
            var monthNames = new[]
            {
            "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro", 
                ""
        };
            formatInfo.AbbreviatedMonthNames =
                formatInfo.MonthNames =
                    formatInfo.MonthGenitiveNames = formatInfo.AbbreviatedMonthGenitiveNames = monthNames;
            formatInfo.ShortDatePattern = "yyyy/MM/dd";
            formatInfo.LongDatePattern = "dddd, dd MMMM,yyyy";
            formatInfo.FirstDayOfWeek = DayOfWeek.Sunday;
            return culture;
        }

        //abrir arquivo a partir do stream
        public async Task<(string base64Data, string mimeType)> OpenFileFromStream(string file)
        {
            // Abre e fecha o ficheiro corretamente com using
            using var fileStream = File.OpenRead(file);

            // Obtém o tipo MIME
            var mimeType = GetMimeType(file);

            // Converte para base64
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            var base64Data = Convert.ToBase64String(memoryStream.ToArray());

            return (base64Data, mimeType);
        }

        // Detecta o tipo MIME com base na extensão do arquivo
        private string GetMimeType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            return ext switch
            {
                ".pdf" => "application/pdf",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".txt" => "text/plain",
                ".html" => "text/html",
                ".css" => "text/css",
                ".js" => "application/javascript",
                ".json" => "application/json",
                ".csv" => "text/csv",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream" // valor padrão para download
            };
        }
    }
   

    public static class UtilsExtension
    {
        public static bool IsDeeplyEqualTo<T>(this T obj1, T obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;

            PropertyInfo[] properties = typeof(T).GetProperties();
            return properties.All(p => Equals(p.GetValue(obj1), p.GetValue(obj2)));
        }

        public static bool IsXlsx(this IBrowserFile file) => file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    }
}


