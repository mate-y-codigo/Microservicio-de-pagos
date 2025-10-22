using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Alumno_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Entrenador_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    Moneda = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Pagado_El = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cobertura_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cobertura_Fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Metodo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, defaultValue: "Pendiente"),
                    Notas = table.Column<string>(type: "text", nullable: true),
                    Creado_En = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pago");
        }
    }
}
