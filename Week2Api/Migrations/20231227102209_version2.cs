using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAkbank.Migrations
{
    /// <inheritdoc />
    public partial class version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "EftTransaction",
                schema: "dbo",
                newName: "EftTransaction");

            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "dbo",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Contact",
                schema: "dbo",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "Address");

            migrationBuilder.RenameTable(
                name: "AccountTransaction",
                schema: "dbo",
                newName: "AccountTransaction");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "dbo",
                newName: "Account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "EftTransaction",
                newName: "EftTransaction",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contact",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AccountTransaction",
                newName: "AccountTransaction",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Account",
                newSchema: "dbo");
        }
    }
}
