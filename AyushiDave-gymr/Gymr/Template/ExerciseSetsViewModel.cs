
using System;
using Gymr.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Gymr.Template
{

   
    public class ExerciseSetsViewModel
    {


        public ObservableCollection<ExerciseSets> GetExerciseSets
        {
            get;
            set;
        } 



        public ExerciseSetsViewModel()
        {
            GetExerciseSets = new ObservableCollection<ExerciseSets>();
            GetExerciseSets.Add(new ExerciseSets { SetNumber = 1, Value_1 = 1, Value_2 = 1 });
          
        }

        public Command<ExerciseSets> RemoveCommand
        {
            get
            {
                return new Command<ExerciseSets>((exerciseSets) => {
                    GetExerciseSets.Remove(exerciseSets);
                });
            }
        }
        
        
        

    }
}
