using Microsoft.EntityFrameworkCore.Migrations;

namespace _6MKT.BackOffice.Infra.Migrations
{
    public partial class removenaturalperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_NaturalPerson_NaturalPersonId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_NaturalPersonId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "NaturalPersonId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.AddColumn<long>(
                name: "CreatedId",
                schema: "backoffice",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedId",
                schema: "backoffice",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedId",
                schema: "backoffice",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedId",
                schema: "backoffice",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Offer",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedId",
                schema: "backoffice",
                table: "NaturalPerson",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedId",
                schema: "backoffice",
                table: "NaturalPerson",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedId",
                schema: "backoffice",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedId",
                schema: "backoffice",
                table: "Business",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Business",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase",
                column: "NaturalPersonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_NaturalPerson_NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase",
                column: "NaturalPersonEntityId",
                principalSchema: "backoffice",
                principalTable: "NaturalPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_NaturalPerson_NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                schema: "backoffice",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                schema: "backoffice",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                schema: "backoffice",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                schema: "backoffice",
                table: "NaturalPerson");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                schema: "backoffice",
                table: "NaturalPerson");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                schema: "backoffice",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                schema: "backoffice",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                schema: "backoffice",
                table: "Business");

            migrationBuilder.AddColumn<long>(
                name: "NaturalPersonId",
                schema: "backoffice",
                table: "Purchase",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_NaturalPersonId",
                schema: "backoffice",
                table: "Purchase",
                column: "NaturalPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_NaturalPerson_NaturalPersonId",
                schema: "backoffice",
                table: "Purchase",
                column: "NaturalPersonId",
                principalSchema: "backoffice",
                principalTable: "NaturalPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
