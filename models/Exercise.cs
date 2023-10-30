using mis321_pa4_aevansmartinez.interfaces;
using mis321_pa4_aevansmartinez.database;

namespace mis321_pa4_aevansmartinez.models
{
    public class Exercise
    {
        public int id {get; set;}
        public string activityType {get; set;}
        public double distance {get; set;}
        public string dateCompleted {get; set;} 
        public bool pinned {get; set;}
        public bool deleted {get; set;}
        
        public override string ToString()
        {
            return (id + " " + activityType + " " + distance + " " + pinned + " " + deleted);
        }
    }
}