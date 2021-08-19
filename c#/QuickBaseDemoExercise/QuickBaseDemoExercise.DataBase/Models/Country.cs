using System;
using System.Collections.Generic;


namespace QuickBaseDemoExercise.DataBase.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();

        }
        public string CountryName { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<State> States { get; set; }

    }
}
