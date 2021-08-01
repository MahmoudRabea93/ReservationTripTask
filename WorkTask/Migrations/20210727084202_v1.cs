using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkTask.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_tripID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "tripID",
                table: "Reservations",
                newName: "TripID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_tripID",
                table: "Reservations",
                newName: "IX_Reservations_TripID");

            migrationBuilder.AlterColumn<int>(
                name: "TripID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_TripID",
                table: "Reservations",
                column: "TripID",
                principalTable: "Trips",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_TripID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TripID",
                table: "Reservations",
                newName: "tripID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TripID",
                table: "Reservations",
                newName: "IX_Reservations_tripID");

            migrationBuilder.AlterColumn<int>(
                name: "tripID",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_tripID",
                table: "Reservations",
                column: "tripID",
                principalTable: "Trips",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
