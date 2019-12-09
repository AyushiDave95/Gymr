using System;
using Gymr.Template;
using Gymr.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Gymr.BusinessLogic;

namespace Gymr.Views
{
    public partial class RoutineExercise : ContentPage
    {
        MyExercisesViewModel mevm = new MyExercisesViewModel();

        String routinName = "";

        public RoutineExercise()
        {
            InitializeComponent();
            list_routineExercise.ItemsSource = Dao.GetMyExercises;
        }

        public RoutineExercise(String getdata)
        {
            Dao.GetScreen = getdata;
            InitializeComponent();
            list_routineExercise.ItemsSource = Dao.GetMyExercises;
        }

        void onBackClick(object sender, System.EventArgs e)
        {
            //Dao.GetMyExercises.Clear();

            RoutineShow rs = new RoutineShow();
            List<RoutineShow> rsList = new List<RoutineShow>();
            ObservableCollection<RoutineShow> allEx = Dao.GetMyExercises;
            for (int i = 0; i < allEx.Count;i++)
            {

                rs.RoutineName = entry_routine.Text;
                rs.ExcerciseName = allEx[i].ExcerciseName;


                rsList.Add(rs);
            }

            BLPlanned bLPlanned = new BLPlanned();
            int rowInserted = bLPlanned.RoutineShowInsert(rsList);
            RoutineDataViewModel rdvm = new RoutineDataViewModel();
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new ExerciseDetail());
            if (Dao.GetScreen.Equals("EDIT"))
            {
                // for edit data
                //App.Current.MainPage.Navigation.PushModalAsync(new ExerciseDetail());
            }
            else
            {
                // for perform exercise
                //App.Current.MainPage.Navigation.PushModalAsync(new PerfomRoutine());
            }
           
        }

        void onAddexercise(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new Exercise("ADD"));
        }

        

        void onbtn_saveClick(object sender, System.EventArgs e)
        {
            routinName = entry_routine.Text;
            Console.WriteLine("Routin Name:" + routinName);
        }


    }
}
