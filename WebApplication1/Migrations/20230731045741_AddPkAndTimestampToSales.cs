using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddPkAndTimestampToSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "kodemanager",
               table: "sales",
              oldType: "tinyint(4)",
              nullable: false,
              oldClrType: typeof(sbyte),
             type: "int(11)"
            );
           
           
            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "sales",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");


            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "sales",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
               name: "updated_at",
               table: "sales",
               type: "datetime(6)",
               nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "sales",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_masteruser_kodesales",
                table: "masteruser",
                column: "kodesales",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_mastertimsales_kodetimsales",
                table: "sales",
                column: "kodetimsales",
                principalTable: "mastertimsales",
                principalColumn: "kode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_sales_kodemanager",
                table: "sales",
                column: "kodemanager");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                 name: "IX_sales_kodemanager",
                table: "sales"
                );

            migrationBuilder.DropForeignKey(
                name: "FK_sales_mastertimsales_kodetimsales",
                table: "sales");

            migrationBuilder.DropIndex(
                name: "IX_masteruser_kodesales",
                table: "masteruser");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "id",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "sales");

            migrationBuilder.AlterColumn<sbyte>(
                    name: "kodesales",
            table: "masteruser",
            oldType: "tinyint(4)",
            nullable: false,
            oldClrType: typeof(sbyte),
            type: "int(11)"
          );
        }
    }
}
