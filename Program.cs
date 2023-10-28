// See https://aka.ms/new-console-template for more information
// using System.Data;
// using MySql.Data;
using mis321_pa4_aevansmartinez;
using MySql.Data.MySqlClient;
Console.WriteLine("Hello World!");

Database db = new Database();
using var con = new MySqlConnection(db.cs);
con.Open();

string stm = "SELECT * from exercises;";
using var cmd = new MySqlCommand(stm, con);
using MySqlDataReader rdr = cmd.ExecuteReader();
Console.WriteLine("here");
while (rdr.Read()){
    Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDouble(2)}");
    Console.WriteLine($"{rdr.GetDateTime(3)}");
}
Console.WriteLine("here2");
con.Close();


// MySqlConnection con = new MySqlConnection(cs);
// // string stm = "SELECT * from Exercise";
// MySqlCommand cmd = new MySqlCommand(stm, con);
// // while (rdr.Read()){
// //     Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDouble32(2)} {rdr.GetDate(3)}")
// // }

// // cmd.CommandText = @"INSERT INTO Exercise(ID, ActivityType, Distance, DateCompleted)
// //     VALUES (@id, @activityType, @distance, @dateCompleted)";
// // cmd.Parameters.AddWithValue("@id", newID);
// // cmd.Parameters.AddWithValue("@activityType", newActivityType);
// // cmd.Parameters.AddWithValue("@distance", newDistance);
// // cmd.Parameters.AddWithValue("@dateCompleted", newDateCompleted);
// // cmd.Prepare();
// // cmd.ExecuteNonQuery();

