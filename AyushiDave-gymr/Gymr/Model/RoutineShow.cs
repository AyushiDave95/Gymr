using System;

using Xamarin.Forms;

namespace Gymr.Model
{
    public class RoutineShow : ContentPage
    {
        public RoutineShow()
        {
            RoutineName = "";
            ExcerciseName = "";
            Time = "";
            ImageURL = "";

        }

        public String RoutineName
        { get; set; }

        public String ExcerciseName
        { get; set; }

        public String Time
        {
            get;
            set;
        }

        public String ImageURL
        {
            get;
            set;
        }
        //Int32 Sets
        //{ get; set; }

        //Int32 Reps
        //{ get; set; }


    }
}

