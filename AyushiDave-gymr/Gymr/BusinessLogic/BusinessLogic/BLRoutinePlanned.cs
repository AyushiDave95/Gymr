﻿using System;
using System.Collections.Generic;
using Gymr.Model;
using SQLite;
using Xamarin.Forms;

namespace Gymr.BusinessLogic
{
    public class BLRoutinePlanned : ContentPage
    {
        SQLiteConnection db;
        public BLRoutinePlanned()
        {
            db = DataLinkLayer.DBconnect();
        }

        public List<RoutinePlanned> ReadRoutinePlanned()
        {
            RoutinePlanned rp = new RoutinePlanned();
            List<RoutinePlanned> list = DataLinkLayer.DBread<RoutinePlanned>(rp);



            String s = "";

            foreach (RoutinePlanned l in list)
            {
                s = s + "\n" + l.ToString();
            }

            Console.WriteLine(s);

            return list;
        }

        public Int32 InsertRoutinePlanned(RoutinePlanned routinePlanned)
        {
            int count = 0;


            db.CreateTable<RoutinePlanned>();

            foreach (RoutinePlanned rp in GetRoutinePlanned())
            {
                Int32 x = DataLinkLayer.DBinsert<RoutinePlanned>(rp);
                count += x;
            }


            return count;
        }



        public List<RoutinePlanned> GetRoutinePlanned()
        {
            Int32 RPIDcounter = 0;   // ExcerciseIDcounter

            List<RoutinePlanned> routine = new List<RoutinePlanned>()
            {
                new RoutinePlanned { ID=RPIDcounter++, ExcertciseID=0, Date="Today", RoutineID=0, Reps=0, Sets=0 },
                new RoutinePlanned { ID=RPIDcounter++, ExcertciseID=1, Date="Today", RoutineID=1, Reps=1, Sets=2 },
                new RoutinePlanned { ID=RPIDcounter++, ExcertciseID=2, Date="Today", RoutineID=0, Reps=3, Sets=3 },

            };

            return routine;
        }

       
    }
}

