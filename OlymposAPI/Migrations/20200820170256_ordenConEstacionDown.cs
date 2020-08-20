using Microsoft.EntityFrameworkCore.Migrations;

namespace OlymposAPI.Migrations
{
    public partial class ordenConEstacionDown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Estaciones_EstacionesID",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_EstacionesID",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "EstacionesID",
                table: "Ordenes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstacionesID",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EstacionesID",
                table: "Ordenes",
                column: "EstacionesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Estaciones_EstacionesID",
                table: "Ordenes",
                column: "EstacionesID",
                principalTable: "Estaciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
