using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gymr
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void btn_onNextClick(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.LandingPage());
           
        }
       
        public async void btn_LandingPage(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.LandingPage());

        }
        public async void btn_ProfilePage(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.ProfilePage());

        }
        public async void btn_ProfileInfo(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.ProfileInfo());
            await Navigation.PushModalAsync(new Views.DashBoard());


        }
    }
}
