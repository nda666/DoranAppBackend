using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddPKtoMastertimsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
              name: "kode",
              table: "mastertimsales",
              type: "tinyint(4)",
              nullable: false,
              oldClrType: typeof(sbyte),
              oldType: "tinyint(4)")
              .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_mastertimsales_kodechannel",
                table: "mastertimsales",
                column: "kodechannel");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_mastertimsales_masterchannelsales_kodechannel",
            //    table: "mastertimsales",
            //    column: "kodechannel",
            //    principalTable: "masterchannelsales",
            //    principalColumn: "kode",
            //    onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
              name: "kode",
              table: "mastertimsales",
              type: "sbyte(4)",
              nullable: false,
              oldClrType: typeof(sbyte),
              oldType: "sbyte(4)");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_mastertimsales_masterchannelsales_kodechannel",
            //    table: "mastertimsales");

            migrationBuilder.DropIndex(
                name: "IX_mastertimsales_kodechannel",
                table: "mastertimsales");
        }
    }
}
