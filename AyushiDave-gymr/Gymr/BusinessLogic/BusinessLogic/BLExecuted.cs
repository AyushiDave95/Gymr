using System;
using System.Collections.Generic;
using Gymr.Model;
using SQLite;

namespace Gymr.BusinessLogic
{
    public class BLExecuted
    {

        SQLiteConnection db;
        Executed rExecuted = new Executed();
        Routine routine = new Routine();
        Exercise exercise = new Exercise();

        BLRoutine bLRoutine = new BLRoutine();
        BLExercise bLExercise = new BLExercise();
        BLPlanned bLPlanned = new BLPlanned();

        List<Exercise> exerciseList;
        List<Routine> routineList;
        List<Planned> planneds;
        List<RoutineShow> rsList;

        public BLExecuted()
        {
            db = DataLinkLayer.DBconnect();
            //db.CreateTable<Executed>();
           


              exerciseList = bLExercise.ReadExercise();
            routineList = bLRoutine.ReadRoutine();
            planneds = bLPlanned.ReadRoutinePlanned();


            //Planned rpd = new Planned();
            //  Int32 d = InsertRoutinePlanned(rpd);
        }

        public List<Executed> ReadRoutineExecuted()
        {

            List<Executed> list = DataLinkLayer.DBread<Executed>(rExecuted);

            return list;

        }

        public Int32 InsertRoutineExecuted(Executed ExecutedRoutine)
        {

            var maxPK = db.Table<Executed>().OrderByDescending(c => c.ID).FirstOrDefault();
            if (maxPK != null)
            {

                rExecuted = new Executed()
                {
                    ID = (maxPK == null ? 1 : (maxPK.ID + 1)),
                    RoutineID = ExecutedRoutine.RoutineID,
                    ExerciseID = ExecutedRoutine.ExerciseID,
                    Date = ExecutedRoutine.Date,
                    Reps = ExecutedRoutine.Reps,
                    Sets = ExecutedRoutine.Sets,
                    lbs = ExecutedRoutine.lbs

                };
            }
            else
            {

            db.CreateTable<Executed>();
            rExecuted = new Executed()
                {
                    ID = 0,
                    RoutineID = ExecutedRoutine.RoutineID,
                    ExerciseID = ExecutedRoutine.ExerciseID,
                    Date = ExecutedRoutine.Date,
                    Reps = ExecutedRoutine.Reps,
                    Sets = ExecutedRoutine.Sets,
                    lbs = ExecutedRoutine.lbs

                };
            }
            return DataLinkLayer.DBinsert<Executed>(rExecuted);
        }


        public Int32 RoutineShowInsertExecuted(ExerciseShow exerciseShow)
        {

            rsList = new List<RoutineShow>();

            Int32 Exerciseid, routineAdded, routineID = 0;


            Exerciseid = exerciseList.Find(x => x.Name.Equals(exerciseShow.ExcerciseName)).ExcerciseID;

            // add record in Routine table
            routine.RoutineName = exerciseShow.RoutineName;
            routineAdded = bLRoutine.InsertRoutine(routine);

            routineList = bLRoutine.ReadRoutine();

            if (routineAdded != 0)
            {
                Console.WriteLine();
                routineID = routineList.Find(x => x.RoutineName.Equals(exerciseShow.RoutineName)).RoutineID;
                rExecuted.RoutinePlannedID = planneds.Find(x => (x.ExcerciseID == Exerciseid) && (x.RoutineID == routineID)).ID;
                rExecuted.ExerciseID = Exerciseid;
                rExecuted.RoutineID = routineID;
                rExecuted.Date = exerciseShow.ExTime;
                rExecuted.Sets = exerciseShow.Sets;
                rExecuted.Reps = exerciseShow.Reps;
                rExecuted.lbs = exerciseShow.Lbs;
                Console.WriteLine();

                return InsertRoutineExecuted(rExecuted);
            }
            return 0;
        }


    }
}
