using System;
using Gymr.Template;
using System.Collections.Generic;

namespace Gymr.Model
{
    public class Exercise 
    {
     
        public String Name
        {
            get;
            set;
        }

        public String BodyType
        {
            get;
            set;
        }

        public String Category
        {
            get;
            set;
        }

        public String ShortName
        {
            get;
            set;
        }

        public String ImageURL
        {
            get;
            set;
        }

        public Int32 ExcerciseID
        {
            get; set;
        }

        public Int32 ExcerciseCategoryID
        { get; set; }
        public String Description
        {
            get; set;
        }

    }
}

        /* public Exercise(String shortname)
         {
              ShortName = shortname;
              public static IList<Exercise> All { private get; set; }
         }*/

