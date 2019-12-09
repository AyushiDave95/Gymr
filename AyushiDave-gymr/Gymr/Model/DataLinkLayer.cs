 
using System;
using System.IO;
using SQLite;
using Gymr.Views;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Gymr.Model
{
    public class DataLinkLayer : ContentPage
    {
        static SQLiteConnection db;

        // delegate declaration
        public delegate void classDel<T>(T t);


        public DataLinkLayer()
        {
            //Profile p = new Profile();
           // classDel<Profile> d = new classDel<Profile>(p);
        }

        public static SQLiteConnection DBconnect()
        {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Gymr.db");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Exercise>();
            db.CreateTable<Routine>();
            db.CreateTable<Profile>();
   

            //TableMapping tm = new TableMapping(typeof(Planned));
            //db.DropTable(tm);


            //db.CreateTable<RoutinePlanned>();

          db.CreateTable<Planned>();
            
            // db.CreateTable<Profile>();
            // db.CreateTable<ExcerciseCategory>()
            return db;
        }

        public static int DBinsert<T>(T tableName)
        {
            Console.WriteLine(tableName);
            return db.Insert(tableName);
           }

        public static int DBupdate<T>(T tableName)
        {
            return db.Update(tableName);
        }

        public static List<T> DBread<T>(T tableName) where T :  new()
        {

            List<T> _list;
            _list = db.Table<T>().ToList();

            return _list;
        }

        public static Int32 DBdelete<T>(T tablename)
        {
            return db.Delete(tablename);
        }

        public static Boolean DBclose(SQLiteConnection db)
        {
          
            if(!db.IsInTransaction)
            {
                db.Close();
                return true;
            }
            return false;
        }

        public void addRoutine(SQLiteConnection db)
        {

            db.CreateTable<Routine>();

            // insert single row

            // var maxPK = db.Table<Routine>().OrderByDescending(c => c.RoutineID).FirstOrDefault();

            Routine myRoutine = new Routine()
            {
                //ProfileID = (maxPK == null ? 1 : (maxPK.RoutineID + 1)),
                RoutineID = 1,
                RoutineName = "MorningRoutine"
            };

            db.Insert(myRoutine);

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
                Console.WriteLine("--Get DB--"+r.ToString());


            }


        }
    }
     
}

