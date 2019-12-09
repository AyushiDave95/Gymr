using System;
using Gymr.Model;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class AddRoutine : ContentPage
    {
        List<NewRoutine> NewRoutines = new List<NewRoutine>();


        public AddRoutine()
        {
            InitializeComponent();
        }

        void addExerciseClick(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new Exercise());
        }

        public void getExerciseList(String name, int lbl_f, int lbl_s)
        {
            NewRoutine n = new NewRoutine();
            n.Name = name;
            n.Label_F = lbl_f;
            n.Label_L = lbl_s;
            NewRoutines.Add(n);
            exerciseList.ItemsSource = NewRoutines;
        }
    }
}
