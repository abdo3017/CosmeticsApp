using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "AreaAr",
                table: "shipmentCost");

            migrationBuilder.DropColumn(
                name: "CityAr",
                table: "shipmentCost");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AreaAr",
                table: "Customer_Address");

            migrationBuilder.DropColumn(
                name: "CityAr",
                table: "Customer_Address");

            migrationBuilder.DropColumn(
                name: "CountryAr",
                table: "Customer_Address");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "shipmentCost",
                newName: "Ciry");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryType",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "AttrValueId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "AttributeValues",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries",
                columns: new[] { "Id", "ProductId" });
        }
    }
}
