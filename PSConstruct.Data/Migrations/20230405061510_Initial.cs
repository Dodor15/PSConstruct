using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSConstruct.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfigName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.ConfigId);
                });

            migrationBuilder.CreateTable(
                name: "BDMotherBoards",
                columns: table => new
                {
                    BDMotherBoardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MDName = table.Column<string>(type: "TEXT", nullable: false),
                    CPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    GPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    RAMsocket = table.Column<string>(type: "TEXT", nullable: false),
                    CountRAM = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDMotherBoards", x => x.BDMotherBoardId);
                    table.ForeignKey(
                        name: "FK_BDMotherBoards_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateTable(
                name: "DBCPUs",
                columns: table => new
                {
                    DBCPUId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPUName = table.Column<string>(type: "TEXT", nullable: false),
                    CPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    CoreCount = table.Column<int>(type: "INTEGER", nullable: false),
                    StreamsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CoreHz = table.Column<double>(type: "REAL", nullable: false),
                    GraphicsCore = table.Column<bool>(type: "INTEGER", nullable: false),
                    PowerEat = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCPUs", x => x.DBCPUId);
                    table.ForeignKey(
                        name: "FK_DBCPUs_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateTable(
                name: "DBGPUs",
                columns: table => new
                {
                    DBGPUId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GPUName = table.Column<string>(type: "TEXT", nullable: false),
                    GPUsocket = table.Column<string>(type: "TEXT", nullable: false),
                    GPUMemoryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MemoryType = table.Column<string>(type: "TEXT", nullable: false),
                    bandwidth = table.Column<int>(type: "INTEGER", nullable: false),
                    PowerEat = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBGPUs", x => x.DBGPUId);
                    table.ForeignKey(
                        name: "FK_DBGPUs_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateTable(
                name: "DBHDD",
                columns: table => new
                {
                    DBHDDId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HDDName = table.Column<string>(type: "TEXT", nullable: false),
                    HDDMemoryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MemorySpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    HDDPowerEat = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBHDD", x => x.DBHDDId);
                    table.ForeignKey(
                        name: "FK_DBHDD_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateTable(
                name: "DBPowerUnit",
                columns: table => new
                {
                    DBPowerUnitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PowerUnitName = table.Column<string>(type: "TEXT", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPowerUnit", x => x.DBPowerUnitId);
                    table.ForeignKey(
                        name: "FK_DBPowerUnit_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateTable(
                name: "DBRAM",
                columns: table => new
                {
                    DBRAMId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RAMName = table.Column<string>(type: "TEXT", nullable: false),
                    RamMemoryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    RamMemorySpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    RAMsocket = table.Column<string>(type: "TEXT", nullable: false),
                    ConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBRAM", x => x.DBRAMId);
                    table.ForeignKey(
                        name: "FK_DBRAM_Configs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "Configs",
                        principalColumn: "ConfigId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BDMotherBoards_ConfigId",
                table: "BDMotherBoards",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBCPUs_ConfigId",
                table: "DBCPUs",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBGPUs_ConfigId",
                table: "DBGPUs",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBHDD_ConfigId",
                table: "DBHDD",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBPowerUnit_ConfigId",
                table: "DBPowerUnit",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DBRAM_ConfigId",
                table: "DBRAM",
                column: "ConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BDMotherBoards");

            migrationBuilder.DropTable(
                name: "DBCPUs");

            migrationBuilder.DropTable(
                name: "DBGPUs");

            migrationBuilder.DropTable(
                name: "DBHDD");

            migrationBuilder.DropTable(
                name: "DBPowerUnit");

            migrationBuilder.DropTable(
                name: "DBRAM");

            migrationBuilder.DropTable(
                name: "Configs");
        }
    }
}
