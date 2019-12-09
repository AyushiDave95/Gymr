using System;
using Gymr.Model;
using Gymr.Template;
using System.Collections.Generic;
using System.Collections.ObjectModel;


using Xamarin.Forms;

namespace Gymr.Views
{
    public partial class ExerciseDetail : ContentPage
    {
        private static int val1 = 0;
        private static int val2 = 0;
        private static int index = 0;
        private static Boolean Isedit = false;


        ExerciseSetsViewModel em = new ExerciseSetsViewModel();
        public ExerciseDetail()
        {

            InitializeComponent();
           
            list_exerciseSet.ItemsSource = em.GetExerciseSets;

        }

        void OnTapped(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

       
        public void onSaveClick(object sender, System.EventArgs e)
        {
            String val1 = lbl_val1.Text;
            String val2 = lbl_val2.Text;
            int sets = 0;

            ExerciseSets ex = new ExerciseSets();
            ex.Value_1 = Int32.Parse(val1);
            ex.Value_2 = Int32.Parse(val2);
            ex.SetNumber = sets;

            if(Isedit)
            {
                Update(index, ex);
            }
            else{
                em.GetExerciseSets.Add(ex);
            }

            //list_exerciseSet.ItemsSource = em.GetExerciseSets;
            Isedit = false;
        }

        void onclick_plusVal1(object sender, System.EventArgs e)
        {
            val1 = Int32.Parse(lbl_val1.Text);
            val1++;
            lbl_val1.Text = ""+ val1;
        }

        void onclick_minusVal1(object sender, System.EventArgs e)
        {
            val1 = Int32.Parse(lbl_val1.Text);
            if(val1>0)
            {
                val1--;
            }
                
              lbl_val1.Text = "" + val1;

        }

        void onclick_plusVal2(object sender, System.EventArgs e)
        {
            val2 = Int32.Parse(lbl_val2.Text);
            val2++;
            lbl_val2.Text = "" + val2;

        }

        void onclick_minusVal2(object sender, System.EventArgs e)
        {
            val2 = Int32.Parse(lbl_val2.Text);
            if (val2 > 0)
            {
                val2--;
            }
               
            lbl_val2.Text = "" + val2;
                

        }

        void onclick_edit(object sender, System.EventArgs e)
        {

            var edit = sender as Image;
            ExerciseSets item = edit.BindingContext as ExerciseSets;

            // get and set data
            item.SetNumber = edit.TabIndex;
            lbl_val1.Text = ""+item.Value_1;
            lbl_val2.Text = "" + item.Value_2;

           
            Isedit = true;

            Console.WriteLine("---Edit  Click----" + edit.TabIndex);
            Console.WriteLine("--->"+item.SetNumber+"-->"+item.Value_1+"-->"+item.Value_2);

        }

        void onclick_delete(object sender, System.EventArgs e)
        {
            var delete = sender as Image;
            ExerciseSets item = delete.BindingContext as ExerciseSets;
            //var vm = BindingContext as ExerciseSetsViewModel;
            //vm.RemoveCommand.Execute(item);

           
            //OnPropertyChanged(nameof(list_exerciseSet));

            var index = (list_exerciseSet.ItemsSource as ObservableCollection<ExerciseSets>).IndexOf(item);

            Console.WriteLine("---Delete Index-->"+index);
            em.GetExerciseSets.RemoveAt(index);

        }

        public void Update(int index, ExerciseSets ex)
        {
            em.GetExerciseSets.Insert(index, ex);
        }
    }
}
