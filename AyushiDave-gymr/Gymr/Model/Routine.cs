using System;
using SQLite;
using System.Collections.Generic;

namespace Gymr.Model
{
    public class Routine
    {
        [PrimaryKey]
        public Int32 RoutineID
        { get; set; }


        public String RoutineName {
           get;
           set;
		}

        public Routine()
        {
            RoutineID = 0;
            RoutineName = "Aroutine";
        }

        public override string ToString()
        {
            return "ID: "+RoutineID+"-"+"Name: " + RoutineName;
        }


        //public List<Routine>GetRoutine()
        //{


        //	List<Routine> routines = new List<Routine>()
        //	{
        //		new Routine { RoutineName="Nirali", NoOfSet="1", ExerciseName="Barbell" },
        //             new Routine { RoutineName="Hardik", NoOfSet="1", ExerciseName="Barbell" },
        //              new Routine { RoutineName="Ayushi", NoOfSet="2", ExerciseName="Barbell" },
        //              new Routine { RoutineName="Swathy", NoOfSet="3", ExerciseName="Barbell" }

        //          };

        //	return routines;
        //}
    }
}
