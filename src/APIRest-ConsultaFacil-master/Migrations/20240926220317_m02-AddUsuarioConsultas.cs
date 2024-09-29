using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apirest.Migrations
{
    /// <inheritdoc />
    public partial class m02AddUsuarioConsultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Consultas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Consultas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$y25Z7A6Qyy58Pom8O4Q8b.58phPwhPs9mSkZ2s2xjWQeAoPQ4kv9a");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$0BmLuqFeXnyoz8WZO5dI.OMOFZwgHp9JomI04GAuAvevzfz0rz5oq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Senha",
                value: "$2a$11$Om.TUJXO4ES8ZD098ydQzuE91AaaEfDi/us6K.nYaQmHrFNnWu8Di");
        }
    }
}
