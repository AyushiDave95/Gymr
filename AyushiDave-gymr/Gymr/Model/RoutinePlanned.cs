using System;
using SQLite;

using Xamarin.Forms;

namespace Gymr.Model
{
    public class RoutinePlanned : ContentPage
    {
        [PrimaryKey]
        public Int32 ID
	{get; set;}
        public Int32 RoutinePlannedID
        { get; set; }

        public Int32 RoutineID
        { get; set; }

        public String Date
        { get; set; }

        public Int32 Reps
        { get; set; }

        public Int32 Sets
        { get; set;  }

        public Int32 ExcertciseID
        { get; set; }

        public RoutinePlanned()
        {
            ID = 0;
            RoutineID = 0;
            ExcertciseID = 0;
            Date = "Today";
            Reps = 0;
            Sets = 0;

        }
 }
}

