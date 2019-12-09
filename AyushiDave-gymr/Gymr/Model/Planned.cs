using System;
using SQLite;
using Xamarin.Forms;

namespace Gymr.Model
{
    public class Planned 
    {
        [PrimaryKey]
        public Int32 ID
        { get; set; }

        public Int32 RoutineID
        { get; set; }

        public String Date
        { get; set; }

        public Int32 Reps
        { get; set; }

        public Int32 Sets
        { get; set; }

        public Int32 ExcerciseID
        { get; set; }

        public Planned()
        {
            ID = 0;
            RoutineID = 0;
            ExcerciseID = 0;
            Date = "Today";
            Reps = 0;
            Sets = 0;

        }
    }
}

