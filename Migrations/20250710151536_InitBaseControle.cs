using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Construlink.Migrations
{
    /// <inheritdoc />
    public partial class InitBaseControle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISVENDEDOR",
                table: "CRM_UTILIZADOR",
                newName: "IsVendedor");

            migrationBuilder.AddColumn<bool>(
                name: "IsFuncionario",
                table: "CRM_UTILIZADOR",
                type: "bit",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CRM_SERIE_DOCUMENTO");

            migrationBuilder.DropColumn(
                name: "IsFuncionario",
                table: "CRM_UTILIZADOR");

            migrationBuilder.RenameColumn(
                name: "IsVendedor",
                table: "CRM_UTILIZADOR",
                newName: "ISVENDEDOR");
        }
    }
}
