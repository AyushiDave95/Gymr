using System;
using System.IO;
using SQLite;

namespace Gymr.Model
{
    public class DbConnect
    {
        public DbConnect()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"Gymr.db");
            var db = new SQLiteConnection(dbPath);

            // add data 
            db.CreateTable<Profile>();

            var maxPK = db.Table<Profile>().OrderByDescending(c => c.ProfileID).FirstOrDefault();

            Profile profile = new Profile()
            {
                ProfileID = (maxPK == null ? 1 : maxPK.ProfileID + 1),
                Name = "Ayushi",
                Metrix = true,
                Height = 0,
                Weight = 0,
                Gender = 0
            };

            db.Insert(profile);

           // await DisplayAlert()

        }
    }
}
