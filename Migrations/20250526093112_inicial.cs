using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construlink.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avisos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraFim = table.Column<TimeSpan>(type: "time", nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avisos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_AUDITORIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UTILIZADORID = table.Column<int>(type: "int", nullable: true),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPORTAMENTO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_AUDITORIA", x => x.ID);
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
                name: "CRM_UTILIZADOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    USERNAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ISADMIN = table.Column<bool>(type: "bit", nullable: true),
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
                    PIN2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true),
                    NomeTurno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTurno = table.Column<int>(type: "int", nullable: true),
                    IS_SUPER_ADMIN = table.Column<bool>(type: "bit", nullable: true),
                    IsApenasPicagens = table.Column<bool>(type: "bit", nullable: true),
                    IsCliente = table.Column<bool>(type: "bit", nullable: true),
                    IsPromotor = table.Column<bool>(type: "bit", nullable: true),
                    ISVENDEDOR = table.Column<bool>(type: "bit", nullable: true),
                    IsConstrutor = table.Column<bool>(type: "bit", nullable: true),
                    IsGestorObra = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_UTILIZADOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CRM_UTILIZADOR_FACIAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_UTILIZADOR = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BIOMARKERS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_UTILIZADOR_FACIAL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoManutencao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoManutencao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    HoraRetorno = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatchNotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsTitulo = table.Column<bool>(type: "bit", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatchNotes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UtilizadorEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizadorEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilizadorEntidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadeId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizadorEntidade", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avisos");

            migrationBuilder.DropTable(
                name: "CRM_AUDITORIA");

            migrationBuilder.DropTable(
                name: "CRM_CONFIG");

            migrationBuilder.DropTable(
                name: "CRM_EMPRESAS");

            migrationBuilder.DropTable(
                name: "CRM_UTILIZADOR");

            migrationBuilder.DropTable(
                name: "CRM_UTILIZADOR_FACIAL");

            migrationBuilder.DropTable(
                name: "EstadoManutencao");

            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "PatchNotes");

            migrationBuilder.DropTable(
                name: "UtilizadorEmpresa");

            migrationBuilder.DropTable(
                name: "UtilizadorEntidade");
        }
    }
}
