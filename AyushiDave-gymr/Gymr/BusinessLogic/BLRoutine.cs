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
            ReadRoutine(db);
            
        }
        public List<Routine> ReadRoutine(SQLiteConnection db)
        {

            //ListView _list = new ListView();
            //_list.ItemsSource = db.Table<Profile>().OrderByDescending(x => x.ProfileID).ToList();
            Routine p = new Routine();
            List<Routine> list = DataLinkLayer.DBread<Routine>(p);



            String s = "";

            foreach (Routine l in list)
            {
                s = s + "\n" + l.ToString();
            }

            Console.WriteLine(s);

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

            //foreach (Routine rp in AddRoutineDB())
            //{
            //    Int32 x = DataLinkLayer.DBinsert<Routine>(rp);
            //    count += x;
            //}

            var maxPK = db.Table<Routine>().OrderByDescending(c => c.RoutineID).FirstOrDefault();

            Routine routine = new Routine()
            {
                RoutineID = (maxPK == null ? 1 : (maxPK.RoutineID + 1)),
                RoutineName = r.RoutineName
            };

            return DataLinkLayer.DBinsert<Routine>(routine);



        }

            public void addRoutine(SQLiteConnection db)
            {

                db.CreateTable<Routine>();

                // insert single row

                // var maxPK = db.Table<Routine>().OrderByDescending(c => c.RoutineID).FirstOrDefault();

                //Routine myRoutine = new Routine()
                //{
                //    //ProfileID = (maxPK == null ? 1 : (maxPK.RoutineID + 1)),
                //    RoutineID = 1,
                //    RoutineName = "MorningRoutine"
                //};

                //db.Insert(myRoutine);

                // insert multiple row : after adding firsr row


                //var maxPK = db.Table<Routine>().OrderByDescending(c => c.RoutineID).FirstOrDefault();

                //for (int i = 0; i < 5;i++)
                //{

                //    Routine r = new Routine()
                //    {
                //        RoutineID = (maxPK == null ? 1 : (maxPK.RoutineID + 1)),

                //        RoutineName = "MorningRoutine"
                //    };
                //    db.Insert(r);

                //    Console.WriteLine(r.ToString());
                //}

                // to show data on logs


                var list = db.Table<Routine>().OrderByDescending(x => x.RoutineID).ToList();

                foreach (Routine r in list)
                {
                    Console.WriteLine(r.ToString());

                }


            }
        }
    }


