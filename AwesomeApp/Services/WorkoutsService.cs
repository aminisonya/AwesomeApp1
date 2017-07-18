using AwesomeApp.Domain;
using AwesomeApp.Models.Requests;
using AwesomeApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AwesomeApp.Services
{
    public class WorkoutsService : IWorkoutsService
    {
        public int Create(WorkoutCreateRequest model)
        {
            int id = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Workouts_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameterCollection parameters = command.Parameters;

                    parameters.AddWithValue("@workoutName", model.WorkoutName);
                    parameters.AddWithValue("@workoutNote", (object)model.WorkoutNote ?? DBNull.Value);

                    SqlParameter idParameter = new SqlParameter("@id", System.Data.SqlDbType.Int); //this is being received
                    idParameter.Direction = System.Data.ParameterDirection.Output;
                    parameters.Add(idParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    //return parameters
                    int.TryParse(idParameter.Value.ToString(), out id);
                }
            }

            return id;
        }

        public void Update(WorkoutUpdateRequest model)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Workouts_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameterCollection parameters = command.Parameters;
                    parameters.AddWithValue("@id", model.Id);
                    parameters.AddWithValue("@workoutName", model.WorkoutName);
                    parameters.AddWithValue("@workoutNote", (object)model.WorkoutNote ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //need to add Dictionary, and add all exerises for all workouts
        public List<Workout> GetAllWorkouts()
        {
            List<Workout> list = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Workouts_SelectAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        
                            Workout workout = new Workout();
                            workout.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            workout.WorkoutName = reader["WorkoutName"].ToString();
                            workout.WorkoutNote = reader["WorkoutNote"].ToString();
                            workout.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated"));
                            workout.DateModified = reader.GetDateTime(reader.GetOrdinal("DateModified"));

                        reader.NextResult();

                        if (reader.HasRows)
                        {
                            workout.WeightExercises = new List<WeightliftingExercise>();

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

                                workout.WeightExercises.Add(exercise);
                            }
                        }

                        if (list == null)
                            {
                                list = new List<Workout>();
                            }

                            list.Add(workout);
                        
                    }
                    reader.Close();
                }
            }
            return list;
        }

        public Workout GetById(int workoutId)
        {
            Workout workout = new Workout();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Workouts_SelectById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", workoutId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        
                            workout.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            workout.WorkoutName = reader["WorkoutName"].ToString();
                            workout.WorkoutNote = reader["WorkoutNote"].ToString();
                            workout.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated"));
                            workout.DateModified = reader.GetDateTime(reader.GetOrdinal("DateModified"));

                        reader.NextResult();

                            if (reader.HasRows)
                            {
                                workout.WeightExercises = new List<WeightliftingExercise>();

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

                                    workout.WeightExercises.Add(exercise);
                                }
                            }
                        
                    }
                    reader.Close();
                }
            }
            return workout;
        }
    }
}