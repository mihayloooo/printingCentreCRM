using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConnectWorkOrederWithTemplateAndEnvelope1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Flows_FlowId1",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_FlowId1",
                table: "WorkOrders");

            // Drop the original int FlowId column — cannot ALTER int to uniqueidentifier directly
            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "FlowId1",
                table: "WorkOrders",
                newName: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_FlowId",
                table: "WorkOrders",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Flows_FlowId",
                table: "WorkOrders",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Flows_FlowId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_FlowId",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<int>(
                name: "FlowId",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "FlowId1",
                table: "WorkOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_FlowId1",
                table: "WorkOrders",
                column: "FlowId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Flows_FlowId1",
                table: "WorkOrders",
                column: "FlowId1",
                principalTable: "Flows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
