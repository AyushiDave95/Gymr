using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Gymr.Model
{
    public class ExerciseCategory : ContentPage
    {
        public Int32 ExerciseCategoryID
        { get; set; }

        public String Name
        { get; set; }

        public String Description
        { get; set; }

        //public List<ExerciseCategory> GetExercises()
        //{

            //List<ExerciseCategory> types = new List<ExcerciseCategory>()
            //{
            //    new ExerciseCategory { Name="Uper" },
            //    new ExerciseCategory { Name="Posterior" },
            //    new ExerciseCategory { Name="Muscle" }
            //};

           // return types;
       // }

        public ExerciseCategory()
        {
        }
    }
}

