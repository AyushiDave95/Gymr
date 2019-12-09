using System;
using SQLite;

namespace Gymr.Model
{
    public class Profile
    {
        [PrimaryKey]
        public Int32 ProfileID
        { get; set; }

        public String Name
        { get; set; }

        public Boolean Metrix
        { get; set; }

        public Double Height
        { get; set; }

        public Double Weight
        { get; set; }

        public Int32 Gender
        { get; set; }
    
        public String DOB
        { get; set; }
    
        public override string ToString()
        {
              return this.ProfileID + "-" + this.Name;
           
        }
    
    }
    

}
