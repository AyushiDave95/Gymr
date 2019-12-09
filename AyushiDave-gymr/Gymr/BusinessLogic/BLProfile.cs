using System;
using SQLite;
using Gymr.Model;
using Xamarin.Forms;
using System.Collections.Generic;


namespace Gymr.BusinessLogic
{
    public class BLProfile : ContentPage
    {
        SQLiteConnection db;

        public BLProfile()
        {
            db = DataLinkLayer.DBconnect();

            BLRoutine bl = new BLRoutine();

            //DeleteProfile(12);
             //ReadProfile(db);

        }

        public int InsertProfile(Profile p)
        {
           var maxPK = db.Table<Profile>().OrderByDescending(c => c.ProfileID).FirstOrDefault();

            Profile profile = new Profile()
            {
              ProfileID = (maxPK == null ? 1 : (maxPK.ProfileID + 1)),
                Name = p.Name,
                Metrix = p.Metrix,
                Height = p.Height,
                Weight = p.Weight,
                Gender = p.Gender,
                DOB = p.DOB

            };

            return DataLinkLayer.DBinsert<Profile>(profile);

        }

        public Profile ReadProfileId(Int32 profileId)
        {
            List<Profile> list = ReadProfile(db);

            foreach(Profile p in list)
            {
                if(p.ProfileID == profileId)
                {
                    return p;
                }
            }

            return new Profile();

           
        }

        public int UpdateProfile(Profile profileUpdate)
        {
            //Profile toUpdate = ReadProfileId(profileUpdate.ProfileID);
            //Profile profile = profileUpdate;

            return DataLinkLayer.DBupdate<Profile>(profileUpdate);

        }


        public List<Profile> ReadProfile(SQLiteConnection db)
        {

            Profile p = new Profile();
            List<Profile> list = DataLinkLayer.DBread<Profile>(p);

            String s = "";

            foreach (Profile l in list)
            {
                s = s + "\n" + l.ToString();
            }

            Console.WriteLine(s);

            return list;

            //await DisplayAlert(null, s, "ok");
        }

        public Int32 DeleteProfile(Int32 id)
        {
            Profile profile = ReadProfileId(id);

            return DataLinkLayer.DBdelete(profile);
        }

        ~BLProfile()
        {
           
            DataLinkLayer.DBclose(db);
        }
    }
}

