using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BD_KURSACH.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Uzel",
                columns: table => new
                {
                    KOD_UZ = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UZ_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzel", x => x.KOD_UZ);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SE",
                columns: table => new
                {
                    KOD_SE = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NP = table.Column<int>(type: "int", nullable: false),
                    α1 = table.Column<int>(type: "int", nullable: false),
                    V = table.Column<int>(type: "int", nullable: false),
                    C1 = table.Column<double>(type: "double", nullable: false),
                    C2 = table.Column<double>(type: "double", nullable: false),
                    C3 = table.Column<double>(type: "double", nullable: false),
                    σ0 = table.Column<double>(type: "double", nullable: false),
                    σF0 = table.Column<double>(type: "double", nullable: false),
                    σF = table.Column<double>(type: "double", nullable: false),
                    F = table.Column<double>(type: "double", nullable: false),
                    Zmax = table.Column<int>(type: "int", nullable: false),
                    Z = table.Column<int>(type: "int", nullable: false),
                    Razn = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SE_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SE_Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SE_Вид = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KOD_UZLA = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SE", x => x.KOD_SE);
                    table.ForeignKey(
                        name: "FK_SE_Uzel_KOD_UZLA",
                        column: x => x.KOD_UZLA,
                        principalTable: "Uzel",
                        principalColumn: "KOD_UZ",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detal",
                columns: table => new
                {
                    KOD_DET = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    S1 = table.Column<int>(type: "int", nullable: false),
                    DET_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DET_Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DET_Вид = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KOD_SE = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detal", x => x.KOD_DET);
                    table.ForeignKey(
                        name: "FK_Detal_SE_KOD_SE",
                        column: x => x.KOD_SE,
                        principalTable: "SE",
                        principalColumn: "KOD_SE",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Detal_KOD_SE",
                table: "Detal",
                column: "KOD_SE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SE_KOD_UZLA",
                table: "SE",
                column: "KOD_UZLA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detal");

            migrationBuilder.DropTable(
                name: "SE");

            migrationBuilder.DropTable(
                name: "Uzel");
        }
    }
}
