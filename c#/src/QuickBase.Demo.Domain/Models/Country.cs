using Abp.Domain.Entities;
using System.Collections.Generic;

namespace QuickBase.Demo.Domain.Models
{
    public class Country: Entity<int>
    {
        public string Name { get; set; }

        public ICollection<State> States { get; set; }

        public Country()
        {
            States = new List<State>();
        }
    }
}
