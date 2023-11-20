using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    HabitatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biotope = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.HabitatId);
                });

            migrationBuilder.CreateTable(
                name: "Keepers",
                columns: table => new
                {
                    KeeperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Responsibility = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keepers", x => x.KeeperId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeeperId = table.Column<int>(type: "int", nullable: true),
                    HabitatId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "HabitatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Keepers_KeeperId",
                        column: x => x.KeeperId,
                        principalTable: "Keepers",
                        principalColumn: "KeeperId");
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "HabitatId", "Biotope", "Name" },
                values: new object[,]
                {
                    { 1, "Grassland", "Savannah" },
                    { 2, "Tropical", "Rainforest" },
                    { 3, "Arid", "Desert" },
                    { 4, "Polar", "Arctic" },
                    { 5, "Temperate", "Forest" }
                });

            migrationBuilder.InsertData(
                table: "Keepers",
                columns: new[] { "KeeperId", "Name", "Responsibility" },
                values: new object[,]
                {
                    { 101, "John Doe", 8 },
                    { 102, "Jane Smith", 5 },
                    { 103, "Bob Johnson", 7 },
                    { 104, "Alice Brown", 6 },
                    { 105, "Charlie Davis", 9 },
                    { 106, "Emma White", 4 },
                    { 107, "David Black", 6 },
                    { 108, "Eva Green", 8 },
                    { 109, "Frank Lee", 3 },
                    { 110, "Grace Taylor", 7 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "HabitatId", "KeeperId", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 5, 1, 101, "Lion", "Panthera leo" },
                    { 2, 10, 1, 102, "Elephant", "Loxodonta africana" },
                    { 3, 8, 1, 103, "Giraffe", "Giraffa camelopardalis" },
                    { 4, 3, 4, 104, "Penguin", "Spheniscidae" },
                    { 5, 6, 3, 105, "Kangaroo", "Macropodidae" },
                    { 6, 7, 2, 101, "Tiger", "Panthera tigris" },
                    { 7, 4, 2, 102, "Panda", "Ailuropoda melanoleuca" },
                    { 8, 5, 1, 103, "Cheetah", "Acinonyx jubatus" },
                    { 9, 2, 2, 105, "Koala", "Phascolarctos cinereus" },
                    { 10, 12, 2, 104, "Gorilla", "Gorilla" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_HabitatId",
                table: "Animals",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KeeperId",
                table: "Animals",
                column: "KeeperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "Keepers");
        }
    }
}
