using System;
using Gymr.Model;

using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Gymr.Template
{
    public class MyExercisesViewModel
    {
  
      
        public MyExercisesViewModel()
        {
            //GetMyExercises = new List<MyExercises>();
        }

        public void AddData(RoutineShow myExercises)
        {
            Dao.GetMyExercises.Add(myExercises);
        }
    }
}
