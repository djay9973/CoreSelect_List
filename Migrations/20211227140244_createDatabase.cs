using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreSelect_List.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country_Djs",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country_Djs", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "City_Djs",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City_Djs", x => x.Code);
                    table.ForeignKey(
                        name: "FK_City_Djs_Country_Djs_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country_Djs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers_dj",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers_dj", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_dj_City_Djs_CityCode",
                        column: x => x.CityCode,
                        principalTable: "City_Djs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_dj_Country_Djs_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Country_Djs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_Djs_CountryCode",
                table: "City_Djs",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_dj_CityCode",
                table: "Customers_dj",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_dj_CountryCode",
                table: "Customers_dj",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers_dj");

            migrationBuilder.DropTable(
                name: "City_Djs");

            migrationBuilder.DropTable(
                name: "Country_Djs");
        }
    }
}
