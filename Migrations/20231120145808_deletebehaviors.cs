using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class deletebehaviors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Habitats_HabitatId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Keepers_KeeperId",
                table: "Animals");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Habitats_HabitatId",
                table: "Animals",
                column: "HabitatId",
                principalTable: "Habitats",
                principalColumn: "HabitatId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Keepers_KeeperId",
                table: "Animals",
                column: "KeeperId",
                principalTable: "Keepers",
                principalColumn: "KeeperId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Habitats_HabitatId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Keepers_KeeperId",
                table: "Animals");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Habitats_HabitatId",
                table: "Animals",
                column: "HabitatId",
                principalTable: "Habitats",
                principalColumn: "HabitatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Keepers_KeeperId",
                table: "Animals",
                column: "KeeperId",
                principalTable: "Keepers",
                principalColumn: "KeeperId");
        }
    }
}
