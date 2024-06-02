using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektPraktyki_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Hr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Companys_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyID",
                table: "Contacts",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Companys");
        }
    }
}
