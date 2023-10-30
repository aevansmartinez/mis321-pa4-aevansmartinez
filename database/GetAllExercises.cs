using MySql.Data.MySqlClient;
using mis321_pa4_aevansmartinez.interfaces;
using mis321_pa4_aevansmartinez.models;

namespace mis321_pa4_aevansmartinez.database
{
    public class GetAllExercises : IGetAllExercises
    {
        List<Exercise> IGetAllExercises.GetAllExercises(){
            List<Exercise> exercises = new List<Exercise>();
            
            ConnectionString connect = new ConnectionString();
            string cs = connect.cs;
            using MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from exercises";
            using MySqlCommand cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Exercise> allExercises = new List<Exercise>();
            while(rdr.Read())
            {
                allExercises.Add(new Exercise(){id = rdr.GetInt32(0), activityType = rdr.GetString(1),
                  distance = rdr.GetDouble(2), dateCompleted = rdr.GetString(3), pinned = rdr.GetBoolean(4),
                  deleted = rdr.GetBoolean(5)});
            } 
            return allExercises;
        }
    }
}