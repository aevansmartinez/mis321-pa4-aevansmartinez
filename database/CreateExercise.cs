using MySql.Data.MySqlClient;
using mis321_pa4_aevansmartinez.interfaces;
using mis321_pa4_aevansmartinez.models;

namespace mis321_pa4_aevansmartinez.database
{
    public class CreateExercise : ICreateExercise
    {        
        /*void ICreateExercise.CreateExerciseTable(Exercise myExercise){
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = @"CREATE TABLE exercises(id INTEGER PRIMARY KEY, activityType VARCHAR(45), distance DOUBLE, dateCompleted DATE, pinned TINYINT, deleted TINYINT)";
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        } */

        void ICreateExercise.CreateExercise(Exercise myExercise){
            ConnectionString myConnection = new ConnectionString();
            string connects = myConnection.cs;
            using var con = new MySqlConnection(connects);
            con.Open();

            string stm = @"INSERT INTO exercises(activityType, distance, dateCompleted) VALUES(@activityType, @distance, @dateCompleted)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@activityType", myExercise.activityType);
            cmd.Parameters.AddWithValue("@distance", myExercise.distance);
            cmd.Parameters.AddWithValue("@dateCompleted", myExercise.dateCompleted);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}