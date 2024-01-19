using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RubBotApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AreaCover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    LabelsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Areas_Labels_LabelsId",
                        column: x => x.LabelsId,
                        principalTable: "Labels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LabelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resources_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaProject",
                columns: table => new
                {
                    AreasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaProject", x => new { x.AreasId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_AreaProject_Areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaResource",
                columns: table => new
                {
                    AreasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourcesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaResource", x => new { x.AreasId, x.ResourcesId });
                    table.ForeignKey(
                        name: "FK_AreaResource_Areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaResource_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectResource",
                columns: table => new
                {
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourcesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectResource", x => new { x.ProjectsId, x.ResourcesId });
                    table.ForeignKey(
                        name: "FK_ProjectResource_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectResource_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourcesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1f81a686-1531-11e8-16e5-f0d5bf731f61", "Personal" },
                    { "2f99a636-2111-11e8-26e5-f0d534f731f62", "Work" },
                    { "3f81a686-3531-11e8-36e5-f0d534f731f63", "Business" },
                    { "4f81a612-4531-11e8-46e5-f0d534f731f64", "School" },
                    { "5f81a789-5234-11e8-56e5-f0d534f731f65", "Productivity" },
                    { "6f81a112-6678-11e8-66e5-f0d534f731f66", "Fitness" },
                    { "7f81a632-7012-11e8-76e5-f0d534f731f67", "Investment" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2f81a123-1234-11e8-86e5-f0d5bf731f68", "Planned" },
                    { "2f81a456-5678-11e8-86e5-f0d5bf731f68", "In Progress" },
                    { "2f81a686-7531-11e8-86e5-f0d5bf731f68", "Inbox" },
                    { "2f81a789-9012-11e8-86e5-f0d5bf731f68", "Done" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "AreaCover", "IsAchieved", "LabelId", "LabelsId", "Name" },
                values: new object[,]
                {
                    { "31483485000784f6", "route", false, "1f81a686-1531-11e8-16e5-f0d5bf731f61", null, "Travel" },
                    { "691460af7e50befd", "dumbbell", false, "6f81a112-6678-11e8-66e5-f0d534f731f66", null, "Health & Fitness" },
                    { "6e3ab353ba1f109a", "briefcase", false, "2f99a636-2111-11e8-26e5-f0d534f731f62", null, "Work" },
                    { "8850a149a403ea70", "leanpub", false, "4f81a612-4531-11e8-46e5-f0d534f731f64", null, "Learning" },
                    { "dce86ddd2b57d888", "money-bill-trend-up", false, "3f81a686-3531-11e8-36e5-f0d534f731f63", null, "Side Hustle" },
                    { "e163ea7c7e495a08", "user", false, "1f81a686-1531-11e8-16e5-f0d5bf731f61", null, "Personal" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "EndDate", "IsAchieved", "Name", "StartDate", "StatusId" },
                values: new object[] { "0d0b5c4d6ab2f474", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sample Project", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2f81a686-7531-11e8-86e5-f0d5bf731f68" });

            migrationBuilder.CreateIndex(
                name: "IX_AreaProject_ProjectsId",
                table: "AreaProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaResource_ResourcesId",
                table: "AreaResource",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LabelId",
                table: "Areas",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_LabelsId",
                table: "Areas",
                column: "LabelsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResource_ResourcesId",
                table: "ProjectResource",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_LabelId",
                table: "Resources",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_StatusId",
                table: "Resources",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectsId",
                table: "Tasks",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ResourcesId",
                table: "Tasks",
                column: "ResourcesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaProject");

            migrationBuilder.DropTable(
                name: "AreaResource");

            migrationBuilder.DropTable(
                name: "ProjectResource");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
