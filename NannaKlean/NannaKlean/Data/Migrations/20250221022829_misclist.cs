using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NannaKlean.Data.Migrations
{
    /// <inheritdoc />
    public partial class misclist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiscItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResCleanDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiscItem_ResCleanDetail_ResCleanDetailId",
                        column: x => x.ResCleanDetailId,
                        principalTable: "ResCleanDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiscItem_ResCleanDetailId",
                table: "MiscItem",
                column: "ResCleanDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiscItem");
        }
    }
}
