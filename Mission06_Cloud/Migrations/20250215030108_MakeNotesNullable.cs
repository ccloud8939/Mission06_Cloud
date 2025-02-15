using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Cloud.Migrations
{
    /// <inheritdoc />
    public partial class MakeNotesNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Forms",
                nullable: true, // Make this column nullable
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: false); // Update this line
            
            // Making 'lent' column nullable
            migrationBuilder.AlterColumn<string>(
                name: "lent",
                table: "Forms",
                nullable: true, // Change from non-nullable to nullable
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: false); // Revert to nullable
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
