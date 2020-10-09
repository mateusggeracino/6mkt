using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _6MKT.BackOffice.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "backoffice");

            migrationBuilder.CreateTable(
                name: "Business",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    RegisteredNumber = table.Column<string>(maxLength: 20, nullable: true),
                    TradeName = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPerson",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    SocialNumber = table.Column<string>(maxLength: 14, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "backoffice",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    AveragePrice = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SubCategoryId = table.Column<long>(nullable: false),
                    NaturalPersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_NaturalPerson_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalSchema: "backoffice",
                        principalTable: "NaturalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalSchema: "backoffice",
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    InStock = table.Column<bool>(nullable: false),
                    PurchaseId = table.Column<long>(nullable: false),
                    BusinessId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalSchema: "backoffice",
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "backoffice",
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt" },
                values: new object[] { 1L, null, "Casa, Móveis e Decoração", null });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt" },
                values: new object[] { 2L, null, "Celulares e Telefones", null });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt" },
                values: new object[] { 3L, null, "Games", null });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "SubCategory",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ModifiedAt" },
                values: new object[,]
                {
                    { 1L, 1L, null, "Banheiros", null },
                    { 2L, 1L, null, "Colchões e Camas Box", null },
                    { 3L, 1L, null, "Cortinas e Acessórios", null },
                    { 4L, 1L, null, "Móveis para Casa", null },
                    { 5L, 2L, null, "Acessórios para Celulares", null },
                    { 6L, 2L, null, "Celulares e Smartphones", null },
                    { 7L, 2L, null, "Tarifadores e Cabines", null },
                    { 8L, 3L, null, "Consoles", null },
                    { 9L, 3L, null, "Peças para Consoles", null },
                    { 10L, 3L, null, "Acessórios para PC Gaming", null },
                    { 11L, 3L, null, "Video Games", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_BusinessId",
                schema: "backoffice",
                table: "Offer",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_PurchaseId",
                schema: "backoffice",
                table: "Offer",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_NaturalPersonId",
                schema: "backoffice",
                table: "Purchase",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SubCategoryId",
                schema: "backoffice",
                table: "Purchase",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                schema: "backoffice",
                table: "SubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Business",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Purchase",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "NaturalPerson",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "SubCategory",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "backoffice");
        }
    }
}
