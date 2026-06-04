using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task.ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "AppProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "AppProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategoryId1",
                table: "AppCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_CategoryId1",
                table: "AppProducts",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppCategories_ParentCategoryId1",
                table: "AppCategories",
                column: "ParentCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCategories_AppCategories_ParentCategoryId1",
                table: "AppCategories",
                column: "ParentCategoryId1",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppCategories_CategoryId1",
                table: "AppProducts",
                column: "CategoryId1",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategories_AppCategories_ParentCategoryId1",
                table: "AppCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppCategories_CategoryId1",
                table: "AppProducts");

            migrationBuilder.DropIndex(
                name: "IX_AppProducts_CategoryId1",
                table: "AppProducts");

            migrationBuilder.DropIndex(
                name: "IX_AppCategories_ParentCategoryId1",
                table: "AppCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId1",
                table: "AppCategories");
        }
    }
}
