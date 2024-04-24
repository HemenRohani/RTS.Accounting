using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTS.Accounting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ExternalInvoiceNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<long>(type: "bigint", nullable: false),
                    ParentInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseDocuments_BaseDocuments_ParentInvoiceId",
                        column: x => x.ParentInvoiceId,
                        principalTable: "BaseDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocuments_ParentInvoiceId",
                table: "BaseDocuments",
                column: "ParentInvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseDocuments");
        }
    }
}
