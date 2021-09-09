using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Assessment2_WebAPI.Migrations
{
    public partial class HouseRent_system : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_User",
                columns: table => new
                {
                    Cust_Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cust_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cust_Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust_Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cust_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_User", x => x.Cust_Username);
                });

            migrationBuilder.CreateTable(
                name: "Rent_Agent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agent_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent_Office = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent_Agent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rent_Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    House_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    House_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    House_WeeklyRent = table.Column<double>(type: "float", nullable: false),
                    House_Bedroom = table.Column<int>(type: "int", nullable: false),
                    House_Bathroom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rent_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rent_AgentId = table.Column<int>(type: "int", nullable: true),
                    Rent_HousesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rent_Details_Rent_Agent_Rent_AgentId",
                        column: x => x.Rent_AgentId,
                        principalTable: "Rent_Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rent_Details_Rent_Houses_Rent_HousesId",
                        column: x => x.Rent_HousesId,
                        principalTable: "Rent_Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rent_Details_Rent_AgentId",
                table: "Rent_Details",
                column: "Rent_AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_Details_Rent_HousesId",
                table: "Rent_Details",
                column: "Rent_HousesId");

            //var sqlagent = Path.Combine(".\\Database", @"RentADB.sql");
            //migrationBuilder.Sql(File.ReadAllText(sqlagent));

            //var sqlhouse = Path.Combine(".\\Database", @"RentHDB.sql");
            //migrationBuilder.Sql(File.ReadAllText(sqlhouse));

            //var sqldetails = Path.Combine(".\\Database", @"RentDDB.sql");
            //migrationBuilder.Sql(File.ReadAllText(sqldetails));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_User");

            migrationBuilder.DropTable(
                name: "Rent_Details");

            migrationBuilder.DropTable(
                name: "Rent_Agent");

            migrationBuilder.DropTable(
                name: "Rent_Houses");
        }
    }
}
