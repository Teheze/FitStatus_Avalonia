using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using FitStatus_Avalonia.ViewModels;

namespace FitStatus_Avalonia
{
    public static class DataAccess
    {
        private static readonly string _connectionString = "Data Source=trainingDB.sqlite;Version=3;";

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
                cnn.Execute("INSERT INTO Training (Name) VALUES (@Name)", training);
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
    }
}
