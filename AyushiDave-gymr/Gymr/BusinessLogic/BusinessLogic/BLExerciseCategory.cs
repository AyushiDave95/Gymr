using System;
using Gymr.Model;
using SQLite;
using Xamarin.Forms;

namespace Gymr.BusinessLogic
{
    public class BLExerciseCategory : ContentPage
    {
        public BLExerciseCategory()
        { }
            public Int32 ExcerciseCategoryWrite(ExerciseCategory mainExcercise, SQLiteConnection db)
            {
                // var maxPK = db.Table<ExcerciseCategory>().OrderByDescending(c => c.ExerciseCategoryID).FirstOrDefault();

                ExerciseCategory exc;

                //if (maxPK != null)

                //{

                //    exc = new ExcerciseCategory()
                //    {
                //        ExerciseCategoryID = (maxPK == null ? 1 : (maxPK.ExerciseCategoryID + 1)),
                //        Name = mainExcercise.Name,
                //        Description = mainExcercise.Description

                //    };
                //}
                //else
                //{
                //db.CreateTable<ExcerciseCategory>();
                exc = new ExerciseCategory()
                {
                    ExerciseCategoryID = 1,
                    Name = mainExcercise.Name,
                    Description = mainExcercise.Description

                };
                //  }
                return db.Insert(exc);
            }

            public ListView ExcerciseCategoryRead()
            {

                ListView _list = new ListView();
         //       _list.ItemsSource = db.Table<ExerciseCategory>().OrderByDescending(x => x.ExerciseCategoryID).ToList();


                return _list;

            }

    }
}

