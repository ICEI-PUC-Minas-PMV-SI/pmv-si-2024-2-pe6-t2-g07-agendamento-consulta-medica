using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apirest.Migrations
{
    /// <inheritdoc />
    public partial class m04AddMedicoConsultas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Consultas",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$eEewv2vkCuO6hGovJqQnIO.K15pHyrpCq0CsbnrID6oPzpTsumndi");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$QjGSqJ8EMcRMeckuP5mdWeM2Ec6KPcdp7RD9RAXd8agPhZ/1vUMom");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Senha",
                value: "$2a$11$ZUGPYvx2//pmFRKOnCgcHuyNloTj6dDfafI9apTjjRTQdZZ2vTjH2");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoId",
                table: "Consultas",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_MedicoId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Consultas");

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
        }
    }
}
