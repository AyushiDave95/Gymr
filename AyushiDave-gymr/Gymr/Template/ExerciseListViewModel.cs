using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Gymr.Model;
namespace Gymr.Template
{
    public class ExerciseListViewModel
    {

        public IList<Exercise> Items { get; private set; }
        public List<ObservableGroupCollection<String,Exercise>> GroupedData { get; set; }


        public int IteamCount { get; private set; }

        public ExerciseListViewModel()
        {
            var data = new ExerciseViewModel();
            Items = data.GetExercises.OrderBy(c => c.Name).ToList();
           

          var Data = Items.OrderBy(p => p.Name)
               .GroupBy(p => p.Name[0].ToString())
                                  .Select(p => new ObservableGroupCollection<string, Exercise>(p))
                                   .ToList();

            GroupedData = Data;
            IteamCount = data.GetExercises.Count;
        }
    
    }
}
