using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EducationMigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreationDate", "Description", "Price", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2c21902a-2bb4-4ab3-8281-783fb9a53cde"), new DateTime(2023, 6, 7, 8, 7, 6, 984, DateTimeKind.Local).AddTicks(5444), "Basic C# course", 56m, new DateTime(2025, 6, 7, 8, 7, 6, 984, DateTimeKind.Local).AddTicks(5465), "C# from zero to hero" },
                    { new Guid("3feff5f0-64fb-4ba4-9686-4f01cf43476c"), new DateTime(2023, 6, 7, 8, 7, 6, 984, DateTimeKind.Local).AddTicks(5553), "Basic Java course", 46m, new DateTime(2024, 6, 7, 8, 7, 6, 984, DateTimeKind.Local).AddTicks(5555), "Java from zero to hero" },
                    { new Guid("c2c5352d-e4fe-4038-826c-5d2cef00fe35"), new DateTime(2023, 6, 7, 8, 7, 6, 984, DateTimeKind.Local).AddTicks(5596), "Basic unit testing course for .NET", 35m, new DateTime(2025, 6, 7, 8, 7, 6, 984, DateTimeKind.Local).AddTicks(5598), "XUnit from zero to hero" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
