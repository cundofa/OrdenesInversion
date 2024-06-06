using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdenesInversion.Migrations
{
    /// <inheritdoc />
    public partial class alterOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name:"Baja",
                table:"Ordenes",
                nullable:false,
                defaultValue:0
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
