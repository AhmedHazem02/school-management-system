using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.infransturture.Data
{
    /// <inheritdoc />
    public partial class convertPhototophone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Students",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "Photo");
        }
    }
}
