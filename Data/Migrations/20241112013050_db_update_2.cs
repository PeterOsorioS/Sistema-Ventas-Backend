using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class db_update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "permissions_blocked");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "products",
                newName: "stock");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "products",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "products",
                newName: "creation_date");

            migrationBuilder.RenameColumn(
                name: "CodeQR",
                table: "products",
                newName: "code_qr");

            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "products",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                table: "products",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "code_qr",
                table: "products",
                newName: "CodeQR");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "permissions_blocked",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
