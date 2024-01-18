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
                name: "NoteBooks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteBooks", x => x.Id);
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
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LabelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourcesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    NoteBooksId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_NoteBooks_NoteBooksId",
                        column: x => x.NoteBooksId,
                        principalTable: "NoteBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "Resources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2f81a112-5678-11e8-86e5-f0d534f731f68", "Fitness" },
                    { "2f81a612-7531-11e8-86e5-f0d534f731f68", "School" },
                    { "2f81a632-9012-11e8-86e5-f0d534f731f68", "Investment" },
                    { "2f81a686-7531-11e8-86e5-f0d534f731f68", "Business" },
                    { "2f81a686-7531-11e8-86e5-f0d5bf731f68", "Personal" },
                    { "2f81a789-1234-11e8-86e5-f0d534f731f68", "Productivity" },
                    { "2f99a636-7111-11e8-86e5-f0d534f731f68", "Work" }
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
                columns: new[] { "Id", "AreaCover", "IsAchieved", "LabelId", "Name" },
                values: new object[,]
                {
                    { "280c9bbeb9f46af1", "money-bill-trend-up", false, "2f81a686-7531-11e8-86e5-f0d534f731f68", "Side Hustle" },
                    { "3165c2ffbc32c7b7", "user", false, "2f81a686-7531-11e8-86e5-f0d5bf731f68", "Personal" },
                    { "3fea19696abe8bcf", "briefcase", false, "2f99a636-7111-11e8-86e5-f0d534f731f68", "Work" },
                    { "4e33dab54181420f", "leanpub", false, "2f81a612-7531-11e8-86e5-f0d534f731f68", "Learning" },
                    { "50fc739db1043beb", "dumbbell", false, "2f81a112-5678-11e8-86e5-f0d534f731f68", "Health & Fitness" },
                    { "e905912d76ef7618", "route", false, "2f81a686-7531-11e8-86e5-f0d5bf731f68", "Travel" }
                });

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
                name: "IX_Notes_AreasId",
                table: "Notes",
                column: "AreasId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LabelId",
                table: "Notes",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteBooksId",
                table: "Notes",
                column: "NoteBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProjectsId",
                table: "Notes",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ResourcesId",
                table: "Notes",
                column: "ResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StatusId",
                table: "Notes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TaskId",
                table: "Notes",
                column: "TaskId");

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
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ProjectResource");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "NoteBooks");

            migrationBuilder.DropTable(
                name: "Tasks");

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
