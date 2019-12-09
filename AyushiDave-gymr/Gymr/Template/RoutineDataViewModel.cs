using System;
using Gymr.Model;
using Gymr.BusinessLogic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace Gymr.Template
{
    public class RoutineDataViewModel
    {

        // RoutineData rd = new RoutineData();
        public ObservableCollection<RoutineShow> routines
        {
            get;
            set;
        } = new ObservableCollection<RoutineShow>();

        public RoutineDataViewModel()
        {
            BLPlanned bl = new BLPlanned();

            var list = new List<RoutineShow>();
            list =  bl.RoutineShowSend();
                  
            foreach (var item in list)
                routines.Add(item);

            //routines.Add(new RoutineShow() { RoutineName = "Hina",  ExcerciseName = "Cable Crunch" });
            //routines.Add(new RoutineShow() { RoutineName = "Ayushi",  ExcerciseName = "Zumba" });
            //routines.Add(new RoutineShow() { RoutineName = "Swathy",  ExcerciseName = "Aerobics" });
        }
    }
}