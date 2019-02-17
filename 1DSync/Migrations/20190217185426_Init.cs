using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1DSync.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PseudoDynamicEntities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValueSql: "HEX(RANDOMBLOB(16))"),
                    StringCol1 = table.Column<string>(nullable: true),
                    StringCol2 = table.Column<string>(nullable: true),
                    StringCol3 = table.Column<string>(nullable: true),
                    StringCol4 = table.Column<string>(nullable: true),
                    StringCol5 = table.Column<string>(nullable: true),
                    StringCol6 = table.Column<string>(nullable: true),
                    StringCol7 = table.Column<string>(nullable: true),
                    StringCol8 = table.Column<string>(nullable: true),
                    StringCol9 = table.Column<string>(nullable: true),
                    DoubleCol1 = table.Column<double>(nullable: false),
                    DoubleCol2 = table.Column<double>(nullable: false),
                    DoubleCol3 = table.Column<double>(nullable: false),
                    DateTimeCol1 = table.Column<DateTime>(nullable: false),
                    DateTimeCol2 = table.Column<DateTime>(nullable: false),
                    SyncStatus = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoDynamicEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PseudoDynamicEntities");
        }
    }
}
