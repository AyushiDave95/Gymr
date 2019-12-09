using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace Gymr.Model
{
    public class Dao
    {
        public static ObservableCollection<RoutineShow> GetMyExercises { get; }
        = new ObservableCollection<RoutineShow>();



        public static String GetScreen = "ITEM";
    }
}
