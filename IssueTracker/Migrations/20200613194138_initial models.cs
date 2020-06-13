using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Migrations
{
    public partial class initialmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFrom = table.Column<string>(nullable: true),
                    UserFromImage = table.Column<string>(nullable: true),
                    UserTo = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_User_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProjectType = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    EndOfContractDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Header = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    EntryById = table.Column<int>(nullable: true),
                    AssignById = table.Column<int>(nullable: true),
                    AssignDate = table.Column<DateTime>(nullable: false),
                    AssignRemarks = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    TaskHour = table.Column<double>(nullable: false),
                    IssueType = table.Column<int>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueLog_User_AssignById",
                        column: x => x.AssignById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueLog_User_EntryById",
                        column: x => x.EntryById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueLog_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContactPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContactPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectContactPerson_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSupportPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSupportPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSupportPerson_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectSupportPerson_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueLogInvolvedPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvolvedPersonId = table.Column<int>(nullable: true),
                    HoursToComplete = table.Column<double>(nullable: false),
                    ExpectedHour = table.Column<double>(nullable: false),
                    ReceiveDate = table.Column<DateTime>(nullable: false),
                    ReceiveRemarks = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    IssueLogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLogInvolvedPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueLogInvolvedPerson_User_InvolvedPersonId",
                        column: x => x.InvolvedPersonId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueLogInvolvedPerson_IssueLog_IssueLogId",
                        column: x => x.IssueLogId,
                        principalTable: "IssueLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWiseStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    ProjectContactPersonId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RelationWithClient = table.Column<int>(nullable: false),
                    LastVisitDate = table.Column<DateTime>(nullable: false),
                    StatusById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWiseStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_ProjectContactPerson_ProjectContactPersonId",
                        column: x => x.ProjectContactPersonId,
                        principalTable: "ProjectContactPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_User_StatusById",
                        column: x => x.StatusById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreatedById",
                table: "Company",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ModifiedById",
                table: "Company",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLog_AssignById",
                table: "IssueLog",
                column: "AssignById");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLog_EntryById",
                table: "IssueLog",
                column: "EntryById");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLog_ProjectId",
                table: "IssueLog",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLogInvolvedPerson_InvolvedPersonId",
                table: "IssueLogInvolvedPerson",
                column: "InvolvedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLogInvolvedPerson_IssueLogId",
                table: "IssueLogInvolvedPerson",
                column: "IssueLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedById",
                table: "Project",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContactPerson_ProjectId",
                table: "ProjectContactPerson",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSupportPerson_ApplicationUserId",
                table: "ProjectSupportPerson",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSupportPerson_ProjectId",
                table: "ProjectSupportPerson",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_CompanyId",
                table: "ProjectWiseStatus",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_ProjectContactPersonId",
                table: "ProjectWiseStatus",
                column: "ProjectContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_ProjectId",
                table: "ProjectWiseStatus",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_StatusById",
                table: "ProjectWiseStatus",
                column: "StatusById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "IssueLogInvolvedPerson");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProjectSupportPerson");

            migrationBuilder.DropTable(
                name: "ProjectWiseStatus");

            migrationBuilder.DropTable(
                name: "IssueLog");

            migrationBuilder.DropTable(
                name: "ProjectContactPerson");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
