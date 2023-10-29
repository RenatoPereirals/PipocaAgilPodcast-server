using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PipocaAgilPodcast.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    ActivityDetails = table.Column<string>(type: "text", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IPAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Topic = table.Column<string>(type: "text", nullable: false),
                    InterestLevel = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statisticss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ActivityLogId = table.Column<int>(type: "integer", nullable: false),
                    TotalActivities = table.Column<int>(type: "integer", nullable: false),
                    TotalLikes = table.Column<int>(type: "integer", nullable: false),
                    TotalComments = table.Column<int>(type: "integer", nullable: false),
                    TotalShares = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statisticss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statisticss_ActivityHistory_ActivityLogId",
                        column: x => x.ActivityLogId,
                        principalTable: "ActivityHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statisticss_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersActivitiesLogs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ActivityLogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersActivitiesLogs", x => new { x.UserId, x.ActivityLogId });
                    table.ForeignKey(
                        name: "FK_UsersActivitiesLogs_ActivityHistory_ActivityLogId",
                        column: x => x.ActivityLogId,
                        principalTable: "ActivityHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersActivitiesLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_UserId",
                table: "Interests",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statisticss_ActivityLogId",
                table: "Statisticss",
                column: "ActivityLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Statisticss_UserId",
                table: "Statisticss",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersActivitiesLogs_ActivityLogId",
                table: "UsersActivitiesLogs",
                column: "ActivityLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Statisticss");

            migrationBuilder.DropTable(
                name: "UsersActivitiesLogs");

            migrationBuilder.DropTable(
                name: "ActivityHistory");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
