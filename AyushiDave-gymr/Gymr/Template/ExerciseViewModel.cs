using System;
using Gymr.Model;
using System.Collections.Generic;
using Gymr.BusinessLogic;

namespace Gymr.Template
{
    public class ExerciseViewModel 
    {
        public IList<Exercise> GetExercises { get; private set; }

        public ExerciseViewModel()
        {
            BLExercise bLExercise = new BLExercise();
            GetExercises = bLExercise.ReadExercise();
        }

    }
}
