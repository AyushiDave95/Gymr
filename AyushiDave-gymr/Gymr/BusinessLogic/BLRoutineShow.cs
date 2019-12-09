using System;

using Xamarin.Forms;

namespace Gymr.BusinessLogic
{
    public class BLShow 
    {
        public BLShow()
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

