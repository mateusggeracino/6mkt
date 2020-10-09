using Microsoft.EntityFrameworkCore.Migrations;

namespace _6MKT.BackOffice.Infra.Migrations
{
    public partial class addstatuspurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "backoffice",
                table: "Purchase",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "backoffice",
                table: "Purchase");
        }
    }
}
