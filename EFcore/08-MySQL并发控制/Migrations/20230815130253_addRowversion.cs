using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _08_MySQL并发控制.Migrations
{
    /// <inheritdoc />
    public partial class addRowversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "T_Houses",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "T_Houses");
        }
    }
}
