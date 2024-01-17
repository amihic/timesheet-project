using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_CountryEntity_CountryId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryEntity",
                table: "CountryEntity");

            migrationBuilder.RenameTable(
                name: "CountryEntity",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Countries_CountryId",
                table: "Clients",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Countries_CountryId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "CountryEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryEntity",
                table: "CountryEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_CountryEntity_CountryId",
                table: "Clients",
                column: "CountryId",
                principalTable: "CountryEntity",
                principalColumn: "Id");
        }
    }
}
