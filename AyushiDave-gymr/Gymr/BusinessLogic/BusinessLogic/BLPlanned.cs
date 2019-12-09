using System;
using System.Collections.Generic;
using Gymr.Model;
using SQLite;
using Xamarin.Forms;

namespace Gymr.BusinessLogic
{
    public class BLPlanned : ContentPage
    {
        SQLiteConnection db;
        BLExercise bLExercise;
        BLRoutine bLRoutine;

        List<Exercise> exercises;
        List<Routine> routines;
        public BLPlanned()
        {
            db = DataLinkLayer.DBconnect();

            bLExercise = new BLExercise();
            bLRoutine = new BLRoutine();

            exercises = bLExercise.ReadExercise();
            routines = bLRoutine.ReadRoutine();
            //Planned rpd = new Planned();
            //  Int32 d = InsertRoutinePlanned(rpd);
        }

        public List<Planned> ReadRoutinePlanned()
        {
            Planned p = new Planned();
            List<Planned> list = DataLinkLayer.DBread<Planned>(p);

            return list;

        }

        public Int32 InsertRoutinePlanned(Planned routinePlanned)
        {
            //int count = 0;


            //foreach (Planned rp in GetRoutinePlanned())
            //{
            //    Int32 x = DataLinkLayer.DBinsert<Planned>(rp);
            //    count += x;
            //}
            //return count;

            //var maxPK = db.Table<Planned>().OrderByDescending(c => c.ID).FirstOrDefault();

            var maxPK = db.Table<Planned>().OrderByDescending(c => c.ID).FirstOrDefault();
            Planned plannedRoutine = new Planned()
            {
                ID = (maxPK == null ? 1 : (maxPK.ID + 1)),
                RoutineID = routinePlanned.RoutineID,
                ExcerciseID = routinePlanned.ExcerciseID,
                Date = routinePlanned.Date,
                Reps = routinePlanned.Reps,
                Sets = routinePlanned.Sets,
                Lbs = routinePlanned.Lbs

            };

            return DataLinkLayer.DBinsert<Planned>(plannedRoutine);
        }

        public List<Planned> GetRoutinePlanned()
        {
            Int32 RPIDcounter = 1;     // ExcerciseIDcounter

            List<Planned> routine = new List<Planned>()
            {
                new Planned { ID=RPIDcounter++, ExcerciseID=0, Date="", RoutineID=0, Reps="", Sets=0 },
                new Planned { ID=RPIDcounter++, ExcerciseID=1, Date="", RoutineID=1, Reps="", Sets=2 },
                new Planned { ID=RPIDcounter++, ExcerciseID=2, Date="", RoutineID=0, Reps="", Sets=3 },

            };

            return routine;
        }

        public Boolean DeletePlanned(Planned p)
        {
            Int32 count = DataLinkLayer.DBdelete<Planned>(p);
            if (count > 0)
                return true;
            else
                return false;
        }


        public Planned ReadRoutinePlanned(ExerciseShow exerciseShow)
        {
            List<Planned> planneds = ReadRoutinePlanned();
            List<Exercise> exerciseList = DataLinkLayer.DBread<Exercise>(new Exercise());
            List<Routine> routineList = DataLinkLayer.DBread<Routine>(new Routine());

            Int32 routineID = routineList.Find(x => x.RoutineName.Equals(exerciseShow.RoutineName)).RoutineID;
            Int32 Exerciseid = exerciseList.Find(x => x.Name.Equals(exerciseShow.ExcerciseName)).ExcerciseID;


            return planneds.Find(x => x.RoutineID == routineID && x.ExcerciseID == Exerciseid);

        }

        // delete exercise from planned routine
        public Boolean DeletePlanned(ExerciseShow exerciseShow)
        {

            Planned toDelPlanned = ReadRoutinePlanned(exerciseShow);
            if (DataLinkLayer.DBdelete<Planned>(toDelPlanned) > 0)
            {
                return true;
            }

            return false;
        }


        public void UpdatePlanned(ExerciseShow exerciseShow)
        {
            Planned planned = ReadRoutinePlanned(exerciseShow);

            planned.Reps = exerciseShow.Reps;
            planned.Lbs = exerciseShow.Lbs;

            DataLinkLayer.DBupdate(planned);
        }

        public Int32 getPlannedID(String Exercisename, String RoutineName)
        {
            Int32 exID = exercises.Find(x => x.Name.Equals(Exercisename)).ExcerciseID;
            Int32 rID = routines.Find(x => x.RoutineName.Equals(RoutineName)).RoutineID;

            return ReadRoutinePlanned().Find(x => x.RoutineID == rID && x.ExcerciseID == exID).ID;
        }
    }
}