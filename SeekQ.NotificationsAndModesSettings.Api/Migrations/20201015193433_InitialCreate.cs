using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeekQ.NotificationsAndModesSettings.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdNotificationType = table.Column<int>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotificationTypes_NotificationTypes_IdNotificationType",
                        column: x => x.IdNotificationType,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotificationTypes_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTypes_Name",
                table: "NotificationTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationTypes_IdNotificationType",
                table: "UserNotificationTypes",
                column: "IdNotificationType");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationTypes_IdUser_IdNotificationType",
                table: "UserNotificationTypes",
                columns: new[] { "IdUser", "IdNotificationType" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotificationTypes");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
