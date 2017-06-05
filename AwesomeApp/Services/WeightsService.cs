using AwesomeApp.Domain;
using AwesomeApp.Models.Requests;
using AwesomeApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AwesomeApp.Services
{
    public class WeightsService : IWeightsService
    {
        public int Create(WeightCreateRequest model)
        {
            int id = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.WeightliftingExercises_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameterCollection parameters = command.Parameters;

                    parameters.AddWithValue("@workoutId", model.WorkoutId);
                    parameters.AddWithValue("@exerciseName", model.ExerciseName);
                    parameters.AddWithValue("@sets", model.Sets);
                    parameters.AddWithValue("@reps", model.Reps);
                    parameters.AddWithValue("@weight", model.Weight);

                    SqlParameter idParameter = new SqlParameter("@id", System.Data.SqlDbType.Int);
                    idParameter.Direction = System.Data.ParameterDirection.Output;
                    parameters.Add(idParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(idParameter.Value.ToString(), out id);
                }
            }

            return id;
        }

        public void Update(WeightUpdateRequest model)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.WeightliftingExercises_Update", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@id", model.Id);
                    parameters.AddWithValue("@workoutId", model.WorkoutId);
                    parameters.AddWithValue("@exerciseName", model.ExerciseName);
                    parameters.AddWithValue("@sets", model.Sets);
                    parameters.AddWithValue("@reps", model.Reps);
                    parameters.AddWithValue("@weight", model.Weight);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<WeightliftingExercise> GetAllWeightExercises()
        {
            List<WeightliftingExercise> list = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.WeightliftingExercises_SelectAll", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            WeightliftingExercise exercise = new WeightliftingExercise();
                            exercise.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            exercise.WorkoutId = reader.GetInt32(reader.GetOrdinal("WorkoutId"));
                            exercise.ExerciseName = reader["ExerciseName"].ToString();
                            exercise.Sets = reader.GetInt32(reader.GetOrdinal("Sets"));
                            exercise.Reps = reader.GetInt32(reader.GetOrdinal("Reps"));
                            exercise.Weight = reader.GetInt32(reader.GetOrdinal("Weight"));
                            exercise.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated"));
                            exercise.DateModified = reader.GetDateTime(reader.GetOrdinal("DateModified"));

                            if (list == null)
                            {
                                list = new List<WeightliftingExercise>();
                            }

                            list.Add(exercise);
                        }
                    }
                    reader.Close();
                }
            }
            return list;
        }
    }
}