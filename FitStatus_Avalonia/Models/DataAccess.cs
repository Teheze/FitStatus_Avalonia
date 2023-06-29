using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace FitStatus_Avalonia.Models
{
    public static class DataAccess
    {
        private static readonly string _connectionString = "Data Source=trainingDB.sqlite;Version=3;";

        static DataAccess()
        {
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
                CreateTables();
            }
        }

        private static bool DatabaseExists()
        {
            return System.IO.File.Exists("trainingDB.sqlite");
        }

        private static void CreateDatabase()
        {
            SQLiteConnection.CreateFile("trainingDB.sqlite");
        }

        private static void CreateTables()
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("CREATE TABLE Training (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, StartTime TEXT, EndTime TEXT)");
                cnn.Execute("CREATE TABLE Exercise (Id INTEGER PRIMARY KEY AUTOINCREMENT, TrainingId INTEGER, Name TEXT, Repetitions INTEGER, Sets INTEGER)");
                cnn.Execute("CREATE TABLE Bmi (Id INTEGER PRIMARY KEY AUTOINCREMENT, Info TEXT, Time DATE)");
                cnn.Execute("CREATE TABLE Bmr (Id INTEGER PRIMARY KEY AUTOINCREMENT, Weight DOUBLE PRECISION, Height DOUBLE PRECISION, Age INTEGER, Gender TEXT, Info TEXT, Time DATE)");
            }
        }

        public static List<Training> LoadTrainings()
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var output = cnn.Query<Training>("SELECT * FROM Training", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddTraining(Training training)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var sql = "INSERT INTO Training (Name) VALUES (@Name); SELECT last_insert_rowid();";
                var trainingId = cnn.ExecuteScalar<int>(sql, training);
                training.Id = trainingId; // Przypisanie wygenerowanego Id do obiektu Training
            }
        }

        public static void RemoveTraining(Training training)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("DELETE FROM Training WHERE Id = @Id", new { training.Id });
                cnn.Execute("DELETE FROM Exercise WHERE TrainingId = @Id", new { training.Id });
            }
        }

        public static List<Exercise> GetExercisesForTraining(int trainingId)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var output = cnn.Query<Exercise>("SELECT * FROM Exercise WHERE TrainingId = @TrainingId", new { TrainingId = trainingId });
                return output.ToList();
            }
        }

        public static void AddExerciseToTraining(Exercise exercise)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("INSERT INTO Exercise (Name, Repetitions, Sets, TrainingId) VALUES (@Name, @Repetitions, @Sets, @TrainingId)", exercise);
            }
        }

        public static void RemoveExercise(Exercise exercise)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("DELETE FROM Exercise WHERE Id = @Id", new { exercise.Id });
            }
        }

        public static void UpdateExercise(Exercise exercise)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("UPDATE Exercise SET Name = @Name, Repetitions = @Repetitions, Sets = @Sets WHERE Id = @Id", exercise);
            }
        }

        public static Training GetLastTraining()
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var output = cnn.QueryFirstOrDefault<Training>("SELECT * FROM Training ORDER BY EndTime DESC LIMIT 1");
                return output;
            }
        }

        public static void UpdateTraining(Training training)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("UPDATE Training SET Name = @Name, StartTime = @StartTime, EndTime = @EndTime WHERE Id = @Id", training);
            }
        }
        
        public static void AddBmiRecord(Bmi bmi)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("INSERT INTO Bmi (Info, Time) VALUES (@Info, @Time)", bmi);
            }
        }

        public static Bmi GetLastBmi()
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var result = cnn.QueryFirstOrDefault<Bmi>("SELECT * FROM Bmi ORDER BY Time DESC LIMIT 1");
                return result;
            }
        }

        public static void AddBmrRecord(Bmr bmr)
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                cnn.Execute("INSERT INTO Bmr (Weight, Height, Age, Gender, Info, Time) VALUES (@Weight, @Height, @Age, @Gender, @Info, @Time)", bmr);
            }
        }
        public static Bmr GetLastBmr()
        {
            using (IDbConnection cnn = new SQLiteConnection(_connectionString))
            {
                var result = cnn.QueryFirstOrDefault<Bmr>("SELECT * FROM Bmr ORDER BY Time DESC LIMIT 1");
                return result;
            }
        }
    }
}
