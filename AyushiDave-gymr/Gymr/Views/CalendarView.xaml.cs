using System;
using Gymr.Model;
using Gymr.Template;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamForms.Controls;

namespace Gymr.Views
{
    public partial class CalendarView : ContentPage
    {
        Calendar calendar;
        CalendarVM _vm;
        DateTime datemy;
        HomeExerciseViewModel hevm;

       


        public CalendarView()
        {
            InitializeComponent();
            hevm = new HomeExerciseViewModel();
            listhome_Exercise.ItemsSource = hevm.MyProperty;
            String str = "11/18/2018";
            datemy = DateTime.Parse(str);
            Console.WriteLine("Print Date-->" + datemy);
        }

         void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new ExerciseDetail());
           
        }

        public void CallCalendar()
        {

            calendar = new Calendar
            {
                MaxDate = DateTime.Now.AddDays(90),
                MinDate = DateTime.Now.AddDays(-1),
                //DisableDatesLimitToMaxMinRange = true,
                MultiSelectDates = false,
                DisableAllDates = false,
                WeekdaysShow = true,
                ShowNumberOfWeek = false,
                DatesBackgroundColorOutsideMonth = Color.White,
                DatesTextColorOutsideMonth = Color.Black,
                DatesBackgroundColor = Color.White,
                DisabledBackgroundColor = Color.White,
                DisabledTextColor = Color.Black,
                
                //DisableDatesLimitToMaxMinRange = true,
                //BorderWidth = 1,
                //BorderColor = Color.Transparent,
                //OuterBorderWidth = 0,
                //SelectedBorderWidth = 1,
                
                ShowNumOfMonths = 1,
                EnableTitleMonthYearView = true,
                WeekdaysTextColor = Color.Teal,
                StartDay = DayOfWeek.Monday,
                SelectedTextColor = Color.Fuchsia,
                SpecialDates = new List<SpecialDate>
                {
                    new SpecialDate(DateTime.Now.AddDays(2).Date) 
                    {   BackgroundColor = Color.Gray,
                        TextColor = Color.White,
                        BorderColor = Color.Gray,
                        BorderWidth=0, 
                        Selectable = true
                     },
                    new SpecialDate(DateTime.Now.AddDays(5).Date) { BackgroundColor = Color.Gray,
                        TextColor = Color.White, BorderColor = Color.Gray, BorderWidth=0, Selectable = true },
                    new SpecialDate(datemy.Date) { BackgroundColor = Color.Gray,
                        TextColor = Color.White, BorderColor = Color.Gray, BorderWidth=0, Selectable = true },
                    new SpecialDate(DateTime.Now.AddDays(4))
                    {
                        Selectable = true,
                        //BackgroundImage = "alphabet/a.png"
                    }
                }
                
            };
            /*
            var white_row = new Pattern { WidthPercent = 1f, HightPercent = 0.04f, Color = Color.Transparent };
            var white_col = new Pattern { WidthPercent = 0.04f, HightPercent = 1f, Color = Color.Transparent };


            calendar.SpecialDates = new List<SpecialDate>{
                    new SpecialDate(DateTime.Now.AddDays(3))
                    {
                        BackgroundColor = Color.White,
                        TextColor = Color.Black,
                        Selectable = true,
                        BackgroundPattern = new BackgroundPattern(7)
                    {
                        Pattern = new List<Pattern>
                            {
                            new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Red, Text = "X", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Gold, Text = "Y", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Green, Text = "Z", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Purple,Text = "Q", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},

                                white_row,white_row,white_row,white_row,white_row,white_row,white_row,

                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Blue},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Chocolate},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Cyan},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Fuchsia},

                                white_row,white_row,white_row,white_row,white_row,white_row,white_row,

                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Crimson},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Aquamarine},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.OrangeRed},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.DarkOrchid},

                                white_row,white_row,white_row,white_row,white_row,white_row,white_row,

                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Black},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.DeepSkyBlue},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.DarkGoldenrod},
                                white_col,
                                new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Firebrick},
                            }
                        }
                    }
            };*/

            calendar.DateClicked += (sender, e) => {
                App.Current.MainPage.Navigation.PushModalAsync(new ExerciseDetail());
            };

            // Special Date End
            LoadCalendar();
        }

    
        public void LoadCalendar()
        {
               _vm = new CalendarVM();
            var c2 = new CalendarView();
            //calendar.SetBinding(Calendar.DateCommandProperty, nameof(_vm.DateChosen));
            //calendar.SetBinding(Calendar.SpecialDatesProperty, nameof(_vm.Attendances));
            c2.BindingContext = _vm;
                
            stack_layout.Children.Add(calendar);

            var dates = new List<SpecialDate>();

            var specialDate = new SpecialDate(new DateTime(2017, 04, 26));
            specialDate.BackgroundColor = Color.Green;
            specialDate.TextColor = Color.White;

            dates.Add(specialDate);

            _vm.Attendances = new ObservableCollection<SpecialDate>(dates);
            calendar.SelectedDate = (DateTime.Now);

            Console.WriteLine("Special Date Add:-->" + datemy.Date+"--> Base-->"+ DateTime.Now.AddDays(5).Date);
        }

       


    }
}
