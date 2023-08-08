using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class addTimestampAndUuidPegawai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "masterpegawai",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "masterpegawai",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "masterpegawai",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "masterpegawai",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_masterpegawai_kodedivisi",
                table: "masterpegawai",
                column: "kodedivisi");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_masterpegawai_masterdivisi_kodedivisi",
            //    table: "masterpegawai",
            //    column: "kodedivisi",
            //    principalTable: "masterdivisi",
            //    principalColumn: "kode",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_masterpegawai_masterdivisi_kodedivisi",
            //    table: "masterpegawai");

            migrationBuilder.DropIndex(
                name: "IX_masterpegawai_kodedivisi",
                table: "masterpegawai");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "masterpegawai");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "masterpegawai");

            migrationBuilder.DropColumn(
                name: "id",
                table: "masterpegawai");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "masterpegawai");
        }
    }
}
