using Microsoft.EntityFrameworkCore.Migrations;

namespace OlymposAPI.Migrations
{
    public partial class isAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FondoDeCaja",
                table: "Gavetas");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "TiposUsuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperAdmin",
                table: "TiposUsuarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "TiposUsuarios");

            migrationBuilder.DropColumn(
                name: "IsSuperAdmin",
                table: "TiposUsuarios");

            migrationBuilder.AddColumn<int>(
                name: "FondoDeCaja",
                table: "Gavetas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
