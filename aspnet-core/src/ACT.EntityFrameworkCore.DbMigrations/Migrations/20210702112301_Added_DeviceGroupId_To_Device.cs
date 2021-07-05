using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations
{
    public partial class Added_DeviceGroupId_To_Device : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeviceGroupId",
                table: "AppDevices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppDevices_DeviceGroupId",
                table: "AppDevices",
                column: "DeviceGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDevices_AppDeviceGroups_DeviceGroupId",
                table: "AppDevices",
                column: "DeviceGroupId",
                principalTable: "AppDeviceGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDevices_AppDeviceGroups_DeviceGroupId",
                table: "AppDevices");

            migrationBuilder.DropIndex(
                name: "IX_AppDevices_DeviceGroupId",
                table: "AppDevices");

            migrationBuilder.DropColumn(
                name: "DeviceGroupId",
                table: "AppDevices");
        }
    }
}
