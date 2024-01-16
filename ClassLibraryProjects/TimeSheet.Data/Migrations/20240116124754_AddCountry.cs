using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CountryEntity");

            migrationBuilder.DropColumn(
                name: "City",
                table: "CountryEntity");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "CountryEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CountryEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CountryEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "CountryEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
