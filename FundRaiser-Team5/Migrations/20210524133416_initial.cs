using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundRaiser_Team5.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundingGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentFund = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundingPackages",
                columns: table => new
                {
                    FundingPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinPrice = table.Column<int>(type: "int", nullable: false),
                    AvailablePackages = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingPackages", x => x.FundingPackageId);
                    table.ForeignKey(
                        name: "FK_FundingPackages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingPackages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagePath",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePath", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImagePath_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusUpdates",
                columns: table => new
                {
                    StatusUpdateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUpdates", x => x.StatusUpdateId);
                    table.ForeignKey(
                        name: "FK_StatusUpdates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoPath",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoPath", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VideoPath_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackerFundingPackages",
                columns: table => new
                {
                    BackerFundingPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FundingPackageId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BackerFundingPackageStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerFundingPackages", x => x.BackerFundingPackageId);
                    table.ForeignKey(
                        name: "FK_BackerFundingPackages_FundingPackages_FundingPackageId",
                        column: x => x.FundingPackageId,
                        principalTable: "FundingPackages",
                        principalColumn: "FundingPackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BackerFundingPackages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackerFundingPackages_FundingPackageId",
                table: "BackerFundingPackages",
                column: "FundingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_BackerFundingPackages_UserId",
                table: "BackerFundingPackages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingPackages_ProjectId",
                table: "FundingPackages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingPackages_UserId",
                table: "FundingPackages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePath_ProjectId",
                table: "ImagePath",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UsersUserId",
                table: "Projects",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusUpdates_ProjectId",
                table: "StatusUpdates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoPath_ProjectId",
                table: "VideoPath",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerFundingPackages");

            migrationBuilder.DropTable(
                name: "ImagePath");

            migrationBuilder.DropTable(
                name: "StatusUpdates");

            migrationBuilder.DropTable(
                name: "VideoPath");

            migrationBuilder.DropTable(
                name: "FundingPackages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
