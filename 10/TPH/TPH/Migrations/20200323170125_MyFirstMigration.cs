using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TPH.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Rector = table.Column<string>(nullable: true),
                    StudentsCapacity = table.Column<int>(nullable: false),
                    IsRowByte = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PaintingRoom = table.Column<string>(nullable: true),
                    AnatomyRoom = table.Column<string>(nullable: true),
                    Computers = table.Column<int>(nullable: true),
                    TypeOfLaboratory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
