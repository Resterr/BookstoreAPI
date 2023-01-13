using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bookstore");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CoverType = table.Column<string>(type: "text", nullable: false),
                    NumberOfPages = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalSchema: "Bookstore",
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "Bookstore",
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                schema: "Bookstore",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Bookstore",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "Bookstore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Bookstore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderBooks",
                schema: "Bookstore",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBooks", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrderBooks_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "Bookstore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBooks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Bookstore",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                schema: "Bookstore",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                schema: "Bookstore",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_BookId",
                schema: "Bookstore",
                table: "OrderBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                schema: "Bookstore",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                schema: "Bookstore",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "OrderBooks",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Publishers",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Bookstore");
        }
    }
}
