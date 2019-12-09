using System;

using Xamarin.Forms;

namespace Gymr.Model
{
    public class ExerciseShow : ContentPage
    {
        public ExerciseShow()
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

