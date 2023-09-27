using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pood.Migrations
{
    /// <inheritdoc />
    public partial class addedPood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avamine = table.Column<TimeSpan>(type: "time", nullable: false),
                    Sulgemine = table.Column<TimeSpan>(type: "time", nullable: false),
                    KuulastusteArv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pood", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pood");
        }
    }
}
