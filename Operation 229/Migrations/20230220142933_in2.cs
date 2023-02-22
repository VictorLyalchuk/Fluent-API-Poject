using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Operation_229.Migrations
{
    public partial class in2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxPassangers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirplaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneID",
                        column: x => x.AirplaneID,
                        principalTable: "Airplanes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFlight",
                columns: table => new
                {
                    clientsID = table.Column<int>(type: "int", nullable: false),
                    flightsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlight", x => new { x.clientsID, x.flightsID });
                    table.ForeignKey(
                        name: "FK_ClientFlight_Flights_flightsID",
                        column: x => x.flightsID,
                        principalTable: "Flights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlight_Passengers_clientsID",
                        column: x => x.clientsID,
                        principalTable: "Passengers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "ID", "MaxPassangers", "Model" },
                values: new object[] { 1, 700, "Boeing 747" });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "ID", "MaxPassangers", "Model" },
                values: new object[] { 2, 750, "Boeing A320" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "ID", "AirplaneID", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime" },
                values: new object[] { 1, 1, "London", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "ID", "AirplaneID", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime" },
                values: new object[] { 2, 2, "London", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amsterdam", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_flightsID",
                table: "ClientFlight",
                column: "flightsID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneID",
                table: "Flights",
                column: "AirplaneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Airplanes");
        }
    }
}
