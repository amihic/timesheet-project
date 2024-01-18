using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "LeadId",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectEntityUserEntity",
                columns: table => new
                {
                    ProjectsWorkingOnId = table.Column<int>(type: "integer", nullable: false),
                    UsersWorkingOnId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEntityUserEntity", x => new { x.ProjectsWorkingOnId, x.UsersWorkingOnId });
                    table.ForeignKey(
                        name: "FK_ProjectEntityUserEntity_Projects_ProjectsWorkingOnId",
                        column: x => x.ProjectsWorkingOnId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEntityUserEntity_Users_UsersWorkingOnId",
                        column: x => x.UsersWorkingOnId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEntityUserEntity_UsersWorkingOnId",
                table: "ProjectEntityUserEntity",
                column: "UsersWorkingOnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectEntityUserEntity");

            migrationBuilder.AlterColumn<int>(
                name: "LeadId",
                table: "Projects",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_LeadId",
                table: "Projects",
                column: "LeadId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
