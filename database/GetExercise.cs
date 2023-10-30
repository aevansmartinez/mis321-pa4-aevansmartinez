using MySql.Data.MySqlClient;
using mis321_pa4_aevansmartinez.interfaces;
using mis321_pa4_aevansmartinez.models;

namespace mis321_pa4_aevansmartinez.database
{
    public class GetExercise : IGetExercise
    {
         Exercise IGetExercise.GetExercise(int id){
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;
            using MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from exercises where id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Exercise(){id = rdr.GetInt32(0), activityType = rdr.GetString(1), 
            dateCompleted = rdr.GetString(2), pinned = rdr.GetBoolean(3), 
            deleted = rdr.GetBoolean(4)};
        }
    }
}