using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesManagementApp.Core.Migrations
{
    public partial class AddDBErrorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBErrors",
                columns: table => new
                {
                    ErrorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    ErrorNumber = table.Column<int>(nullable: false),
                    ErrorState = table.Column<int>(nullable: false),
                    ErrorSeverity = table.Column<int>(nullable: false),
                    ErrorLine = table.Column<int>(nullable: false),
                    ErrorProcedure = table.Column<string>(nullable: true),
                    ErrorMessage = table.Column<string>(nullable: true),
                    ErrorDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBErrors", x => x.ErrorID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBErrors");
        }
    }
}
