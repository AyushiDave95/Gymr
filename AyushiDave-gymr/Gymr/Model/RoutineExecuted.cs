using System;

using Xamarin.Forms;
using SQLite;

namespace Gymr.Model
{
    public class RoutineExecuted : ContentPage
    {
        [PrimaryKey]
        public Int32 RoutineExecutedID
        { get; set; }

        public Int32 RoutineID
        { get; set; }

        public String Date
        { get; set; }

        public Int32 Reps
        { get; set; }

        public Int32 Sets
        { get; set; }
    }
}

