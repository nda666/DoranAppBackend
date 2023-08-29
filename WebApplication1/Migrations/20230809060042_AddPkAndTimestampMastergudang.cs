using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddPkAndTimestampMastergudang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "kode",
            table: "mastergudang",
            type: "int(11)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int(11)")
            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<short>(
                name: "boletransit",
                table: "mastergudang",
                type: "smallint(1)",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(short),
                oldType: "smallint(1)",
                oldDefaultValueSql: "'1'");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "mastergudang",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "mastergudang",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "mastergudang",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "mastergudang",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "kode",
            table: "mastergudang",
            type: "int(11)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int(11)");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "mastergudang");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "mastergudang");

            migrationBuilder.DropColumn(
                name: "id",
                table: "mastergudang");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "mastergudang");

            migrationBuilder.AlterColumn<short>(
                name: "boletransit",
                table: "mastergudang",
                type: "smallint(1)",
                nullable: false,
                defaultValueSql: "'1'",
                oldClrType: typeof(short),
                oldType: "smallint(1)",
                oldNullable: true,
                oldDefaultValueSql: "'1'");
        }
    }
}
