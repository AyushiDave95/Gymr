using System;
using Gymr.Template;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class PerfomRoutine : ContentPage
    {
        ExerciseSetsViewModel em = new ExerciseSetsViewModel();
        public PerfomRoutine()
        {
            InitializeComponent();
            list_exerciseSet.ItemsSource = em.GetExerciseSets;
        }

        void OnTapped(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        void onSaveClick(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void onstopClick(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void onStatClick(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
