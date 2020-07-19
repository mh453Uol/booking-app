using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberBooking.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UpdatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingService_AspNetUsers_UpdatedById",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningHours_AspNetUsers_CreatedById",
                table: "OpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningHours_AspNetUsers_ResourceId",
                table: "OpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningHours_Tenants_TenantId",
                table: "OpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningHours_AspNetUsers_UpdatedById",
                table: "OpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_OpeningHours_AspNetUsers_UserId",
                table: "OpeningHours");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UpdatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AspNetUsers_UpdatedById",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpeningHours",
                table: "OpeningHours");

            migrationBuilder.RenameTable(
                name: "OpeningHours",
                newName: "TradingHours");

            migrationBuilder.RenameIndex(
                name: "IX_OpeningHours_UserId",
                table: "TradingHours",
                newName: "IX_TradingHours_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OpeningHours_UpdatedById",
                table: "TradingHours",
                newName: "IX_TradingHours_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_OpeningHours_TenantId",
                table: "TradingHours",
                newName: "IX_TradingHours_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_OpeningHours_ResourceId",
                table: "TradingHours",
                newName: "IX_TradingHours_ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_OpeningHours_CreatedById",
                table: "TradingHours",
                newName: "IX_TradingHours_CreatedById");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Tenants",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Services",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "BookingService",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "TradingHours",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TradingHours",
                table: "TradingHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UpdatedById",
                table: "Bookings",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingService_AspNetUsers_UpdatedById",
                table: "BookingService",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_UpdatedById",
                table: "Services",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AspNetUsers_UpdatedById",
                table: "Tenants",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TradingHours_AspNetUsers_CreatedById",
                table: "TradingHours",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TradingHours_AspNetUsers_ResourceId",
                table: "TradingHours",
                column: "ResourceId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TradingHours_Tenants_TenantId",
                table: "TradingHours",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TradingHours_AspNetUsers_UpdatedById",
                table: "TradingHours",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TradingHours_AspNetUsers_UserId",
                table: "TradingHours",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UpdatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingService_AspNetUsers_UpdatedById",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UpdatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AspNetUsers_UpdatedById",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_TradingHours_AspNetUsers_CreatedById",
                table: "TradingHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TradingHours_AspNetUsers_ResourceId",
                table: "TradingHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TradingHours_Tenants_TenantId",
                table: "TradingHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TradingHours_AspNetUsers_UpdatedById",
                table: "TradingHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TradingHours_AspNetUsers_UserId",
                table: "TradingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TradingHours",
                table: "TradingHours");

            migrationBuilder.RenameTable(
                name: "TradingHours",
                newName: "OpeningHours");

            migrationBuilder.RenameIndex(
                name: "IX_TradingHours_UserId",
                table: "OpeningHours",
                newName: "IX_OpeningHours_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TradingHours_UpdatedById",
                table: "OpeningHours",
                newName: "IX_OpeningHours_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_TradingHours_TenantId",
                table: "OpeningHours",
                newName: "IX_OpeningHours_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_TradingHours_ResourceId",
                table: "OpeningHours",
                newName: "IX_OpeningHours_ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_TradingHours_CreatedById",
                table: "OpeningHours",
                newName: "IX_OpeningHours_CreatedById");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Tenants",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Services",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "BookingService",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "Bookings",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedById",
                table: "OpeningHours",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpeningHours",
                table: "OpeningHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UpdatedById",
                table: "Bookings",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingService_AspNetUsers_UpdatedById",
                table: "BookingService",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningHours_AspNetUsers_CreatedById",
                table: "OpeningHours",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningHours_AspNetUsers_ResourceId",
                table: "OpeningHours",
                column: "ResourceId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningHours_Tenants_TenantId",
                table: "OpeningHours",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningHours_AspNetUsers_UpdatedById",
                table: "OpeningHours",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpeningHours_AspNetUsers_UserId",
                table: "OpeningHours",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_UpdatedById",
                table: "Services",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AspNetUsers_UpdatedById",
                table: "Tenants",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
