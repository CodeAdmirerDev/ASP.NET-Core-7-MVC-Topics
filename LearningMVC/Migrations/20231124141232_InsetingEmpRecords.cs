using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningMVC.Migrations
{
    /// <inheritdoc />
    public partial class InsetingEmpRecords : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Employees values ('Suri',28,1234567890);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Employees WHERE EId =2;");
        }
    }
}
