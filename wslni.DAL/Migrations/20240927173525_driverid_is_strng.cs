using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wslni.DAL.Migrations
{
    /// <inheritdoc />
    public partial class driverid_is_strng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_AspNetUsers_DriverId1",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_DriverId1",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "DriverId1",
                table: "Rides");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Rides",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DriverId",
                table: "Rides",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_AspNetUsers_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_AspNetUsers_DriverId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_DriverId",
                table: "Rides");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Rides",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DriverId1",
                table: "Rides",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DriverId1",
                table: "Rides",
                column: "DriverId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_AspNetUsers_DriverId1",
                table: "Rides",
                column: "DriverId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
