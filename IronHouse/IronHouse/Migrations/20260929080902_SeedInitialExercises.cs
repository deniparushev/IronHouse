using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IronHouse.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { 1, "A chest exercise performed by pressing a weight upwards from a supine position.", "Chest", "Bench Press" },
                    { 2, "A lower body exercise that primarily targets the thighs and glutes.", "Legs", "Squat" },
                    { 3, "A compound movement that targets multiple muscle groups, including the back, legs, and core.", "Back", "Deadlift" },
                    { 4, "A shoulder exercise performed by pressing a weight overhead from shoulder height.", "Shoulders", "Overhead Press" },
                    { 5, "A bodyweight back exercise that targets the lats and rhomboids.", "Back", "Pull-up" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
