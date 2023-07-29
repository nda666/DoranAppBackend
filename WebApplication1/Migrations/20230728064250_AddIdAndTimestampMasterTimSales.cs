using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddIdAndTimestampMasterTimSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "mastertimsales",
                type: "datetime(6)",
                nullable: true
                );

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "mastertimsales",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "mastertimsales",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "mastertimsales",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "mastertimsales");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "mastertimsales");

            migrationBuilder.DropColumn(
                name: "id",
                table: "mastertimsales");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "mastertimsales");

            migrationBuilder.RenameColumn(
                name: "aktif",
                table: "masterchannelsales",
                newName: "Aktif");
        }
    }
}
