using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Users",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "CreatedBy",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "CreatedOn",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "EmailId",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "FirstName",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "LastModifiedBy",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "LastName",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "Password",
            //    table: "Users");

            //migrationBuilder.RenameTable(
            //    name: "Users",
            //    newName: "aspnetusers");

            //migrationBuilder.RenameColumn(
            //    name: "LastModifiedOn",
            //    table: "aspnetusers",
            //    newName: "LockoutEnd");

            //migrationBuilder.RenameColumn(
            //    name: "IsDeleted",
            //    table: "aspnetusers",
            //    newName: "TwoFactorEnabled");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Tag",
            //    table: "Products",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ModificationDate",
            //    table: "Products",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreationDate",
            //    table: "Products",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ModificationDate",
            //    table: "Categories",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<bool>(
            //    name: "IsSelected",
            //    table: "Categories",
            //    type: "bit",
            //    nullable: true,
            //    oldClrType: typeof(bool),
            //    oldType: "bit");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreationDate",
            //    table: "Categories",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ModificationDate",
            //    table: "Brands",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreationDate",
            //    table: "Brands",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "date",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Qty",
            //    table: "AttributeValues",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.AddColumn<int>(
            //    name: "AccessFailedCount",
            //    table: "aspnetusers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "ConcurrencyStamp",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Email",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "EmailConfirmed",
            //    table: "aspnetusers",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "LockoutEnabled",
            //    table: "aspnetusers",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "NormalizedEmail",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NormalizedUserName",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PasswordHash",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PhoneNumber",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "PhoneNumberConfirmed",
            //    table: "aspnetusers",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "SecurityStamp",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "UserName",
            //    table: "aspnetusers",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_aspnetusers",
            //    table: "aspnetusers",
            //    column: "Id");

            //migrationBuilder.CreateTable(
            //    name: "Reviews",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Rate = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        ProductId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reviews", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Reviews_aspnetusers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "aspnetusers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reviews_CustomerId",
            //    table: "Reviews",
            //    column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Reviews");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_aspnetusers",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "Qty",
            //    table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "AccessFailedCount",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "ConcurrencyStamp",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "Email",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "EmailConfirmed",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "LockoutEnabled",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "NormalizedEmail",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "NormalizedUserName",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "PasswordHash",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "PhoneNumber",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "PhoneNumberConfirmed",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "SecurityStamp",
            //    table: "aspnetusers");

            //migrationBuilder.DropColumn(
            //    name: "UserName",
            //    table: "aspnetusers");

            //migrationBuilder.RenameTable(
            //    name: "aspnetusers",
            //    newName: "Users");

            //migrationBuilder.RenameColumn(
            //    name: "TwoFactorEnabled",
            //    table: "Users",
            //    newName: "IsDeleted");

            //migrationBuilder.RenameColumn(
            //    name: "LockoutEnd",
            //    table: "Users",
            //    newName: "LastModifiedOn");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Tag",
            //    table: "Products",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ModificationDate",
            //    table: "Products",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreationDate",
            //    table: "Products",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ModificationDate",
            //    table: "Categories",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<bool>(
            //    name: "IsSelected",
            //    table: "Categories",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false,
            //    oldClrType: typeof(bool),
            //    oldType: "bit",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreationDate",
            //    table: "Categories",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ModificationDate",
            //    table: "Brands",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreationDate",
            //    table: "Brands",
            //    type: "date",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<Guid>(
            //    name: "CreatedBy",
            //    table: "Users",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.AddColumn<DateTimeOffset>(
            //    name: "CreatedOn",
            //    table: "Users",
            //    type: "datetimeoffset",
            //    nullable: false,
            //    defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            //migrationBuilder.AddColumn<string>(
            //    name: "EmailId",
            //    table: "Users",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "FirstName",
            //    table: "Users",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "LastModifiedBy",
            //    table: "Users",
            //    type: "uniqueidentifier",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LastName",
            //    table: "Users",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Password",
            //    table: "Users",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Users",
            //    table: "Users",
            //    column: "Id");
        }
    }
}
