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
        public BLPlanned()
        {
            db = DataLinkLayer.DBconnect();
            //Planned rpd = new Planned();
          //  Int32 d = InsertRoutinePlanned(rpd);
        }

        public List<Planned> ReadRoutinePlanned()
        {
            Planned rp = new Planned();
            List<Planned> list = DataLinkLayer.DBread<Planned>(rp);



            String s = "";

            foreach (Planned l in list)
            {
                s = s + "\n" + l.ToString();
            }

            Console.WriteLine(s);

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

            var maxPK = db.Table<Planned>().OrderByDescending(c => c.ID).FirstOrDefault();

            Planned plannedRoutine = new Planned()
            {
                ID = (maxPK == null ? 1 : (maxPK.ID + 1)),
                RoutineID = routinePlanned.RoutineID,
                ExcerciseID = routinePlanned.ExcerciseID

            };

            return DataLinkLayer.DBinsert<Planned>(plannedRoutine);




        }



        public List<Planned> GetRoutinePlanned()
        {
            Int32 RPIDcounter = 1;     // ExcerciseIDcounter

            List<Planned> routine = new List<Planned>()
            {
                new Planned { ID=RPIDcounter++, ExcerciseID=0, Date="Today", RoutineID=0, Reps=0, Sets=0 },
                new Planned { ID=RPIDcounter++, ExcerciseID=1, Date="Today", RoutineID=1, Reps=1, Sets=2 },
                new Planned { ID=RPIDcounter++, ExcerciseID=2, Date="Today", RoutineID=0, Reps=3, Sets=3 },

            };

            return routine;
        }

        public List<RoutineShow> RoutineShowSend()
        {
            Routine rt = new Routine();
            //BLRoutine r = new BLRoutine();
            //Int32 c = r.InsertRoutine(rt);

            Planned rpd = new Planned();
            // Int32 d = InsertRoutinePlanned(rpd);

            Exercise ex = new Exercise();
            BLExercise addExerciseData = new BLExercise();
           // int exCount = addExerciseData.InsertExcercise(ex);

            BLRoutine addRoutineData = new BLRoutine();
//            int rCount = addRoutineData.InsertRoutine(rt);


           // int d = InsertRoutinePlanned(rpd);



            List<Routine> routine = DataLinkLayer.DBread<Routine>(new Routine());
            List<Exercise> exercise = DataLinkLayer.DBread<Exercise>(new Exercise());


            List<Planned> routinePlanned = DataLinkLayer.DBread<Planned>(rpd);
            Console.WriteLine(routinePlanned);

            List<RoutineShow> myRoutine = new List<RoutineShow>();

            {
                foreach (Planned rp in routinePlanned)
                {
                    String a = routine.Find(x => x.RoutineID == rp.RoutineID).RoutineName;
                    String b = exercise.Find(x => x.ExcerciseID == (rp.ExcerciseID)).Name;
                    myRoutine.Add(new RoutineShow { RoutineName = a, ExcerciseName = b });
                    Console.WriteLine(a + "-" + b);
                }
            };


            return myRoutine;


        }


        public int RoutineShowInsert(List<RoutineShow> rsList)
        {

            Planned rp = new Planned();
            Routine routine = new Routine();
            Exercise exercise = new Exercise();
            BLRoutine bLRoutine = new BLRoutine();

            Int32 Exerciseid,routineAdded,routineID = 0;

            List<Exercise> exerciseList = DataLinkLayer.DBread<Exercise>(new Exercise());
            List<Routine> routineList = DataLinkLayer.DBread<Routine>(new Routine());

            Console.WriteLine(routineList);

            foreach (RoutineShow routineShow in rsList)
            {

                Exerciseid = exerciseList.Find(x => x.Name.Equals(routineShow.ExcerciseName)).ExcerciseID;

               // add record in Routine table
                routine.RoutineName = routineShow.RoutineName;
                routineAdded= bLRoutine.InsertRoutine(routine);

                routineList = DataLinkLayer.DBread<Routine>(new Routine());
                routineID = routineList.Find(x => x.RoutineName.Equals(routineShow.RoutineName)).RoutineID;

                if (routineAdded != 0)
                {
                    rp.ExcerciseID = Exerciseid;
                    rp.RoutineID = routineID;

                    return InsertRoutinePlanned(rp);
                }


            }

            return 0;
        }

    }
}

