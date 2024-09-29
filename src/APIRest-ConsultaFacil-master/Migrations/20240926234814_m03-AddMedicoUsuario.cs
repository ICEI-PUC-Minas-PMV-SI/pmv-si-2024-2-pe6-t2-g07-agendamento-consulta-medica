using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace apirest.Migrations
{
    /// <inheritdoc />
    public partial class m03AddMedicoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Consultas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Especialidade = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CRM = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$OTqfqF/HXVwui7H8nkVI0.E.2aZ6lv0JABayPCRDQ6w4n4/QjxVEm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$zjKyFUyzcitJ6OQnhuOVL.nJK.7jwJ3Noqtf6P2qWz7bcmXj5RljK");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Senha",
                value: "$2a$11$ADk7uQobzMu2vvTBCgQdNOfL4GKJlheAM5Xm88Ex/ZzGI0F9tVxmO");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_UsuarioId",
                table: "Medicos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Consultas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$R6H73LeyMvKlGa8mdE7eCeRw7vaUKUzj4ihcjh6h8181/ufq/gsra");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$IJbJJeMeBg4GlizVAFY1nun7IYTGF6el5yV1/7JNvTNB.4Ng4PWQ2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Senha",
                value: "$2a$11$LOiYLYjrtOag6894qxEIo.fUC2T.rodGCrtSB5z1RUQ3aM9dTwfr.");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
