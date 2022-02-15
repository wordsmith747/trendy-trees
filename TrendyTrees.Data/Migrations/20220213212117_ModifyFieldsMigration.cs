using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyTrees.Data.Migrations
{
    public partial class ModifyFieldsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CustomerInquiries");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CustomerInquiries");

            migrationBuilder.AddColumn<DateTime>(
                name: "InquiryDate",
                table: "CustomerInquiries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CustomerInquiries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CustomerInquiries",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InquiryDate",
                table: "CustomerInquiries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CustomerInquiries");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CustomerInquiries");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CustomerInquiries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CustomerInquiries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
