using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SmsSender.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SendDB");

            migrationBuilder.CreateTable(
                name: "Response",
                schema: "SendDB",
                columns: table => new
                {
                    idR = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Response_pkey", x => x.idR);
                });

            migrationBuilder.CreateTable(
                name: "Senders",
                schema: "SendDB",
                columns: table => new
                {
                    idS = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    login = table.Column<string>(type: "character varying", nullable: true),
                    password = table.Column<string>(type: "character varying", nullable: true),
                    source = table.Column<string>(type: "character varying", nullable: true),
                    phone = table.Column<string>(type: "character varying", nullable: true),
                    text = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Senders_pkey", x => x.idS);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response",
                schema: "SendDB");

            migrationBuilder.DropTable(
                name: "Senders",
                schema: "SendDB");
        }
    }
}
