using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSConstruct.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBHDD_DBHDDsDBHDDId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBPowerUnit_DBPowerUnitsDBPowerUnitId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBRAM_DBRAMsDBRAMId",
                table: "Configs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBRAM",
                table: "DBRAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBPowerUnit",
                table: "DBPowerUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBHDD",
                table: "DBHDD");

            migrationBuilder.RenameTable(
                name: "DBRAM",
                newName: "DBRAMs");

            migrationBuilder.RenameTable(
                name: "DBPowerUnit",
                newName: "DBPowerUnits");

            migrationBuilder.RenameTable(
                name: "DBHDD",
                newName: "DBHDDs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBRAMs",
                table: "DBRAMs",
                column: "DBRAMId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBPowerUnits",
                table: "DBPowerUnits",
                column: "DBPowerUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBHDDs",
                table: "DBHDDs",
                column: "DBHDDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBHDDs_DBHDDsDBHDDId",
                table: "Configs",
                column: "DBHDDsDBHDDId",
                principalTable: "DBHDDs",
                principalColumn: "DBHDDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBPowerUnits_DBPowerUnitsDBPowerUnitId",
                table: "Configs",
                column: "DBPowerUnitsDBPowerUnitId",
                principalTable: "DBPowerUnits",
                principalColumn: "DBPowerUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBRAMs_DBRAMsDBRAMId",
                table: "Configs",
                column: "DBRAMsDBRAMId",
                principalTable: "DBRAMs",
                principalColumn: "DBRAMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBHDDs_DBHDDsDBHDDId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBPowerUnits_DBPowerUnitsDBPowerUnitId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBRAMs_DBRAMsDBRAMId",
                table: "Configs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBRAMs",
                table: "DBRAMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBPowerUnits",
                table: "DBPowerUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DBHDDs",
                table: "DBHDDs");

            migrationBuilder.RenameTable(
                name: "DBRAMs",
                newName: "DBRAM");

            migrationBuilder.RenameTable(
                name: "DBPowerUnits",
                newName: "DBPowerUnit");

            migrationBuilder.RenameTable(
                name: "DBHDDs",
                newName: "DBHDD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBRAM",
                table: "DBRAM",
                column: "DBRAMId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBPowerUnit",
                table: "DBPowerUnit",
                column: "DBPowerUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBHDD",
                table: "DBHDD",
                column: "DBHDDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBHDD_DBHDDsDBHDDId",
                table: "Configs",
                column: "DBHDDsDBHDDId",
                principalTable: "DBHDD",
                principalColumn: "DBHDDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBPowerUnit_DBPowerUnitsDBPowerUnitId",
                table: "Configs",
                column: "DBPowerUnitsDBPowerUnitId",
                principalTable: "DBPowerUnit",
                principalColumn: "DBPowerUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBRAM_DBRAMsDBRAMId",
                table: "Configs",
                column: "DBRAMsDBRAMId",
                principalTable: "DBRAM",
                principalColumn: "DBRAMId");
        }
    }
}
