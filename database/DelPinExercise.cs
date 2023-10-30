using MySql.Data.MySqlClient;
using mis321_pa4_aevansmartinez.interfaces;
using mis321_pa4_aevansmartinez.models;

namespace mis321_pa4_aevansmartinez.database
{
    public class DelPinExercise : IDelPinExercise
    {
        void IDelPinExercise.DelPinExercise(Exercise myExercise){
            ConnectionString myConnection = new ConnectionString();
            string connects = myConnection.cs;
            using var con = new MySqlConnection(connects);
            con.Open();
            
            string stm = @"UPDATE exercises SET activityType = @activityType, dateCompleted = @dateCompleted, pinned = @pinned, deleted = @deleted WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", myExercise.id);
            cmd.Parameters.AddWithValue("@activityType", myExercise.activityType);
            cmd.Parameters.AddWithValue("@dateCompleted", myExercise.dateCompleted);
            cmd.Parameters.AddWithValue("@pinned", myExercise.pinned);
            cmd.Parameters.AddWithValue("@deleted", myExercise.deleted);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }

    /*public static void DropExerciseTable(){
            ConnectionString myConnection = new ConnectionString();
            string connects = myConnection.cs;
            using var con = new MySqlConnection(connects);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS exercises";
            using var cmd = new MySqlCommand(stm, con);
            
            cmd.ExecuteNonQuery();
    } */
}