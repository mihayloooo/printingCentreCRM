using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FlowSequenceId",
                table: "PrintTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flows_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowSequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintSide = table.Column<int>(type: "int", nullable: false),
                    ColorMode = table.Column<int>(type: "int", nullable: false),
                    ShipmentType = table.Column<int>(type: "int", nullable: false),
                    FlowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowSequences_Flows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envelope",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnvelopeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FlowSequenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envelope_FlowSequences_FlowSequenceId",
                        column: x => x.FlowSequenceId,
                        principalTable: "FlowSequences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintTemplates_FlowSequenceId",
                table: "PrintTemplates",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Envelope_FlowSequenceId",
                table: "Envelope",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Flows_CompanyId",
                table: "Flows",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSequences_FlowId",
                table: "FlowSequences",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintTemplates_FlowSequences_FlowSequenceId",
                table: "PrintTemplates",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrintTemplates_FlowSequences_FlowSequenceId",
                table: "PrintTemplates");

            migrationBuilder.DropTable(
                name: "Envelope");

            migrationBuilder.DropTable(
                name: "FlowSequences");

            migrationBuilder.DropTable(
                name: "Flows");

            migrationBuilder.DropIndex(
                name: "IX_PrintTemplates_FlowSequenceId",
                table: "PrintTemplates");

            migrationBuilder.DropColumn(
                name: "FlowSequenceId",
                table: "PrintTemplates");
        }
    }
}
