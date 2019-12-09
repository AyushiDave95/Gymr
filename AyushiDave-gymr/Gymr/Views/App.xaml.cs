using System;
using Gymr.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Gymr
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
            MainPage = new DashBoard();
        }

      
        protected override void OnStart()
        {
       
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
