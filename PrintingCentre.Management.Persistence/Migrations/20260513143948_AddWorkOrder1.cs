using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkOrder1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowId = table.Column<int>(type: "int", nullable: false),
                    FlowId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Flows_FlowId1",
                        column: x => x.FlowId1,
                        principalTable: "Flows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderSequenceEnvelopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnvelopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderSequenceEnvelopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderSequenceEnvelopes_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderSequenceTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderSequenceTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderSequenceTemplates_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_FlowId1",
                table: "WorkOrders",
                column: "FlowId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequenceEnvelopes_WorkOrderId",
                table: "WorkOrderSequenceEnvelopes",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequenceTemplates_WorkOrderId",
                table: "WorkOrderSequenceTemplates",
                column: "WorkOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropTable(
                name: "WorkOrderSequenceTemplates");

            migrationBuilder.DropTable(
                name: "WorkOrders");
        }
    }
}
