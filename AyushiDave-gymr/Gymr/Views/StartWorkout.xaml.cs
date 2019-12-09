using System;
using System.Collections.Generic;
using Gymr.Template;
using Gymr.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class StartWorkout : ContentPage
    {
        RoutineDataViewModel vm;
        public StartWorkout()
        {
            InitializeComponent();
            vm = new RoutineDataViewModel();

            listRoutines.ItemsSource = vm.routines;
        }

        void edit_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void delete_Clicked(object sender, System.EventArgs e)
        {
            var delete = sender as Image;
            RoutineData item = delete.BindingContext as RoutineData;
            var index = (listRoutines.ItemsSource as ObservableCollection<RoutineData>).IndexOf(item);
            vm.routines.RemoveAt(index);

        }

        void oncreateRoutine(object sender, System.EventArgs e)
        {
            // Open ExerciseList data

            App.Current.MainPage.Navigation.PushModalAsync(new RoutineExercise());
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new RoutineExercise("ITEM"));
        }

        void onEditClick(object sender, System.EventArgs e)
        {
            //Console.WriteLine("--Edit Button Click--");
            //App.Current.MainPage.Navigation.PushModalAsync(new RoutineExercise("EDIT"));
        }
    }
}