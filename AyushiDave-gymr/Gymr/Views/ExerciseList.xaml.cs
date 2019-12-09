using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Gymr.Template;
using Gymr.Model;
using System.Linq;
using System.Collections.ObjectModel;

namespace Gymr.Views
{
    public partial class Exercise : ContentPage
    {
        String frompage="EXERCISE";

        public Exercise()
        {
            InitializeComponent();
            btn_save.IsVisible = false;
            Console.WriteLine("--- Read Data-----");

            ExerciseViewModel exerciseViewModel = new ExerciseViewModel(); // Added data in Listview


            var Data = exerciseViewModel.GetExercises.OrderBy(p => p.Name)
               .GroupBy(p => p.Name[0].ToString())
                                        .Select(p => new ObservableGroupCollection<string, Model.Exercise>(p))
                                   .ToList();

            // ExerciseListViewModel exerciseListViewModel = new ExerciseListViewModel();
            // exerciseListViewModel.GroupedData = Data;

            //BindingContext = new ObservableCollection<ObservableGroupCollection<string, Model.Exercise>>(Data);

            exerciselist.ItemsSource = Data;
            exerciselist.GroupShortNameBinding = new Binding("Key");
        }


        public Exercise(String strfrompage)
        {
            InitializeComponent();
            btn_save.IsVisible = true;
            ExerciseViewModel exerciseViewModel = new ExerciseViewModel(); // Added data in Listview


            var Data = exerciseViewModel.GetExercises.OrderBy(p => p.Name)
               .GroupBy(p => p.Name[0].ToString())
                                        .Select(p => new ObservableGroupCollection<string, Model.Exercise>(p))
                                   .ToList();

            exerciselist.ItemsSource = Data;
            exerciselist.GroupShortNameBinding = new Binding("Key");
            frompage = strfrompage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //TheListView.SelectedItem = null;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
         
           // App.Current.MainPage.Navigation.PushModalAsync(new ExerciseView());
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {


            if (frompage.Equals("EXERCISE"))
            {
                App.Current.MainPage.Navigation.PushModalAsync(new ExerciseView());
            }
            else
            {
                var selectedCategory = e.SelectedItem as Model.Exercise;
                String lblName = selectedCategory.Name;


                RoutineShow my = new RoutineShow();
                my.ExcerciseName = lblName;
                my.Time = "00:00";
                my.ImageURL = "alphabet/" + Char.ToLower(lblName[0]) + "";
                new MyExercisesViewModel().AddData(my);
                Console.WriteLine("--Data on exercise Click" + my.ImageURL);
            }

        }

        void btnSaveClicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
