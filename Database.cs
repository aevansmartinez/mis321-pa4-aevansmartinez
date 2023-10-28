namespace mis321_pa4_aevansmartinez
{
    public class Database
    {
        private string hostServer {get; set;}
        private string username {get; set;}
        private string password {get; set;}
        private string port {get; set;}
        private string database {get; set;}
        public string cs {get; set;}

        public Database(){
            hostServer = "ohunm00fjsjs1uzy.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            username = "tmu328i8rjzqp7jh";
            password = "eacepdgd94s5ekzh";
            port = "3306";
            database = "b7t1a16akmtjgp4x";
            cs = $"server={hostServer};user={username};database={database};port={port};password={password}";

        }
    }
}