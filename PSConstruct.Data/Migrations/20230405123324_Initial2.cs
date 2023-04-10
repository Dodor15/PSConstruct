using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSConstruct.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BDMotherBoards_Configs_ConfigId",
                table: "BDMotherBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_DBCPUs_Configs_ConfigId",
                table: "DBCPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_DBGPUs_Configs_ConfigId",
                table: "DBGPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_DBHDD_Configs_ConfigId",
                table: "DBHDD");

            migrationBuilder.DropForeignKey(
                name: "FK_DBPowerUnit_Configs_ConfigId",
                table: "DBPowerUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_DBRAM_Configs_ConfigId",
                table: "DBRAM");

            migrationBuilder.DropIndex(
                name: "IX_DBRAM_ConfigId",
                table: "DBRAM");

            migrationBuilder.DropIndex(
                name: "IX_DBPowerUnit_ConfigId",
                table: "DBPowerUnit");

            migrationBuilder.DropIndex(
                name: "IX_DBHDD_ConfigId",
                table: "DBHDD");

            migrationBuilder.DropIndex(
                name: "IX_DBGPUs_ConfigId",
                table: "DBGPUs");

            migrationBuilder.DropIndex(
                name: "IX_DBCPUs_ConfigId",
                table: "DBCPUs");

            migrationBuilder.DropIndex(
                name: "IX_BDMotherBoards_ConfigId",
                table: "BDMotherBoards");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "DBRAM");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "DBPowerUnit");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "DBHDD");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "DBGPUs");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "DBCPUs");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "BDMotherBoards");

            migrationBuilder.AddColumn<int>(
                name: "BDMotherBoardsBDMotherBoardId",
                table: "Configs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DBCPUsDBCPUId",
                table: "Configs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DBGPUsDBGPUId",
                table: "Configs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DBHDDsDBHDDId",
                table: "Configs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DBPowerUnitsDBPowerUnitId",
                table: "Configs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DBRAMsDBRAMId",
                table: "Configs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configs_BDMotherBoardsBDMotherBoardId",
                table: "Configs",
                column: "BDMotherBoardsBDMotherBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBCPUsDBCPUId",
                table: "Configs",
                column: "DBCPUsDBCPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBGPUsDBGPUId",
                table: "Configs",
                column: "DBGPUsDBGPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBHDDsDBHDDId",
                table: "Configs",
                column: "DBHDDsDBHDDId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBPowerUnitsDBPowerUnitId",
                table: "Configs",
                column: "DBPowerUnitsDBPowerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_DBRAMsDBRAMId",
                table: "Configs",
                column: "DBRAMsDBRAMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_BDMotherBoards_BDMotherBoardsBDMotherBoardId",
                table: "Configs",
                column: "BDMotherBoardsBDMotherBoardId",
                principalTable: "BDMotherBoards",
                principalColumn: "BDMotherBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBCPUs_DBCPUsDBCPUId",
                table: "Configs",
                column: "DBCPUsDBCPUId",
                principalTable: "DBCPUs",
                principalColumn: "DBCPUId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configs_DBGPUs_DBGPUsDBGPUId",
                table: "Configs",
                column: "DBGPUsDBGPUId",
                principalTable: "DBGPUs",
                principalColumn: "DBGPUId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configs_BDMotherBoards_BDMotherBoardsBDMotherBoardId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBCPUs_DBCPUsDBCPUId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBGPUs_DBGPUsDBGPUId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBHDD_DBHDDsDBHDDId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBPowerUnit_DBPowerUnitsDBPowerUnitId",
                table: "Configs");

            migrationBuilder.DropForeignKey(
                name: "FK_Configs_DBRAM_DBRAMsDBRAMId",
                table: "Configs");

            migrationBuilder.DropIndex(
                name: "IX_Configs_BDMotherBoardsBDMotherBoardId",
                table: "Configs");

            migrationBuilder.DropIndex(
                name: "IX_Configs_DBCPUsDBCPUId",
                table: "Configs");

            migrationBuilder.DropIndex(
                name: "IX_Configs_DBGPUsDBGPUId",
                table: "Configs");

            migrationBuilder.DropIndex(
                name: "IX_Configs_DBHDDsDBHDDId",
                table: "Configs");

            migrationBuilder.DropIndex(
                name: "IX_Configs_DBPowerUnitsDBPowerUnitId",
                table: "Configs");

            migrationBuilder.DropIndex(
                name: "IX_Configs_DBRAMsDBRAMId",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "BDMotherBoardsBDMotherBoardId",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DBCPUsDBCPUId",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DBGPUsDBGPUId",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DBHDDsDBHDDId",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DBPowerUnitsDBPowerUnitId",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "DBRAMsDBRAMId",
                table: "Configs");

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "DBRAM",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "DBPowerUnit",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "DBHDD",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "DBGPUs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "DBCPUs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigId",
                table: "BDMotherBoards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DBRAM_ConfigId",
                table: "DBRAM",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBPowerUnit_ConfigId",
                table: "DBPowerUnit",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBHDD_ConfigId",
                table: "DBHDD",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBGPUs_ConfigId",
                table: "DBGPUs",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBCPUs_ConfigId",
                table: "DBCPUs",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_BDMotherBoards_ConfigId",
                table: "BDMotherBoards",
                column: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_BDMotherBoards_Configs_ConfigId",
                table: "BDMotherBoards",
                column: "ConfigId",
                principalTable: "Configs",
                principalColumn: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBCPUs_Configs_ConfigId",
                table: "DBCPUs",
                column: "ConfigId",
                principalTable: "Configs",
                principalColumn: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBGPUs_Configs_ConfigId",
                table: "DBGPUs",
                column: "ConfigId",
                principalTable: "Configs",
                principalColumn: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBHDD_Configs_ConfigId",
                table: "DBHDD",
                column: "ConfigId",
                principalTable: "Configs",
                principalColumn: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBPowerUnit_Configs_ConfigId",
                table: "DBPowerUnit",
                column: "ConfigId",
                principalTable: "Configs",
                principalColumn: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_DBRAM_Configs_ConfigId",
                table: "DBRAM",
                column: "ConfigId",
                principalTable: "Configs",
                principalColumn: "ConfigId");
        }
    }
}
