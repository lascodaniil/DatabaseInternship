using Microsoft.EntityFrameworkCore.Migrations;

namespace APP.Migrations
{
    public partial class gfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    RestaurantType = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Capacity", "City", "RestaurantName", "RestaurantType", "Street" },
                values: new object[,]
                {
                    { 1, 150, "Chisinau", "Mi Piace", "Italian", "str.Miron Costin" },
                    { 2, 10, "Chisinau", "Meat House", "Moldavian", "str.Ismail" },
                    { 3, 50, "Chisinau", "Star Kebab", "Fast-Food", "bd.Moscova" },
                    { 4, 15, "Chisinau", "Twistter", "Fast-Food", "bd.Moscova" },
                    { 5, 50, "Chisinau", "Andys Pizza", "Fast-Food", "str.Ceucari" },
                    { 6, 150, "Chisinau", "Versenz", "Wedding", "bd.Moscova" },
                    { 7, 250, "Chisinau", "Capitoles Park", "Wedding", "db.Decebal" },
                    { 8, 70, "Chisinau", "Oasis", "Turkish", "bd.Stefan cel Mare" },
                    { 9, 150, "Chisinau", "Eleganace", "Wedding", "str.Ceucari" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
