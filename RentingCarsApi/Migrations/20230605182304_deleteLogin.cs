﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingCarsApi.Migrations
{
    /// <inheritdoc />
    public partial class deleteLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "AspNetUsers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Login");
        }
    }
}
