using System;
using System.Collections.Generic;

namespace QuickBaseDemoExercise.DataBase.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int? Population { get; set; }

        public virtual State State { get; set; }
    }
}
