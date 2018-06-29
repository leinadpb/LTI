using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LTI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    MyconfigurationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 30, nullable: true),
                    Value = table.Column<string>(maxLength: 1200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.MyconfigurationID);
                });

            migrationBuilder.CreateTable(
                name: "HistoryStudents",
                columns: table => new
                {
                    HistoryStudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginName = table.Column<string>(maxLength: 60, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 120, nullable: false),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    Domain = table.Column<string>(maxLength: 20, nullable: false),
                    ComputerName = table.Column<string>(maxLength: 20, nullable: false),
                    SubjectName = table.Column<string>(maxLength: 80, nullable: true),
                    SubjectSection = table.Column<string>(maxLength: 10, nullable: true),
                    HasFilledSurvey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryStudents", x => x.HistoryStudentID);
                });

            migrationBuilder.CreateTable(
                name: "HistoryTeachers",
                columns: table => new
                {
                    HistoryTeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginName = table.Column<string>(maxLength: 60, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 120, nullable: false),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    Domain = table.Column<string>(maxLength: 20, nullable: false),
                    ComputerName = table.Column<string>(maxLength: 20, nullable: false),
                    HasFilledSurvey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTeachers", x => x.HistoryTeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Normas",
                columns: table => new
                {
                    NormaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NormaContent = table.Column<string>(maxLength: 1250, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normas", x => x.NormaID);
                });

            migrationBuilder.CreateTable(
                name: "Trimestres",
                columns: table => new
                {
                    TrimestreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trimestres", x => x.TrimestreID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginName = table.Column<string>(maxLength: 60, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 120, nullable: false),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    Domain = table.Column<string>(maxLength: 20, nullable: false),
                    ComputerName = table.Column<string>(maxLength: 20, nullable: false),
                    HasFilledSurvey = table.Column<bool>(nullable: false),
                    HistoryTeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK_Teachers_HistoryTeachers_HistoryTeacherID",
                        column: x => x.HistoryTeacherID,
                        principalTable: "HistoryTeachers",
                        principalColumn: "HistoryTeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeacherID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admins_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(maxLength: 120, nullable: false),
                    LoginName = table.Column<string>(maxLength: 60, nullable: false),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    Domain = table.Column<string>(maxLength: 20, nullable: false),
                    ComputerName = table.Column<string>(maxLength: 20, nullable: false),
                    SubjectName = table.Column<string>(maxLength: 140, nullable: true),
                    SubjectSection = table.Column<string>(maxLength: 10, nullable: true),
                    SubjectCode = table.Column<string>(maxLength: 20, nullable: true),
                    HasFilledSurvey = table.Column<bool>(nullable: false),
                    HistoryStudentID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_HistoryStudents_HistoryStudentID",
                        column: x => x.HistoryStudentID,
                        principalTable: "HistoryStudents",
                        principalColumn: "HistoryStudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(maxLength: 120, nullable: false),
                    SubjectCode = table.Column<string>(maxLength: 10, nullable: false),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimText = table.Column<string>(maxLength: 500, nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimID);
                    table.ForeignKey(
                        name: "FK_Claims_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claims_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complains",
                columns: table => new
                {
                    ComplainID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainText = table.Column<string>(maxLength: 500, nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complains", x => x.ComplainID);
                    table.ForeignKey(
                        name: "FK_Complains_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complains_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suggestion",
                columns: table => new
                {
                    SuggestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SuggestionText = table.Column<string>(maxLength: 500, nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestion", x => x.SuggestionID);
                    table.ForeignKey(
                        name: "FK_Suggestion_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suggestion_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_TeacherID",
                table: "Admins",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_StudentID",
                table: "Claims",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_TeacherID",
                table: "Claims",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Complains_StudentID",
                table: "Complains",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Complains_TeacherID",
                table: "Complains",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_HistoryStudentID",
                table: "Students",
                column: "HistoryStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherID",
                table: "Students",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherID",
                table: "Subjects",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_StudentID",
                table: "Suggestion",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_TeacherID",
                table: "Suggestion",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_HistoryTeacherID",
                table: "Teachers",
                column: "HistoryTeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Complains");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Normas");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Suggestion");

            migrationBuilder.DropTable(
                name: "Trimestres");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "HistoryStudents");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "HistoryTeachers");
        }
    }
}
