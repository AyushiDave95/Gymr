using System;
using Gymr.Model;
using Xamarin.Forms;
using System.Collections.Generic;


namespace Gymr.Template
{
    public class HomeExerciseViewModel 
    {
        public List<Model.HomeExercise> MyProperty
        {
            get;
            set;
        }

        public HomeExerciseViewModel()
        {
            MyProperty = new Model.HomeExercise().GetHomeExercises();
        }
    }
}

