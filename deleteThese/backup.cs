// using System;
// using mis321_pa4_aevansmartinez;
// using mis321_pa4_aevansmartinez.database;
// using mis321_pa4_aevansmartinez.interfaces;
// using mis321_pa4_aevansmartinez.models;
// using MySql.Data.MySqlClient;


// namespace mis321_pa4_aevansmartinez{

//     class Program {

//         static void Main(string[] args){
//             Console.WriteLine("hello");
//             // DeleteExercise.DropExerciseTable();
//             // SaveExercise.CreateExerciseTable();

//             Exercise myExercise = new Exercise(){activityType="Running", distance=3.21, dateCompleted="2023-10-10"};
//             myExercise.Save.CreateExercise(myExercise);
//         }

//         // Console.WriteLine("Hello World!");

//         // ConnectionString db = new ConnectionString();
//         // using var con = new MySqlConnection(db.cs);
//         // con.Open();

//         // string stm = "SELECT * from exercises;";
//         // using var cmd = new MySqlCommand(stm, con);
//         // using MySqlDataReader rdr = cmd.ExecuteReader();
//         // Console.WriteLine("here");
//         // while (rdr.Read()){
//         //     Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDouble(2)}");
//         //     Console.WriteLine($"{rdr.GetDateTime(3)}");
//         // }
//         // Console.WriteLine("here2");
//         // con.Close();
//     }
// }


// // MySqlConnection con = new MySqlConnection(cs);
// // // string stm = "SELECT * from Exercise";
// // MySqlCommand cmd = new MySqlCommand(stm, con);
// // // while (rdr.Read()){
// // //     Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDouble32(2)} {rdr.GetDate(3)}")
// // // }

// // // cmd.CommandText = @"INSERT INTO Exercise(ID, ActivityType, Distance, DateCompleted)
// // //     VALUES (@id, @activityType, @distance, @dateCompleted)";
// // // cmd.Parameters.AddWithValue("@id", newID);
// // // cmd.Parameters.AddWithValue("@activityType", newActivityType);
// // // cmd.Parameters.AddWithValue("@distance", newDistance);
// // // cmd.Parameters.AddWithValue("@dateCompleted", newDateCompleted);
// // // cmd.Prepare();
// // // cmd.ExecuteNonQuery();

