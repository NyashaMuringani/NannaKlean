using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NannaKlean.Data.Migrations
{
    /// <inheritdoc />
    public partial class rescleandetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResCleanDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numLivingRooms = table.Column<int>(type: "int", nullable: false),
                    numBedrooms = table.Column<int>(type: "int", nullable: false),
                    numBathRooms = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResCleanDetail", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResCleanDetail");
        }
    }
}
