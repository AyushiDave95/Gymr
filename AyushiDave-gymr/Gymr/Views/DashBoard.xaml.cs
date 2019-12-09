using System;
using System.Collections.Generic;

using Xamarin.Forms;


namespace Gymr.Views
{
    public partial class DashBoard : ContentPage
    {
        public DashBoard()
        {
            InitializeComponent();

            var page_cal = new Views.CalendarView();
            page_cal.CallCalendar();
            PlaceHolder.Content = page_cal.Content;
        }

        // Profile View
        void profile_tapped(object sender, System.EventArgs e)
        {
            var page_home = new Views.ProfilePage();
            PlaceHolder.Content = page_home.Content;
        }

        // Calendar view
        void calendar_tapped(object sender, System.EventArgs e)
        {
            var page_cal = new Views.CalendarView();
            page_cal.CallCalendar();
            PlaceHolder.Content = page_cal.Content;

        }

        // Add New Exercise View 
        void addExercise_tapped(object sender, System.EventArgs e)
        {
            var page_exercise = new Views.StartWorkout();
            PlaceHolder.Content = page_exercise.Content;
        }

        // ExerciseList view 
        void exercise_tapped(object sender, System.EventArgs e)
        {
            var page = new Views.Exercise();
            PlaceHolder.Content = page.Content;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var p = new Views.ProfileInfo();
            PlaceHolder.Content = p.Content;
        }
    }
}
