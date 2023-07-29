using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class addPKtoUserAndChannelSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql("ALTER TABLE masterchannelsales ADD CONSTRAINT PK_masterchannelsales PRIMARY KEY(kode)");

            migrationBuilder.Sql("ALTER TABLE masteruser ADD CONSTRAINT PK_masteruser PRIMARY KEY(kodeku)");

            migrationBuilder.AlterColumn<int>(
               name: "kodeku",
               table: "masteruser",
               type: "int(11)",
               nullable: false,
               oldClrType: typeof(int),
               oldType: "int(11)")
               .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                 name: "id",
                table: "masteruser",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "masteruser",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "masteruser",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "masteruser",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                 name: "id",
                table: "masterchannelsales",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");


            migrationBuilder.AlterColumn<int>(
                name: "kode",
                table: "masterchannelsales",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "masterchannelsales",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "masterchannelsales",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "masterchannelsales",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(table: "masterchannelsales", name: "PK_masterchannelsales");
            migrationBuilder.DropPrimaryKey(table: "masteruser", name: "PK_masteruser");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "masteruser");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "masteruser");

            migrationBuilder.DropColumn(
                name: "id",
                table: "masteruser");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "masteruser");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "masterchannelsales");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "masterchannelsales");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "masterchannelsales");

            migrationBuilder.AlterColumn<int>(
                name: "kode",
                table: "masterchannelsales",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}
