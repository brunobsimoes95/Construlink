using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construlink.Migrations.Construlink
{
    /// <inheritdoc />
    public partial class InitConstrulink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "codigos_postais",
                columns: table => new
                {
                    cod_distrito = table.Column<byte>(type: "tinyint", nullable: false),
                    cod_concelho = table.Column<byte>(type: "tinyint", nullable: false),
                    cod_localidade = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    nome_localidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cod_arteria = table.Column<int>(type: "int", nullable: true),
                    tipo_arteria = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    prep1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    titulo_arteria = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    prep2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    nome_arteria = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    local_arteria = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    troco = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    porta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cliente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    num_cod_postal = table.Column<short>(type: "smallint", nullable: false),
                    ext_cod_postal = table.Column<short>(type: "smallint", nullable: false),
                    desig_postal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorEPIs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEpi = table.Column<int>(type: "int", nullable: true),
                    IdColaborador = table.Column<int>(type: "int", nullable: true),
                    NomeEpi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataAtribuicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorEPIs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "concelhos",
                columns: table => new
                {
                    cod_distrito = table.Column<byte>(type: "tinyint", nullable: false),
                    cod_concelho = table.Column<byte>(type: "tinyint", nullable: false),
                    nome_concelho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: true),
                    NumMecanografico = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TipoContrato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrimeiraHoraExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HoraExtraSub = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrdenadoHora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrdenadoBase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiaVencimento = table.Column<int>(type: "int", nullable: true),
                    PeriodoExperiencia = table.Column<bool>(type: "bit", nullable: true),
                    ContratoAtivo = table.Column<bool>(type: "bit", nullable: true),
                    Pica4 = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_ANEXOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    categoria_id = table.Column<int>(type: "int", nullable: false),
                    file_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_ANEXOS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CRM_CONCELHO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DISTRITOID = table.Column<int>(type: "int", nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CUSTO = table.Column<decimal>(type: "decimal(37,8)", nullable: true),
                    CUSTO2 = table.Column<decimal>(type: "decimal(37,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_CONCELHO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_CONFIG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPTION = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    VALUE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_CONFIG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_DISTRITO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PAISID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_DISTRITO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_EMPRESAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPicagens = table.Column<int>(type: "int", nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Favicon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogoNavBar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cor1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cor2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cor3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImagemCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImagemIndex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BaseNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_EMPRESAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRM_ENTIDADE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    nome = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    nome_fiscal = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    situacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tipo_preco = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    site = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NomeNivelPreco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NivelPreco = table.Column<int>(type: "int", nullable: true),
                    zona = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    vendedor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    morada = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    morada2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    localidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CpLoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TipoMercado = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Moeda = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdPrimavera = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    codigo_postal = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    telemovel = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    nif = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    data_upd = table.Column<DateTime>(type: "datetime", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    distrito = table.Column<int>(type: "int", nullable: true),
                    concelho = table.Column<int>(type: "int", nullable: true),
                    cond_Pagamento = table.Column<int>(type: "int", nullable: true),
                    tipo_entidade = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nib = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    iban = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    swift = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    plafond = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
                    fax = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    isentoiva = table.Column<bool>(type: "bit", nullable: true),
                    motivoisencao = table.Column<int>(type: "int", nullable: true),
                    IsPotencial = table.Column<bool>(type: "bit", nullable: true),
                    ccEntidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ccValidade = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_ENTIDADE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CRM_ENTIDADE_META",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entidade_id = table.Column<int>(type: "int", nullable: true),
                    meta_key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    meta_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_ENTIDADE_META", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CRM_FALTAS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Falta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_FALTAS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CRM_FERIADOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MES = table.Column<int>(type: "int", nullable: true),
                    DIA = table.Column<int>(type: "int", nullable: true),
                    TRABALHA = table.Column<bool>(type: "bit", nullable: true),
                    edita = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_FERIADOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_FERIAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_FERIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_HORARIO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    data = table.Column<DateTime>(type: "datetime", nullable: true),
                    day_of_week = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    ispausa = table.Column<bool>(type: "bit", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    sabado = table.Column<bool>(type: "bit", nullable: true),
                    domingo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_HORARIO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CRM_MOTIVOSISENCAO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ERPID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CODIGOERP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_MOTIVOSISENCAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_PAISES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CODIGO = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    COUNTRID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MARKETTYPE = table.Column<int>(type: "int", nullable: true),
                    SAFTCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_PAISES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_PICAGEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UTILIZADORID = table.Column<int>(type: "int", nullable: true),
                    ENTRADA = table.Column<DateTime>(type: "datetime", nullable: true),
                    INICIO_ALMOCO = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIM_ALMOCO = table.Column<DateTime>(type: "datetime", nullable: true),
                    SAIDA = table.Column<DateTime>(type: "datetime", nullable: true),
                    IP1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IP2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IP3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IP4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SAIDA_FORCADA = table.Column<bool>(type: "bit", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    LATITUDE = table.Column<double>(type: "float", nullable: true),
                    LONGITUDE = table.Column<double>(type: "float", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsFalta = table.Column<bool>(type: "bit", nullable: true),
                    IsFerias = table.Column<bool>(type: "bit", nullable: true),
                    IsFolga = table.Column<bool>(type: "bit", nullable: true),
                    IsFaltaJustificada = table.Column<bool>(type: "bit", nullable: true),
                    HorasFaltaParcial = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_PICAGEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_PRAZO_PAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ERPID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CODIGO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NUMDIAS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_PRAZO_PAGAMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_SERIE_DOCUMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPODOCUMENTOID = table.Column<int>(type: "int", nullable: true),
                    SERIE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ULTIMODOCUMENTO = table.Column<int>(type: "int", nullable: true),
                    SETORERP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ERPID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LAYOUTID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LOJAID = table.Column<int>(type: "int", nullable: true),
                    ISDEFAULT = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_SERIE_DOCUMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_TIPO_DOCUMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ENTRADASAIDA = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MODULO = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MOVSTOCKS = table.Column<bool>(type: "bit", nullable: true),
                    DEBITOCREDITO = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CODIGOERP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ERPID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CLASS = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ATIVO = table.Column<bool>(type: "bit", nullable: true),
                    CONTACORRENTE = table.Column<bool>(type: "bit", nullable: true),
                    PRECOSCOMIVA = table.Column<bool>(type: "bit", nullable: true),
                    CONTABILISTICO = table.Column<bool>(type: "bit", nullable: true),
                    CUSTOOBRA = table.Column<bool>(type: "bit", nullable: true),
                    INTEGRA_WT = table.Column<bool>(type: "bit", nullable: true),
                    RESERVASTOCK = table.Column<bool>(type: "bit", nullable: true),
                    ISDOCTRANSPORTE = table.Column<bool>(type: "bit", nullable: true),
                    IS_ORDEM_FABRICO = table.Column<bool>(type: "bit", nullable: true),
                    IS_DOC_ARMAZEM = table.Column<bool>(type: "bit", nullable: true),
                    REPORT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SELECTION_FORMULA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ISREGULARIZACAO = table.Column<bool>(type: "bit", nullable: true),
                    IS_ACERTO_STOCK = table.Column<bool>(type: "bit", nullable: true),
                    EDITAVEL = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_TIPO_DOCUMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "distritos",
                columns: table => new
                {
                    cod_distrito = table.Column<byte>(type: "tinyint", nullable: false),
                    nome_distrito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Epis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEticadata = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioFerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioFerias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioObraAgendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdObra = table.Column<int>(type: "int", nullable: false),
                    NomeObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraPausa = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraRetorno = table.Column<TimeSpan>(type: "time", nullable: true),
                    HorasNormais = table.Column<double>(type: "float", nullable: true),
                    HorasExtras = table.Column<double>(type: "float", nullable: true),
                    HoraSaida = table.Column<TimeSpan>(type: "time", nullable: true),
                    Trabalhou = table.Column<bool>(type: "bit", nullable: true),
                    FaltouParcialmente = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioObraAgendamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abreviatura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IDFuncao = table.Column<int>(type: "int", nullable: true),
                    OrdemMapas = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CustoHora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comercial = table.Column<bool>(type: "bit", nullable: true),
                    MontagensResponsavel = table.Column<int>(type: "int", nullable: true),
                    MontagensFuncionarios = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IDComissoesTabela = table.Column<int>(type: "int", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SenhaProvisoria = table.Column<int>(type: "int", nullable: true),
                    Inativo = table.Column<int>(type: "int", nullable: true),
                    USERNAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ISADMIN = table.Column<bool>(type: "bit", nullable: true),
                    IsChaoFabrica = table.Column<bool>(type: "bit", nullable: true),
                    LASTLOGON = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHANGEPASSWORD = table.Column<bool>(type: "bit", nullable: true),
                    ISMANAGER = table.Column<bool>(type: "bit", nullable: true),
                    REPORTTO = table.Column<int>(type: "int", nullable: true),
                    MACADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FAZ_PICAGENS = table.Column<bool>(type: "bit", nullable: true),
                    FUNCONARIO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_CF = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PREENCHE_TS = table.Column<bool>(type: "bit", nullable: true),
                    INICIO_TIMESHEETS = table.Column<DateTime>(type: "datetime", nullable: true),
                    DEPARTAMENTO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AGPASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMPRESA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VALIDA_PICAGENS = table.Column<bool>(type: "bit", nullable: true),
                    BANCO_HORAS = table.Column<bool>(type: "bit", nullable: true),
                    BANCO_HORAS_DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    BANCO_HORAS_START = table.Column<decimal>(type: "decimal(10,1)", nullable: true),
                    BANCO_HORAS_TURNO = table.Column<decimal>(type: "decimal(10,1)", nullable: true),
                    GEOLOCATION = table.Column<bool>(type: "bit", nullable: true),
                    ACEDE_OBRAS = table.Column<bool>(type: "bit", nullable: true),
                    ACEDE_ENTIDADES = table.Column<bool>(type: "bit", nullable: true),
                    AcedeComercial = table.Column<bool>(type: "bit", nullable: true),
                    IsFuncionario = table.Column<bool>(type: "bit", nullable: true),
                    AcedeArtigos = table.Column<bool>(type: "bit", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    veValore = table.Column<bool>(type: "bit", nullable: true),
                    acede_documentos = table.Column<bool>(type: "bit", nullable: true),
                    so_obras = table.Column<bool>(type: "bit", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Morada = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Concelho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodPostal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContatoSeguranca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nif = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SegSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CCValidade = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumFilhos = table.Column<int>(type: "int", nullable: true),
                    Seguro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NIB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Swift = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HabilitacoesLiterarias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ACEDE_CONTASCORRENTES = table.Column<bool>(type: "bit", nullable: true),
                    ADJUDICA_OBRA = table.Column<bool>(type: "bit", nullable: true),
                    IdCrmUtilizador = table.Column<int>(type: "int", nullable: true),
                    NumMecanografico = table.Column<int>(type: "int", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaminhoFoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NiveisPreco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Adicional = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveisPreco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_CONDPAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONDPAG = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DIAS = table.Column<int>(type: "int", nullable: true),
                    EMPRESAID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_CONDPAGAMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_ENTIDADES_ERP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPOENTIDADE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ENTIDADE = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NOMEFISCAL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MORADA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MORADA2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LOCALIDADE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CP_LOC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NUMCONTRIB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PAIS = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TIPOMERCADO = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MOEDA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMPRESAID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_ENTIDADES_ERP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_ESTADOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ORDEM = table.Column<int>(type: "int", nullable: true),
                    EMPRESAID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_ESTADOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_FRACOES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BLOCO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AREABRUTA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NOTAS = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CodigoObraPai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IMAGEM = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AREAUTIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TIPOLOGIA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ANDAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GARAGEM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VALOR_TOTAL = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    ESTADO = table.Column<int>(type: "int", nullable: true),
                    IMOBILIARIA = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    CLIENTE = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DATA_ENTREGA = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATA_CPCV = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_FRACOES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_IMOBILIARIAS_OBRA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OBRA_ID = table.Column<int>(type: "int", nullable: true),
                    ENTIDADE = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_IMOBILIARIAS_OBRA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_MODOSPAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MOVIM = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TIPOMV = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    EMPRESAID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_MODOSPAGAMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_OBRA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CLIENTE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATA_ADJUDICACAO = table.Column<DateTime>(type: "datetime", nullable: true),
                    CRIADA_POR = table.Column<int>(type: "int", nullable: true),
                    VALOR_ADJUDICACAO = table.Column<decimal>(type: "money", nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GESTOR = table.Column<int>(type: "int", nullable: true),
                    INICIO_PREVISTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIM_PREVISTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIM_REAL = table.Column<DateTime>(type: "datetime", nullable: true),
                    MORADA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LOCALIDADE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CODIGO_POSTAL = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LOCAL_POSTAL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COND_PAG = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    MODO_PAG = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    OBS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ERP_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DELETED = table.Column<bool>(type: "bit", nullable: true),
                    PARENT_ID = table.Column<int>(type: "int", nullable: true),
                    VALOR_SECO = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    VALOR_REORCAMENTO = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    VALOR_TOTAL_EST_MAT = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    TOTAL_TMAIS_APROVADOS = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    TOTAL_EO_APROVADOS = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    TOTAL_REVISAO_PRECOS_APROVADOS = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    VALOR_TOTAL_EST_SUBEMPREITADA = table.Column<decimal>(type: "decimal(37,2)", nullable: true),
                    DESBLOQUEAR_SUBEMPREITADAS = table.Column<bool>(type: "bit", nullable: true),
                    PROMOTOR = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    CONSTRUTOR = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ALVARA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VALIDADE_ALVARA = table.Column<DateTime>(type: "datetime", nullable: true),
                    ISEMPREENDIMENTO = table.Column<bool>(type: "bit", nullable: true),
                    PROCESSOID = table.Column<int>(type: "int", nullable: true),
                    EMPRESAID = table.Column<int>(type: "int", nullable: true),
                    LATITUDE = table.Column<double>(type: "float", nullable: true),
                    LONGITUDE = table.Column<double>(type: "float", nullable: true),
                    AREA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_OBRA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OSUSR_N2P_PROCESSO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARENTID = table.Column<int>(type: "int", nullable: true),
                    CODIGO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DESCRICAO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RESPONSAVEL = table.Column<int>(type: "int", nullable: true),
                    ATIVO = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSUSR_N2P_PROCESSO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoTurno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTurno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    NomeTipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Entrada = table.Column<TimeSpan>(type: "time", nullable: true),
                    Pausa = table.Column<TimeSpan>(type: "time", nullable: true),
                    Retorno = table.Column<TimeSpan>(type: "time", nullable: true),
                    Saida = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrmAusencias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    NomeColaborador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoAusencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraFim = table.Column<TimeSpan>(type: "time", nullable: true),
                    CriadaPor = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    EditadaPor = table.Column<int>(type: "int", nullable: true),
                    DataEdicao = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmAusencias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrmAusencias_Funcionarios_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Funcionarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrmAusencias_IdColaborador",
                table: "CrmAusencias",
                column: "IdColaborador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "codigos_postais");

            migrationBuilder.DropTable(
                name: "ColaboradorEPIs");

            migrationBuilder.DropTable(
                name: "concelhos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "CRM_ANEXOS");

            migrationBuilder.DropTable(
                name: "CRM_CONCELHO");

            migrationBuilder.DropTable(
                name: "CRM_CONFIG");

            migrationBuilder.DropTable(
                name: "CRM_DISTRITO");

            migrationBuilder.DropTable(
                name: "CRM_EMPRESAS");

            migrationBuilder.DropTable(
                name: "CRM_ENTIDADE");

            migrationBuilder.DropTable(
                name: "CRM_ENTIDADE_META");

            migrationBuilder.DropTable(
                name: "CRM_FALTAS");

            migrationBuilder.DropTable(
                name: "CRM_FERIADOS");

            migrationBuilder.DropTable(
                name: "CRM_FERIAS");

            migrationBuilder.DropTable(
                name: "CRM_HORARIO");

            migrationBuilder.DropTable(
                name: "CRM_MOTIVOSISENCAO");

            migrationBuilder.DropTable(
                name: "CRM_PAISES");

            migrationBuilder.DropTable(
                name: "CRM_PICAGEM");

            migrationBuilder.DropTable(
                name: "CRM_PRAZO_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "CRM_SERIE_DOCUMENTO");

            migrationBuilder.DropTable(
                name: "CRM_TIPO_DOCUMENTO");

            migrationBuilder.DropTable(
                name: "CrmAusencias");

            migrationBuilder.DropTable(
                name: "distritos");

            migrationBuilder.DropTable(
                name: "Epis");

            migrationBuilder.DropTable(
                name: "FuncionarioFerias");

            migrationBuilder.DropTable(
                name: "FuncionarioObraAgendamento");

            migrationBuilder.DropTable(
                name: "NiveisPreco");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_CONDPAGAMENTO");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_ENTIDADES_ERP");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_ESTADOS");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_FRACOES");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_IMOBILIARIAS_OBRA");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_MODOSPAGAMENTO");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_OBRA");

            migrationBuilder.DropTable(
                name: "OSUSR_N2P_PROCESSO");

            migrationBuilder.DropTable(
                name: "TipoTurno");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
