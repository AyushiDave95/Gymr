using System;

using Xamarin.Forms;
using SQLite;

namespace Gymr.Model
{
    public class Executed 
    {
        [PrimaryKey]
        public Int32 ID
        { get; set; }

        public Int32 RoutinePlannedID
        {
            get;
            set;
        }

        public Int32 RoutineID
        { get; set; }

        public Int32 ExerciseID
        { get; set; }

        public String Date
        { get; set; }

        public String Reps
        { get; set; }

        public Int32 Sets
        { get; set; }

        public String lbs
        {
            get;
            set;
        }
        public Executed()
        {
            ID = 0;
            RoutinePlannedID = 0;
            RoutineID = 0;
            ExerciseID = 0;
            Date = "01:01:01";
            Reps = "0";
            Sets = 0;
            lbs = "0";
        }
    }
}

