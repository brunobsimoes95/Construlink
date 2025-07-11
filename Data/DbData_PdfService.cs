using Microsoft.Extensions.Configuration;

namespace Construlink.Data
{
    /// <summary>
    /// Serviço de configuração para geração de relatórios/PDFs sem hard‑codes a servidores da antiga empresa.
    /// Todos os caminhos e credenciais vêm do appsettings.json (ou User‑Secrets/Env‑Vars).
    /// </summary>
    public class ReportServiceSettings
    {
        private readonly IConfiguration _cfg;
        private readonly IWebHostEnvironment _env;

        public ReportServiceSettings(IConfiguration cfg, IWebHostEnvironment env, string database, string reportName, string selectionFormula = "")
        {
            _cfg = cfg;
            _env = env;

            // ligação SQL / WSKey vêm da secção "ReportService" do appsettings
            var rs = cfg.GetSection("ReportService");
            Server = rs.GetValue<string>("Server");
            User = rs.GetValue<string>("User");
            Password = rs.GetValue<string>("Password");
            WsKey = rs.GetValue<string>("WsKey");

            Database = database;
            SelectionFormula = selectionFormula;
            ReportName = reportName;          // setter calcula paths abaixo
        }

        /* --------------- propriedades públicas --------------- */
        public string Server { get; }
        public string User { get; }
        public string Password { get; }
        public string WsKey { get; }
        public string Database
        {
            get => _database;
            set { _database = value; UpdatePaths(); }
        }

        public string SelectionFormula { get; set; }

        public string ReportName
        {
            get => _reportName;
            set { _reportName = value; UpdatePaths(); }
        }

        public string ReportPath { get; private set; } = string.Empty;
        public string OutputPdfFullPath { get; private set; } = string.Empty;
        public string PdfUrl { get; private set; } = string.Empty;

        /* --------------- campos privados --------------- */
        private string _database = string.Empty;
        private string _reportName = string.Empty;

        /* --------------- actualiza caminhos dependendo de DB/Report --------------- */
        private void UpdatePaths()
        {
            // Base fisica dos ficheiros RPT dentro do projecto → /Reports
            var rptBase = Path.Combine(_env.ContentRootPath, "Reports");
            // PDFs gerados vão para wwwroot/reports/pdfs/{db}/report.pdf
            var pdfBase = Path.Combine(_env.WebRootPath, "reports", "pdfs", _database);
            Directory.CreateDirectory(pdfBase);

            ReportPath = Path.Combine(rptBase, $"{_reportName}.rpt");
            OutputPdfFullPath = Path.Combine(pdfBase, $"{_reportName}.pdf");

            // URL pública (caso sirvas via static files)
            var baseUrl = _cfg.GetValue<string>("AppSettings:BaseUrl") ?? "http://localhost:5000/";
            PdfUrl = $"{baseUrl.TrimEnd('/')}/reports/pdfs/{_database}/{_reportName}.pdf";
        }
    }
}
