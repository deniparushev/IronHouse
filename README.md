🏋️‍♂️ IronHouse - Fitness & Workout Tracking Application

IronHouse is an ASP.NET Core MVC web application built as part of the SoftUni C# Web Development course.
It helps users track their fitness journey by logging workouts, organizing exercises, and recording individual sets, reps, and weights.


🛠️ Tech Stack & Features

Framework: ASP.NET Core MVC (.NET 6+)
Database: SQL Server Express (`.\SQLEXPRESS`)
ORM: Entity Framework Core (Code-First)
Frontend: Bootstrap 5, HTML5, CSS3, Razor Views
Validation: Data Annotations & Custom `EntityValidationConstants`


🗄️ Database Architecture & Entities

The application consists of three fully connected entities:

1.   Exercise 
   * Pre-seeded exercise library (*Bench Press, Squat, Deadlift, etc.*).
   * Properties: `Id`, `Name`, `MuscleGroup`, `Description`.

2.   WorkoutLog
   * Tracks individual workout sessions.
   * Properties: `Id`, `Date`, `WorkoutType`, `Duration` (min), `CaloriesBurned`, `Notes`.
   * Includes full  CRUD  functionality (Create, Read, Edit, Delete).

3.   SetLog 
   * Represents individual sets performed within a workout.
   * Properties: `Id`, `WeightKg`, `Reps`, `WorkoutLogId`, `ExerciseId`.
   * Establishes Many-to-One relationships with both `WorkoutLog` and `Exercise`.


🚀 Getting Started

Prerequisites
* [.NET 6+ SDK](https://dotnet.microsoft.com/download)
* [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

Installation & Setup

1.  Clone the repository: 
   ```bash
   git clone [https://github.com/deniparushev/IronHouse.git](https://github.com/deniparushev/IronHouse.git)
   cd IronHouse
