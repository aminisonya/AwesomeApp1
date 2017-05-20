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
        private IWorkoutsService _workoutsService;

        public WorkoutsService(IWorkoutsService workoutsService)
        {
            _workoutsService = workoutsService;
        }

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
    }
}