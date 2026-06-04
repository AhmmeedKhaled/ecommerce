using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task.ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class FixProductCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppCategories_CategoryId1",
                table: "AppProducts");

            migrationBuilder.DropIndex(
                name: "IX_AppProducts_CategoryId1",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "AppProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "AppProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_CategoryId1",
                table: "AppProducts",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppCategories_CategoryId1",
                table: "AppProducts",
                column: "CategoryId1",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
