﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class dodana_datawygasniecia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataWygasniecia",
                table: "Oferty",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataWygasniecia",
                table: "Oferty");
        }
    }
}
