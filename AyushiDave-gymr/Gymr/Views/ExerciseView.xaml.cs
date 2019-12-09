using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class ExerciseView : ContentPage
    {
        public ExerciseView()
        {
            InitializeComponent();
        }

        void OnImageNameTapped(object sender, System.EventArgs e)
        {
           
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
