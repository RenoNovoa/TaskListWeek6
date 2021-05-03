using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstonTask.Data.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ToDos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDos");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
