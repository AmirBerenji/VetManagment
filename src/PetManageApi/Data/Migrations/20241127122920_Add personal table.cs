using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetManageApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addpersonaltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KindName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RegisterUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RegisterTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Desc = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    PersonalKindId = table.Column<int>(type: "integer", nullable: false),
                    RegisterUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RegisterTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personals_PersonalKinds_PersonalKindId",
                        column: x => x.PersonalKindId,
                        principalTable: "PersonalKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalId = table.Column<int>(type: "integer", nullable: false),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    RegisterUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RegisterTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteUserRef = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalBranches_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalBranches_BranchId",
                table: "PersonalBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalBranches_PersonalId",
                table: "PersonalBranches",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_PersonalKindId",
                table: "Personals",
                column: "PersonalKindId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalBranches");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "PersonalKinds");
        }
    }
}
