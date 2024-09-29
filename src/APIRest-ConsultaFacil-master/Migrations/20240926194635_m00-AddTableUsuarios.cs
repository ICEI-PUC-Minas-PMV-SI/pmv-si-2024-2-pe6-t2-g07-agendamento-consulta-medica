using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apirest.Migrations
{
    /// <inheritdoc />
    public partial class m00AddTableUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sexo = table.Column<int>(type: "integer", nullable: true),
                    Perfil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CPF", "DataNascimento", "Email", "Nome", "Perfil", "Senha", "Sexo", "Telefone" },
                values: new object[,]
                {
                    { 1, "12345678910", null, "admin@email.com.br", "Administrador", 0, "$2a$11$gP7CM.7s53TCgepY6K/ysuxbgQsS3uhzGHUkO3HWMqxycwfqQWgI2", 1, "31990000000" },
                    { 2, "12345678911", null, "medico@email.com.br", "Medico", 1, "$2a$11$pHhh3nDhuouMfuE.XDOzLuEloK.rgISFttICa8PHtZTqJxmxh4fkO", 1, "31990000001" },
                    { 3, "12345678912", null, "paciente@email.com.br", "Paciente", 2, "$2a$11$O0fWQlVCgNlJS/xjVjb64eDMTrvRpc84plTgSV5P90oJOn016NmCu", null, "31990000002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
