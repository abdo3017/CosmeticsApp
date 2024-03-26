using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Status",
            //    table: "Users");

            //migrationBuilder.RenameColumn(
            //    name: "ChildId",
            //    table: "Categories",
            //    newName: "ParentId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "Users",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "BrandId",
            //    table: "Products",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "TagName",
            //    table: "Products",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerId",
            //    table: "Orders",
            //    type: "int",
            //    maxLength: 455,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(455)",
            //    oldMaxLength: 455);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsSelected",
            //    table: "Categories",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerId",
            //    table: "Carts",
            //    type: "int",
            //    maxLength: 455,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(455)",
            //    oldMaxLength: 455);

            //migrationBuilder.AddColumn<byte[]>(
            //    name: "Image",
            //    table: "Brands",
            //    type: "varbinary(max)",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Advertisements",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
            //        TagName = table.Column<int>(type: "int", nullable: true),
            //        BrandId = table.Column<int>(type: "int", nullable: true),
            //        CategoryId = table.Column<int>(type: "int", nullable: true),
            //        Discount = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Advertisements", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.AppUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Galleries_ProductId",
            //    table: "Galleries",
            //    column: "ProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Galleries_Products_ProductId",
            //    table: "Galleries",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Galleries_Products_ProductId",
            //    table: "Galleries");

            //migrationBuilder.DropTable(
            //    name: "Advertisements");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            //migrationBuilder.DropIndex(
            //    name: "IX_Galleries_ProductId",
            //    table: "Galleries");

            //migrationBuilder.DropColumn(
            //    name: "TagName",
            //    table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "IsSelected",
            //    table: "Categories");

            //migrationBuilder.DropColumn(
            //    name: "Image",
            //    table: "Brands");

            //migrationBuilder.RenameColumn(
            //    name: "ParentId",
            //    table: "Categories",
            //    newName: "ChildId");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "Id",
            //    table: "Users",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<int>(
            //    name: "Status",
            //    table: "Users",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AlterColumn<int>(
            //    name: "BrandId",
            //    table: "Products",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<string>(
            //    name: "CustomerId",
            //    table: "Orders",
            //    type: "nvarchar(455)",
            //    maxLength: 455,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldMaxLength: 455);

            //migrationBuilder.AlterColumn<string>(
            //    name: "CustomerId",
            //    table: "Carts",
            //    type: "nvarchar(455)",
            //    maxLength: 455,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldMaxLength: 455);
        }
    }
}
