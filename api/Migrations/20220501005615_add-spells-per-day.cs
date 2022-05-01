﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class addspellsperday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpellsPerDay",
                table: "Class",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":3,\"1\":1},\"3\":{\"0\":3,\"1\":2},\"4\":{\"0\":3,\"1\":2,\"2\":0},\"5\":{\"0\":3,\"1\":2,\"2\":1},\"6\":{\"0\":3,\"1\":2,\"2\":1},\"7\":{\"0\":3,\"1\":3,\"2\":2},\"8\":{\"0\":3,\"1\":3,\"2\":2,\"3\":0},\"9\":{\"0\":3,\"1\":3,\"2\":2,\"3\":1},\"10\":{\"0\":3,\"1\":3,\"2\":2,\"3\":1},\"11\":{\"0\":3,\"1\":3,\"2\":3,\"3\":2},\"12\":{\"0\":3,\"1\":3,\"2\":3,\"3\":2,\"4\":0},\"13\":{\"0\":3,\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"14\":{\"0\":3,\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"15\":{\"0\":3,\"1\":3,\"2\":3,\"3\":3,\"4\":2},\"16\":{\"0\":3,\"1\":3,\"2\":3,\"3\":3,\"4\":2,\"5\":0},\"17\":{\"0\":3,\"1\":3,\"2\":3,\"3\":3,\"4\":2,\"5\":1},\"18\":{\"0\":3,\"1\":3,\"2\":3,\"3\":3,\"4\":2,\"5\":1},\"19\":{\"0\":3,\"1\":3,\"2\":3,\"3\":3,\"4\":3,\"5\":2},\"20\":{\"0\":3,\"1\":3,\"2\":3,\"3\":3,\"4\":3,\"5\":2}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpellsPerDay",
                value: "{\"1\":{},\"2\":{},\"3\":{},\"4\":{\"1\":0},\"5\":{\"1\":1},\"6\":{\"1\":1},\"7\":{\"1\":1,\"2\":0},\"8\":{\"1\":1,\"2\":1},\"9\":{\"1\":2,\"2\":1},\"10\":{\"1\":2,\"2\":1,\"3\":0},\"11\":{\"1\":2,\"2\":1,\"3\":1},\"12\":{\"1\":2,\"2\":2,\"3\":1},\"13\":{\"1\":3,\"2\":2,\"3\":1,\"4\":0},\"14\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"15\":{\"1\":3,\"2\":2,\"3\":2,\"4\":1},\"16\":{\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"17\":{\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"18\":{\"1\":4,\"2\":3,\"3\":2,\"4\":2},\"19\":{\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"20\":{\"1\":4,\"2\":4,\"3\":3,\"4\":3}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 5,
                column: "SpellsPerDay",
                value: "{\"1\":{},\"2\":{},\"3\":{},\"4\":{\"1\":1},\"5\":{\"1\":1},\"6\":{\"1\":1},\"7\":{\"1\":1,\"2\":1},\"8\":{\"1\":1,\"2\":1},\"9\":{\"1\":2,\"2\":1},\"10\":{\"1\":2,\"2\":1,\"3\":1},\"11\":{\"1\":2,\"2\":1,\"3\":1},\"12\":{\"1\":2,\"2\":2,\"3\":1},\"13\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"14\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"15\":{\"1\":3,\"2\":2,\"3\":2,\"4\":1},\"16\":{\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"17\":{\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"18\":{\"1\":4,\"2\":3,\"3\":2,\"4\":2},\"19\":{\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"20\":{\"1\":4,\"2\":4,\"3\":3,\"4\":2}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 6,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":4,\"1\":2},\"3\":{\"0\":4,\"1\":2,\"2\":1},\"4\":{\"0\":4,\"1\":3,\"2\":2},\"5\":{\"0\":4,\"1\":3,\"2\":2,\"3\":1},\"6\":{\"0\":4,\"1\":3,\"2\":3,\"3\":2},\"7\":{\"0\":4,\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"8\":{\"0\":4,\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"9\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":2,\"5\":1},\"10\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":3,\"5\":2},\"11\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":2,\"6\":1},\"12\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":3,\"6\":2},\"13\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":2,\"7\":1},\"14\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":3,\"7\":2},\"15\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":2,\"8\":1},\"16\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":3,\"8\":2},\"17\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":2,\"9\":1},\"18\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":3,\"9\":2},\"19\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":3,\"9\":3},\"20\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":4,\"9\":4}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 7,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":4,\"1\":2},\"3\":{\"0\":4,\"1\":2,\"2\":1},\"4\":{\"0\":4,\"1\":3,\"2\":2},\"5\":{\"0\":4,\"1\":3,\"2\":2,\"3\":1},\"6\":{\"0\":4,\"1\":3,\"2\":3,\"3\":2},\"7\":{\"0\":4,\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"8\":{\"0\":4,\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"9\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":2,\"5\":1},\"10\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":3,\"5\":2},\"11\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":2,\"6\":1},\"12\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":3,\"6\":2},\"13\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":2,\"7\":1},\"14\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":3,\"7\":2},\"15\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":2,\"8\":1},\"16\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":3,\"8\":2},\"17\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":2,\"9\":1},\"18\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":3,\"9\":2},\"19\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":3,\"9\":3},\"20\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":4,\"9\":4}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 8,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 9,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 10,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 11,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":4,\"1\":2},\"3\":{\"0\":4,\"1\":3},\"4\":{\"0\":4,\"1\":3,\"2\":1},\"5\":{\"0\":4,\"1\":4,\"2\":2},\"6\":{\"0\":5,\"1\":4,\"2\":3},\"7\":{\"0\":5,\"1\":4,\"2\":3,\"3\":1},\"8\":{\"0\":5,\"1\":4,\"2\":4,\"3\":2},\"9\":{\"0\":5,\"1\":5,\"2\":4,\"3\":3},\"10\":{\"0\":5,\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"0\":5,\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"0\":5,\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"0\":5,\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"0\":5,\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"0\":5,\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"0\":5,\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"0\":5,\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"0\":5,\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"0\":5,\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"0\":5,\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 12,
                column: "SpellsPerDay",
                value: "{\"1\":{},\"2\":{},\"3\":{},\"4\":{\"1\":1},\"5\":{\"1\":1},\"6\":{\"1\":1},\"7\":{\"1\":1,\"2\":1},\"8\":{\"1\":1,\"2\":1},\"9\":{\"1\":2,\"2\":1},\"10\":{\"1\":2,\"2\":1,\"3\":1},\"11\":{\"1\":2,\"2\":1,\"3\":1},\"12\":{\"1\":2,\"2\":2,\"3\":1},\"13\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"14\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"15\":{\"1\":3,\"2\":2,\"3\":2,\"4\":1},\"16\":{\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"17\":{\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"18\":{\"1\":4,\"2\":3,\"3\":2,\"4\":2},\"19\":{\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"20\":{\"1\":4,\"2\":4,\"3\":3,\"4\":2}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 13,
                column: "SpellsPerDay",
                value: "{\"1\":{},\"2\":{},\"3\":{},\"4\":{\"1\":1},\"5\":{\"1\":1},\"6\":{\"1\":1},\"7\":{\"1\":1,\"2\":1},\"8\":{\"1\":1,\"2\":1},\"9\":{\"1\":2,\"2\":1},\"10\":{\"1\":2,\"2\":1,\"3\":1},\"11\":{\"1\":2,\"2\":1,\"3\":1},\"12\":{\"1\":2,\"2\":2,\"3\":1},\"13\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"14\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"15\":{\"1\":3,\"2\":2,\"3\":2,\"4\":1},\"16\":{\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"17\":{\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"18\":{\"1\":4,\"2\":3,\"3\":2,\"4\":2},\"19\":{\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"20\":{\"1\":4,\"2\":4,\"3\":3,\"4\":2}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 14,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 15,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":3},\"2\":{\"1\":4},\"3\":{\"1\":5},\"4\":{\"1\":6,\"2\":3},\"5\":{\"1\":6,\"2\":4},\"6\":{\"1\":6,\"2\":5,\"3\":3},\"7\":{\"1\":6,\"2\":6,\"3\":4},\"8\":{\"1\":6,\"2\":6,\"3\":5,\"4\":3},\"9\":{\"1\":6,\"2\":6,\"3\":6,\"4\":4},\"10\":{\"1\":6,\"2\":6,\"3\":6,\"4\":5,\"5\":3},\"11\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":4},\"12\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":5,\"6\":3},\"13\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":4},\"14\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":5,\"7\":3},\"15\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":4},\"16\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":5,\"8\":3},\"17\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":4},\"18\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":5,\"9\":3},\"19\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":6,\"9\":4},\"20\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":6,\"9\":6}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 16,
                column: "SpellsPerDay",
                value: "{\"1\":{},\"2\":{},\"3\":{},\"4\":{\"1\":0},\"5\":{\"1\":1},\"6\":{\"1\":1},\"7\":{\"1\":1,\"2\":0},\"8\":{\"1\":1,\"2\":1},\"9\":{\"1\":2,\"2\":1},\"10\":{\"1\":2,\"2\":1,\"3\":0},\"11\":{\"1\":2,\"2\":1,\"3\":1},\"12\":{\"1\":2,\"2\":2,\"3\":1},\"13\":{\"1\":3,\"2\":2,\"3\":1,\"4\":0},\"14\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"15\":{\"1\":3,\"2\":2,\"3\":2,\"4\":1},\"16\":{\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"17\":{\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"18\":{\"1\":4,\"2\":3,\"3\":2,\"4\":2},\"19\":{\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"20\":{\"1\":4,\"2\":4,\"3\":3,\"4\":3}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 17,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":3},\"2\":{\"1\":4},\"3\":{\"1\":5},\"4\":{\"1\":6,\"2\":3},\"5\":{\"1\":6,\"2\":4},\"6\":{\"1\":6,\"2\":5,\"3\":3},\"7\":{\"1\":6,\"2\":6,\"3\":4},\"8\":{\"1\":6,\"2\":6,\"3\":5,\"4\":3},\"9\":{\"1\":6,\"2\":6,\"3\":6,\"4\":4},\"10\":{\"1\":6,\"2\":6,\"3\":6,\"4\":5,\"5\":3},\"11\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":4},\"12\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":5,\"6\":3},\"13\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":4},\"14\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":5,\"7\":3},\"15\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":4},\"16\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":5,\"8\":3},\"17\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":4},\"18\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":5,\"9\":3},\"19\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":6,\"9\":4},\"20\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":6,\"9\":6}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 18,
                column: "SpellsPerDay",
                value: "{\"1\":{},\"2\":{},\"3\":{},\"4\":{\"1\":0},\"5\":{\"1\":1},\"6\":{\"1\":1},\"7\":{\"1\":1,\"2\":0},\"8\":{\"1\":1,\"2\":1},\"9\":{\"1\":2,\"2\":1},\"10\":{\"1\":2,\"2\":1,\"3\":0},\"11\":{\"1\":2,\"2\":1,\"3\":1},\"12\":{\"1\":2,\"2\":2,\"3\":1},\"13\":{\"1\":3,\"2\":2,\"3\":1,\"4\":0},\"14\":{\"1\":3,\"2\":2,\"3\":1,\"4\":1},\"15\":{\"1\":3,\"2\":2,\"3\":2,\"4\":1},\"16\":{\"1\":3,\"2\":3,\"3\":2,\"4\":1},\"17\":{\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"18\":{\"1\":4,\"2\":3,\"3\":2,\"4\":2},\"19\":{\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"20\":{\"1\":4,\"2\":4,\"3\":3,\"4\":3}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 19,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":4,\"1\":2},\"3\":{\"0\":4,\"1\":2,\"2\":1},\"4\":{\"0\":4,\"1\":3,\"2\":2},\"5\":{\"0\":4,\"1\":3,\"2\":2,\"3\":1},\"6\":{\"0\":4,\"1\":3,\"2\":3,\"3\":2},\"7\":{\"0\":4,\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"8\":{\"0\":4,\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"9\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":2,\"5\":1},\"10\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":3,\"5\":2},\"11\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":2,\"6\":1},\"12\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":3,\"6\":2},\"13\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":2,\"7\":1},\"14\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":3,\"7\":2},\"15\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":2,\"8\":1},\"16\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":3,\"8\":2},\"17\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":2,\"9\":1},\"18\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":3,\"9\":2},\"19\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":3,\"9\":3},\"20\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":4,\"9\":4}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "SpellsPerDay" },
                values: new object[] { "Skald", "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}" });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 22,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":3},\"2\":{\"1\":4},\"3\":{\"1\":5},\"4\":{\"1\":6,\"2\":3},\"5\":{\"1\":6,\"2\":4},\"6\":{\"1\":6,\"2\":5,\"3\":3},\"7\":{\"1\":6,\"2\":6,\"3\":4},\"8\":{\"1\":6,\"2\":6,\"3\":5,\"4\":3},\"9\":{\"1\":6,\"2\":6,\"3\":6,\"4\":4},\"10\":{\"1\":6,\"2\":6,\"3\":6,\"4\":5,\"5\":3},\"11\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":4},\"12\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":5,\"6\":3},\"13\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":4},\"14\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":5,\"7\":3},\"15\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":4},\"16\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":5,\"8\":3},\"17\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":4},\"18\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":5,\"9\":3},\"19\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":6,\"9\":4},\"20\":{\"1\":6,\"2\":6,\"3\":6,\"4\":6,\"5\":6,\"6\":6,\"7\":6,\"8\":6,\"9\":6}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 23,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 24,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 25,
                column: "SpellsPerDay",
                value: "{\"1\":{\"1\":1},\"2\":{\"1\":2},\"3\":{\"1\":3},\"4\":{\"1\":3,\"2\":1},\"5\":{\"1\":4,\"2\":2},\"6\":{\"1\":4,\"2\":3},\"7\":{\"1\":4,\"2\":3,\"3\":1},\"8\":{\"1\":4,\"2\":4,\"3\":2},\"9\":{\"1\":5,\"2\":4,\"3\":3},\"10\":{\"1\":5,\"2\":4,\"3\":3,\"4\":1},\"11\":{\"1\":5,\"2\":4,\"3\":4,\"4\":2},\"12\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3},\"13\":{\"1\":5,\"2\":5,\"3\":4,\"4\":3,\"5\":1},\"14\":{\"1\":5,\"2\":5,\"3\":4,\"4\":4,\"5\":2},\"15\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3},\"16\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":3,\"6\":1},\"17\":{\"1\":5,\"2\":5,\"3\":5,\"4\":4,\"5\":4,\"6\":2},\"18\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":4,\"6\":3},\"19\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":4},\"20\":{\"1\":5,\"2\":5,\"3\":5,\"4\":5,\"5\":5,\"6\":5}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 26,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":4,\"1\":2},\"3\":{\"0\":4,\"1\":2,\"2\":1},\"4\":{\"0\":4,\"1\":3,\"2\":2},\"5\":{\"0\":4,\"1\":3,\"2\":2,\"3\":1},\"6\":{\"0\":4,\"1\":3,\"2\":3,\"3\":2},\"7\":{\"0\":4,\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"8\":{\"0\":4,\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"9\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":2,\"5\":1},\"10\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":3,\"5\":2},\"11\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":2,\"6\":1},\"12\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":3,\"6\":2},\"13\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":2,\"7\":1},\"14\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":3,\"7\":2},\"15\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":2,\"8\":1},\"16\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":3,\"8\":2},\"17\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":2,\"9\":1},\"18\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":3,\"9\":2},\"19\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":3,\"9\":3},\"20\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":4,\"9\":4}}");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 27,
                column: "SpellsPerDay",
                value: "{\"1\":{\"0\":3,\"1\":1},\"2\":{\"0\":4,\"1\":2},\"3\":{\"0\":4,\"1\":2,\"2\":1},\"4\":{\"0\":4,\"1\":3,\"2\":2},\"5\":{\"0\":4,\"1\":3,\"2\":2,\"3\":1},\"6\":{\"0\":4,\"1\":3,\"2\":3,\"3\":2},\"7\":{\"0\":4,\"1\":4,\"2\":3,\"3\":2,\"4\":1},\"8\":{\"0\":4,\"1\":4,\"2\":3,\"3\":3,\"4\":2},\"9\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":2,\"5\":1},\"10\":{\"0\":4,\"1\":4,\"2\":4,\"3\":3,\"4\":3,\"5\":2},\"11\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":2,\"6\":1},\"12\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":3,\"5\":3,\"6\":2},\"13\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":2,\"7\":1},\"14\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":3,\"6\":3,\"7\":2},\"15\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":2,\"8\":1},\"16\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":3,\"7\":3,\"8\":2},\"17\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":2,\"9\":1},\"18\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":3,\"8\":3,\"9\":2},\"19\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":3,\"9\":3},\"20\":{\"0\":4,\"1\":4,\"2\":4,\"3\":4,\"4\":4,\"5\":4,\"6\":4,\"7\":4,\"8\":4,\"9\":4}}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpellsPerDay",
                table: "Class");

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Scald");
        }
    }
}
