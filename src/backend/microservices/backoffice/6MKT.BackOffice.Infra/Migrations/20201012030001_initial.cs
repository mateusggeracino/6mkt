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
                    CreatedId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedId = table.Column<long>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
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
                    CreatedId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedId = table.Column<long>(nullable: true),
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
                    CreatedId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedId = table.Column<long>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
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
                    CreatedId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedId = table.Column<long>(nullable: true),
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
                    CreatedId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedId = table.Column<long>(nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(nullable: true),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    AveragePrice = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<long>(nullable: false),
                    NaturalPersonEntityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_NaturalPerson_NaturalPersonEntityId",
                        column: x => x.NaturalPersonEntityId,
                        principalSchema: "backoffice",
                        principalTable: "NaturalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CreatedId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedId = table.Column<long>(nullable: true),
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
                columns: new[] { "Id", "CreatedAt", "CreatedId", "Description", "ModifiedAt", "ModifiedId" },
                values: new object[] { 1L, null, null, "Casa, Móveis e Decoração", null, null });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedId", "Description", "ModifiedAt", "ModifiedId" },
                values: new object[] { 2L, null, null, "Celulares e Telefones", null, null });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "CreatedId", "Description", "ModifiedAt", "ModifiedId" },
                values: new object[] { 3L, null, null, "Games", null, null });

            migrationBuilder.InsertData(
                schema: "backoffice",
                table: "SubCategory",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedId", "Description", "ModifiedAt", "ModifiedId" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, "Banheiros", null, null },
                    { 2L, 1L, null, null, "Colchões e Camas Box", null, null },
                    { 3L, 1L, null, null, "Cortinas e Acessórios", null, null },
                    { 4L, 1L, null, null, "Móveis para Casa", null, null },
                    { 5L, 2L, null, null, "Acessórios para Celulares", null, null },
                    { 6L, 2L, null, null, "Celulares e Smartphones", null, null },
                    { 7L, 2L, null, null, "Tarifadores e Cabines", null, null },
                    { 8L, 3L, null, null, "Consoles", null, null },
                    { 9L, 3L, null, null, "Peças para Consoles", null, null },
                    { 10L, 3L, null, null, "Acessórios para PC Gaming", null, null },
                    { 11L, 3L, null, null, "Video Games", null, null }
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
                name: "IX_Purchase_NaturalPersonEntityId",
                schema: "backoffice",
                table: "Purchase",
                column: "NaturalPersonEntityId");

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
