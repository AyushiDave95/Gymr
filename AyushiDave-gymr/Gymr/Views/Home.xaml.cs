using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

        }

         void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Image setimage = (Image)sender;
                setimage.Source = "user.png";

                App.Current.MainPage = new ExerciseDetail();

                // Navigation.RemovePage(new Views.DashBoard());


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
