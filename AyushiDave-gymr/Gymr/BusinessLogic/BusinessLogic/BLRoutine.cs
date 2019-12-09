using System;
using SQLite;
using Gymr.Model;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Gymr.BusinessLogic
{
    public class BLRoutine : ContentPage
    {
        SQLiteConnection db;

        public BLRoutine()
        {
            db = DataLinkLayer.DBconnect();
            //ReadRoutine(db);

        }
        public List<Routine> ReadRoutine()
        {
            Routine p = new Routine();
            List<Routine> list = DataLinkLayer.DBread<Routine>(p);

            return list;
            //await DisplayAlert(null, s, "ok");
        }


        public List<Routine> AddRoutineDB()
        {
            Int32 RIDcounter = 0;   // ExcerciseIDcounter

            List<Routine> routine = new List<Routine>()
            {
                new Routine { RoutineID=RIDcounter++, RoutineName="Morning"},
                new Routine { RoutineID=RIDcounter++, RoutineName="AyushiMorning"},
                new Routine { RoutineID=RIDcounter++, RoutineName="NiraliEvening"},
            };

            return routine;
        }

        public Int32 InsertRoutine(Routine r)
        {
            //Int32 count=0;

            //foreach (Routine rp in AddRoutineDB())
            //{
            //    Int32 x = DataLinkLayer.DBinsert<Routine>(rp);
            //    count += x;
            //}

            //return count;
            var maxPK = db.Table<Routine>().OrderByDescending(c => c.RoutineID).FirstOrDefault();

            Routine routine = new Routine()
            {
                RoutineID = (maxPK == null ? 1 : (maxPK.RoutineID + 1)),
                RoutineName = r.RoutineName
            };

            return DataLinkLayer.DBinsert<Routine>(routine);



        }

        public Boolean DeleteRoutine(String RoutineName)
        {
            Boolean PlannedCheck = false;
            BLPlanned bLPlanned = new BLPlanned();

            List<Routine> routines = ReadRoutine();
            List<Planned> planneds = bLPlanned.ReadRoutinePlanned();

            Routine routine = routines.Find(x => x.RoutineName == RoutineName);
            List<Planned> PlannedsToDelete = planneds.FindAll(x => x.RoutineID == routine.RoutineID);


            foreach (Planned planned in PlannedsToDelete)
            {
                PlannedCheck = bLPlanned.DeletePlanned(planned);
            }

            Int32 count = DataLinkLayer.DBdelete<Routine>(routine);


            routines = ReadRoutine();
            planneds = bLPlanned.ReadRoutinePlanned();

            Console.WriteLine(planneds.ToArray().ToString());
            Console.WriteLine(routines.ToArray().ToString());

            if (count > 0 && PlannedCheck)
                return true;
            else
                return false;
        }

    }
}
