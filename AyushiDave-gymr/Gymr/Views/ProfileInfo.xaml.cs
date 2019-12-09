using System;
using System.Collections.Generic;
using Gymr.Model;
using SQLite;
using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class ProfileInfo : ContentPage
    {
        public ProfileInfo()
        {
            InitializeComponent();
        }


        void  Handle_Clicked(object sender, System.EventArgs e)
        {
            // await Navigation.PushModalAsync(new ProfilePage()); 
            App.Current.MainPage = new DashBoard();
        }

        public void InsertData(object sender, EventArgs e)
        {
            Profile profile = new Profile();

            profile.Name = txt_name.Text;

            // Metrix = matrix.SelectedItem.ToString() == "US" ? false : true,

            if (matrix.SelectedItem.ToString() == "US")
                profile.Metrix = false;
            else
                profile.Metrix = true;

            if (gender.SelectedItem.ToString() == "Male")
            {
                profile.Gender = 1;
            }
            else if (gender.SelectedItem.ToString() == "Female")
            {
                profile.Gender = 2;
            }
            else
            {
                profile.Gender = 3;
            }

            profile.Height = Double.Parse(txt_height.Text.ToString());
            profile.Weight = Double.Parse(txt_weight.Text.ToString());

            profile.DOB = dob.Date.ToString();

            // Actually insert data in database

            DataLinkLayer dll = new DataLinkLayer();
            SQLiteConnection db = DataLinkLayer.DBconnect();
            int insertConfirm = DataLinkLayer.DBinsert(profile);
            if (insertConfirm > 0)
            {
                 Console.WriteLine("User Name"+profile.Name);
                //System.Diagnostics.Debug.WriteLine(""+ profile.Name);
                //await DisplayAlert(null, profile.Name + "Saved", "ok");
            }

            // dll.ReadProfile(db);
            DataLinkLayer.DBclose(db);
        }
    }
}
