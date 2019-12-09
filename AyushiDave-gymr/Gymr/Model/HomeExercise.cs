using System;
using System.Collections.Generic;

namespace Gymr.Model
{
    public class HomeExercise
    {
        public String ExerciseName
        {
            get;
            set;
        }

        public String ExerciseTime
        {
            get;
            set;
        }

        public String Progress
        {
            get;
            set;
        }

        public String ImageURL
        {
            get;
            set;
        }

       public List<HomeExercise> GetHomeExercises()
        {
            List<HomeExercise> homeExercises = new List<HomeExercise>
            {

                new HomeExercise { ExerciseName = "Ab Wheel", ExerciseTime = "10-24, 12:00 PM", Progress = "23% Complete", ImageURL = "alphabet/a" },
                new HomeExercise { ExerciseName = "Back Extenstion", ExerciseTime = "10-10, 16:54 PM", Progress = "96% Complete", ImageURL = "alphabet/a" },
                new HomeExercise { ExerciseName = "Cable Crunch", ExerciseTime = "12-07, 09:17 PM", Progress = "23% Complete", ImageURL = "alphabet/b" },
                new HomeExercise { ExerciseName = "Height Cross", ExerciseTime = "02-23, 04:00 PM", Progress = "87% Complete", ImageURL = "alphabet/a" }
            };
            return homeExercises;
        }

    }
}
