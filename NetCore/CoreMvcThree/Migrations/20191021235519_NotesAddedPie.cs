using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMvcThree.Migrations
{
    public partial class NotesAddedPie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Pies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Pies");
        }
    }
}
