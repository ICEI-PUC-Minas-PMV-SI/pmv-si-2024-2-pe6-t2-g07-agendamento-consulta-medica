using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace apirest.Migrations
{
    /// <inheritdoc />
    public partial class m01AddTableConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataConsulta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraConsulta = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$gP7CM.7s53TCgepY6K/ysuxbgQsS3uhzGHUkO3HWMqxycwfqQWgI2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$pHhh3nDhuouMfuE.XDOzLuEloK.rgISFttICa8PHtZTqJxmxh4fkO");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "Senha",
                value: "$2a$11$O0fWQlVCgNlJS/xjVjb64eDMTrvRpc84plTgSV5P90oJOn016NmCu");
        }
    }
}
