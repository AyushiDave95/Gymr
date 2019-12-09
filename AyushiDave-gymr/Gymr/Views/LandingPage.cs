sing System;

using Xamarin.Forms;

namespace Gymr.Views
{
    public class LandingPage : ContentPage
    {
        public LandingPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

