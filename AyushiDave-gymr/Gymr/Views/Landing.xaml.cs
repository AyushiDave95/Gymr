using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class Landing : ContentPage
    {
        public Landing()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Console.WriteLine("---Button Click----");
            App.Current.MainPage = new ProfileInfo();
        }
    }
}
