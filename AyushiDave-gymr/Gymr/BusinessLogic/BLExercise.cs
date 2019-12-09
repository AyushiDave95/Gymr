using System;
using System.Collections.Generic;
using Gymr.Model;
using SQLite;
using Xamarin.Forms;

namespace Gymr.BusinessLogic
{
    public class BLExercise : ContentPage
    {
        SQLiteConnection db;

        public BLExercise()
        {
            db = DataLinkLayer.DBconnect();

           
        }

        public List<Exercise> ReadExercise()
        {
          
            Exercise e = new Exercise();
         // Int32 count = InsertExcercise(e);
            List<Exercise> list = DataLinkLayer.DBread<Exercise>(e);

            return list;

        }

        public Int32 InsertExcercise(Exercise e)
        {
            int count = 0;
            foreach(Exercise ex in GetExercises())
            {
                Int32 x = DataLinkLayer.DBinsert<Exercise>(ex);
                count += x;
            }


            return count;

        }


        public static List<Exercise> GetExercises()
        {
            Int32 EIDcounter = 0;   // ExcerciseIDcounter

            List<Exercise> exercise = new List<Exercise>()
            {
                new Exercise { ExcerciseID=EIDcounter++, Name="Ab Wheel", ExcerciseCategoryID=0, Description="Ab Wheel" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Arnold Press", ExcerciseCategoryID=0, Description="Arnold Press" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Around the world", ExcerciseCategoryID=0, Description="Around the world" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Back Extension", ExcerciseCategoryID=0, Description="Back Extension" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Ballslams", ExcerciseCategoryID=0, Description="Ballslams" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Battle ropes", ExcerciseCategoryID=0, Description="Battle ropes" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bench Dip", ExcerciseCategoryID=0, Description="Bench Dip" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bench Press", ExcerciseCategoryID=0, Description="Bench Press" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bent Over Row", ExcerciseCategoryID=0, Description="Bent Over Row" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bicep Curl(Barbell)", ExcerciseCategoryID=0, Description="Bicep Curl(Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bicep Curl(Dumbbell)", ExcerciseCategoryID=0, Description="Bicep Curl(Dumbbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bicep Curl(Cable)", ExcerciseCategoryID=0, Description="Bicep Curl(Cable)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bicep Curl(Mechine)", ExcerciseCategoryID=0, Description="Bicep Curl(Mechine)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bicycle Crunch", ExcerciseCategoryID=0, Description="Bicycle Crunch" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Box Jump", ExcerciseCategoryID=0, Description="Box Jump" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Box Squat(Barbell)", ExcerciseCategoryID=0, Description="Box Squat(Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Bulgarian Split Squat", ExcerciseCategoryID=0, Description="Bulgarian Split Squat" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Burpee", ExcerciseCategoryID=0, Description="Burpee" },
                  new Exercise { ExcerciseID=EIDcounter++, Name="Cable Crossover", ExcerciseCategoryID=0, Description="Cable Crossover" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Cable Crunch", ExcerciseCategoryID=0, Description="Cable Crunch" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Cable Kickback", ExcerciseCategoryID=0, Description="Cable Kickback" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Chin Up", ExcerciseCategoryID=0, Description="Chin Up" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Clean(Barbell)", ExcerciseCategoryID=0, Description="Clean(Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Concentration Curl(Dumbbell)", ExcerciseCategoryID=0, Description="Concentration Curl(Dumbbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Cross Body Crunch", ExcerciseCategoryID=0, Description="Cross Body Crunch" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Crunch", ExcerciseCategoryID=0, Description="Crunch" },
                new Exercise { ExcerciseID=EIDcounter++, Name="DeadLift(Dumbball)", ExcerciseCategoryID=0, Description="DeadLift(Dumbball)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Deadlift(Barball)", ExcerciseCategoryID=0, Description="Deadlift(Barball)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Deadlift(Smith Machine)", ExcerciseCategoryID=0, Description="Deadlift(Smith Machine)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Decline Bench Press(Barball)", ExcerciseCategoryID=0, Description="Decline Bench Press(Barball)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Decline Crunch", ExcerciseCategoryID=0, Description="Decline Crunch" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Deficit Deadlift (Barbell)", ExcerciseCategoryID=0, Description="Deficit Deadlift (Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Flat Knee Raise", ExcerciseCategoryID=0, Description="Flat Knee Raise" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Flat Leg Raise", ExcerciseCategoryID=0, Description="Flat Leg Raise" },
                  new Exercise { ExcerciseID=EIDcounter++, Name="Floor Press (Barbell)", ExcerciseCategoryID=0, Description="Floor Press (Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Front Raise (Barbell)", ExcerciseCategoryID=0, Description="Front Raise (Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Front Raise (Plate)", ExcerciseCategoryID=0, Description="Front Raise (Plate)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Glute ham Raise", ExcerciseCategoryID=0, Description="Glute ham Raise" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Goblet Squat (Kettlebell)", ExcerciseCategoryID=0, Description="Goblet Squat (Kettlebell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Good morning (Barbell)", ExcerciseCategoryID=0, Description="Good morning (Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Hack Squat", ExcerciseCategoryID=0, Description="Hack Squat" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Hack Squat(Barbell)", ExcerciseCategoryID=0, Description="Hack Squat(Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Handstand Push Up", ExcerciseCategoryID=0, Description="Handstand Push Up" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Hang Clean(Barbell)", ExcerciseCategoryID=0, Description="Hang Clean(Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Hang Snatch(Barbell)", ExcerciseCategoryID=0, Description="Hang Snatch(Barbell)" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Hanging Knee Raise", ExcerciseCategoryID=0, Description="Hanging Knee Raise" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Hanging leg Raise", ExcerciseCategoryID=0, Description="Hanging leg Raise" },
                new Exercise { ExcerciseID=EIDcounter++, Name="Zexercise", ExcerciseCategoryID=0, Description="Zexercise" },
            };

            return exercise;
        }

    }
}

