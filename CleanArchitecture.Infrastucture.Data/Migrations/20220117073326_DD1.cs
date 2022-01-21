using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastucture.Data.Migrations
{
    public partial class DD1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nation",
                table: "Students");
        }
    }
}
