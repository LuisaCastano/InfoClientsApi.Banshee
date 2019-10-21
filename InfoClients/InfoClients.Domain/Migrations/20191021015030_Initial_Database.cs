using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoClients.Domain.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "infoclients");

            migrationBuilder.CreateTable(
                name: "City",
                schema: "infoclients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    NameCity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "infoclients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesRepresentative",
                schema: "infoclients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRepresentative", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "infoclients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    NameState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "infoclients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nit = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    CreditLimit = table.Column<int>(nullable: false),
                    VisitsPercentage = table.Column<double>(nullable: false),
                    AvailableCredit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "infoclients",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "infoclients",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "infoclients",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientVisit",
                schema: "infoclients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<Guid>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    SaleRepresentativeId = table.Column<int>(nullable: false),
                    Net = table.Column<int>(nullable: false),
                    VisitTotal = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientVisit_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "infoclients",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientVisit_SalesRepresentative_SaleRepresentativeId",
                        column: x => x.SaleRepresentativeId,
                        principalSchema: "infoclients",
                        principalTable: "SalesRepresentative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CityId",
                schema: "infoclients",
                table: "Client",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CountryId",
                schema: "infoclients",
                table: "Client",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_StateId",
                schema: "infoclients",
                table: "Client",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientVisit_ClientId",
                schema: "infoclients",
                table: "ClientVisit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientVisit_SaleRepresentativeId",
                schema: "infoclients",
                table: "ClientVisit",
                column: "SaleRepresentativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientVisit",
                schema: "infoclients");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "infoclients");

            migrationBuilder.DropTable(
                name: "SalesRepresentative",
                schema: "infoclients");

            migrationBuilder.DropTable(
                name: "City",
                schema: "infoclients");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "infoclients");

            migrationBuilder.DropTable(
                name: "State",
                schema: "infoclients");
        }
    }
}
