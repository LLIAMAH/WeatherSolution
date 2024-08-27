using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.DB.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "USA" },
                    { 2L, "Great Britain" },
                    { 3L, "Japan" },
                    { 4L, "France" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, 40.7143m, -74.006m, "New York" },
                    { 2L, 1L, 34.0522m, -118.2437m, "Los Angeles" },
                    { 3L, 1L, 47.6062m, -122.3321m, "Seattle" },
                    { 4L, 2L, 51.5085m, -0.1257m, "London" },
                    { 5L, 2L, 52.2m, 0.1167m, "Cambridge" },
                    { 6L, 2L, 51.7522m, -1.256m, "Oxford" },
                    { 7L, 3L, 35.6895m, 139.6917m, "Tokyo" },
                    { 8L, 3L, 35.0211m, 135.7538m, "Kyoto" },
                    { 9L, 4L, 48.8534m, 2.3488m, "Paris" },
                    { 10L, 4L, 43.297m, 5.3811m, "Marseille" },
                    { 11L, 4L, 50.633m, 3.0586m, "Lille" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
