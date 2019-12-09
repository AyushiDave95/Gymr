using System;
using System.Collections.Generic;
using Gymr.BusinessLogic;
using SQLite;
using Gymr.Model;
using Xamarin.Forms;

namespace Gymr.BusinessLogic
{
    public class BLRoutineShow
    {
        SQLiteConnection db;
        BLPlanned bLPlanned;
        BLExecuted bLExecuted;

        public BLRoutineShow()
        {
            db = DataLinkLayer.DBconnect();

            bLPlanned = new BLPlanned();
            bLExecuted = new BLExecuted();

             Executed executed = new Executed()
            {
                ID = 1,
                RoutinePlannedID = 0,
                RoutineID = 0,
                ExerciseID = 0,
                Date = "01:01:01",
                Reps = "0",
                Sets = 2,
                lbs = "0"
            };
          // db.CreateTable<Executed>();
            //bLExecuted.InsertRoutineExecuted(executed);
          
            //db.DropTable<Exercise>();
            //db.CreateTable<Exercise>();
            //BLExercise bl = new BLExercise();
            //bl.InsertExcercise(new Exercise());

            //db.DropTable<Routine>();
            //db.CreateTable<Routine>();
            //BLRoutine bL = new BLRoutine();
            //bL.InsertRoutine(new Routine());

            //db.DropTable<Planned>();
            //db.CreateTable<Planned>();

        }
        public List<RoutineShow> RoutineShowSend()
        {
            Routine rt = new Routine();
            Planned rpd = new Planned();
            Exercise ex = new Exercise();
            BLExercise addExerciseData = new BLExercise();
            BLRoutine addRoutineData = new BLRoutine();
            RoutineShow eachRoutineShow = new RoutineShow();

            //db.DropTable<Routine>();
            //db.CreateTable<Routine>();
            //BLRoutine bL = new BLRoutine();
            //bL.InsertRoutine(new Routine());

            //db.DropTable<Planned>();
            //db.CreateTable<Planned>();

            List<Routine> routine = DataLinkLayer.DBread<Routine>(new Routine());
            List<Exercise> exercise = DataLinkLayer.DBread<Exercise>(new Exercise());

            List<RoutineShow> finalList = new List<RoutineShow>();
            finalList.Clear();


            List<Planned> routinePlanned = DataLinkLayer.DBread<Planned>(rpd);
            Console.WriteLine(routinePlanned);

            RoutineShow myRoutineShow = new RoutineShow();
            foreach (Planned rp in routinePlanned)
            {

                String a = routine.Find(x => x.RoutineID == rp.RoutineID).RoutineName;
                String b = exercise.Find(x => x.ExcerciseID == (rp.ExcerciseID)).Name;
                Console.WriteLine(a + "-" + b + "-" + rp.Date);
                if (finalList.Find(x => x.RoutineName.Equals(a)) == null)
                {
                    RoutineShow routineShow = new RoutineShow();
                    routineShow.RoutineName = a;
                    routineShow.ExcerciseList.Add(b);
                    routineShow.ExTime = rp.Date;
                    routineShow.Sets.Add(rp.Sets);
                    routineShow.Reps.Add(rp.Reps);
                    routineShow.Lbs.Add(rp.Lbs);
                    finalList.Add(routineShow);

                }
                else
                {
                    finalList.Find(x => x.RoutineName.Equals(a)).ExcerciseList.Add(b);
                    finalList.Find(x => x.RoutineName.Equals(a)).ExTime = rp.Date;
                    finalList.Find(x => x.RoutineName.Equals(a)).Sets.Add(rp.Sets);
                    finalList.Find(x => x.RoutineName.Equals(a)).Reps.Add(rp.Reps);
                    finalList.Find(x => x.RoutineName.Equals(a)).Lbs.Add(rp.Lbs);

                }
            }

            return finalList;

        }

        public List<ExerciseShow> RoutineShowSend(String RoutineName)
        {
            List<ExerciseShow> exerciseShows = new List<ExerciseShow>();
            RoutineShow routine = RoutineShowSend().Find(x => x.RoutineName.Equals(RoutineName));
            List<String> exList = routine.ExcerciseList;
            String timeList = routine.ExTime;
            List<Int32> sets = routine.Sets;
            List<String> reps = routine.Reps;
            List<String> lbs = routine.Lbs;

           
            for (int i = 0; i < routine.ExcerciseList.Count; i++)
            {

                ExerciseShow exerciseShow = new ExerciseShow();
                exerciseShow.ExcerciseName = exList[i];
                char firstChar = Char.ToLower(exerciseShow.ExcerciseName[0]);
                exerciseShow.ImageURL = "alphabet/" + firstChar;
                exerciseShow.ExTime = timeList;
                exerciseShow.Sets = sets[i];
                exerciseShow.Reps = reps[i];
                exerciseShow.Lbs = lbs[i];
                exerciseShow.RoutineName = RoutineName;
                exerciseShows.Add(exerciseShow);


            }


            return exerciseShows;
        }


        public Int32 RoutineShowInsert(ExerciseShow exerciseShow)
        {
            List<RoutineShow> rsList = new List<RoutineShow>();

            Planned rp = new Planned();
            Routine routine = new Routine();
            Exercise exercise = new Exercise();
            BLRoutine bLRoutine = new BLRoutine();
            BLPlanned bLPlanned = new BLPlanned();

            Int32 Exerciseid, routineAdded, routineID = 0;

            List<Exercise> exerciseList = DataLinkLayer.DBread<Exercise>(new Exercise());
            List<Routine> routineList = DataLinkLayer.DBread<Routine>(new Routine());
            Exerciseid = exerciseList.Find(x => x.Name.Equals(exerciseShow.ExcerciseName)).ExcerciseID;

            // add record in Routine table
            routine.RoutineName = exerciseShow.RoutineName;
            routineAdded = bLRoutine.InsertRoutine(routine);

            routineList = DataLinkLayer.DBread<Routine>(new Routine());

            if (routineAdded != 0)
            {
                Console.WriteLine();
                routineID = routineList.Find(x => x.RoutineName.Equals(exerciseShow.RoutineName)).RoutineID;
                rp.ExcerciseID = Exerciseid;
                rp.RoutineID = routineID;
                rp.Date = exerciseShow.ExTime;
                rp.Sets = exerciseShow.Sets;
                rp.Reps = exerciseShow.Reps;
                rp.Lbs = exerciseShow.Lbs;
                Console.WriteLine();

                return bLPlanned.InsertRoutinePlanned(rp);
            }
            return 0;
        }

        public List<RoutineShow> RoutineOnDateSelected(String date)
        {
            List<RoutineShow> rsList = RoutineShowSend();

            List<RoutineShow> listOnDate = rsList.FindAll(x => x.ExTime.Equals(date));
            List<RoutineShow> routineShows = new List<RoutineShow>();
            String timeSend = "";

            int secs = 0, mins = 0, hrs = 0;

            foreach (RoutineShow routineShow in listOnDate)
            {
                foreach (String exercise in routineShow.ExcerciseList)
                {

                    Int32 plannedID = bLPlanned.getPlannedID(exercise, routineShow.RoutineName);

                    Executed exe = bLExecuted.ReadRoutineExecuted().Find(x => x.RoutinePlannedID == plannedID);
                    if (exe != null)
                    {

                        String timeString = bLExecuted.ReadRoutineExecuted().Find(x => x.RoutinePlannedID == plannedID).Date;

                        String[] timeInt = timeString.Split(':');

                        secs = secs + Int32.Parse(timeInt[2]);
                        mins += secs / 60;
                        mins = mins + Int32.Parse(timeInt[1]);
                        hrs += mins / 60;
                        hrs = hrs + Int32.Parse(timeInt[0]);

                        routineShow.Time = String.Format("{0:00}:{1:00}:{2:00}", hrs, mins, secs);
                        
                    }
                }
                secs = 0; mins = 0; hrs = 0;
                routineShows.Add(routineShow);
            }


            return listOnDate;
        }

        public List<String> GetSpecialDatesList()
        {
            List<String> listSpecialDates = new List<string>();

            foreach (RoutineShow routineShow in RoutineShowSend())
            {
                if (listSpecialDates.Find(x => x.ToString().Equals(routineShow.ExTime)) == null)
                {
                    listSpecialDates.Add(routineShow.ExTime);
                }
            }


            return listSpecialDates;
        }
    }

}

