using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task.ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class FixConflictPKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategories_AppCategories_ParentCategoryId1",
                table: "AppCategories");

            migrationBuilder.DropIndex(
                name: "IX_AppCategories_ParentCategoryId1",
                table: "AppCategories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId1",
                table: "AppCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategoryId1",
                table: "AppCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }
    }
}
