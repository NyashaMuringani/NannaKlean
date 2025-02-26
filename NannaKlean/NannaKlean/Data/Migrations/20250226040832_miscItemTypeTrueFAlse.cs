using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NannaKlean.Data.Migrations
{
    /// <inheritdoc />
    public partial class miscItemTypeTrueFAlse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "requested",
                table: "MiscItemType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_MiscItem_MiscItemTypeId",
                table: "MiscItem",
                column: "MiscItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MiscItem_MiscItemType_MiscItemTypeId",
                table: "MiscItem",
                column: "MiscItemTypeId",
                principalTable: "MiscItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiscItem_MiscItemType_MiscItemTypeId",
                table: "MiscItem");

            migrationBuilder.DropIndex(
                name: "IX_MiscItem_MiscItemTypeId",
                table: "MiscItem");

            migrationBuilder.DropColumn(
                name: "requested",
                table: "MiscItemType");
        }
    }
}
