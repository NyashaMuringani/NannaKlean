using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NannaKlean.Data.Migrations
{
    /// <inheritdoc />
    public partial class miscitemtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiscItem_ResCleanDetail_ResCleanDetailId",
                table: "MiscItem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MiscItem");

            migrationBuilder.AlterColumn<int>(
                name: "ResCleanDetailId",
                table: "MiscItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "requested",
                table: "MiscItem",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MiscItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscItemType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MiscItem_ResCleanDetail_ResCleanDetailId",
                table: "MiscItem",
                column: "ResCleanDetailId",
                principalTable: "ResCleanDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiscItem_ResCleanDetail_ResCleanDetailId",
                table: "MiscItem");

            migrationBuilder.DropTable(
                name: "MiscItemType");

            migrationBuilder.DropColumn(
                name: "requested",
                table: "MiscItem");

            migrationBuilder.AlterColumn<int>(
                name: "ResCleanDetailId",
                table: "MiscItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MiscItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MiscItem_ResCleanDetail_ResCleanDetailId",
                table: "MiscItem",
                column: "ResCleanDetailId",
                principalTable: "ResCleanDetail",
                principalColumn: "Id");
        }
    }
}
