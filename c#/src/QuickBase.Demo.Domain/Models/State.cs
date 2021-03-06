using Abp.Domain.Entities;
using System.Collections.Generic;

namespace QuickBase.Demo.Domain.Models
{
    public class State : Entity<int>
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }

        public State()
        {
            Cities = new List<City>();
        }
    }
}
