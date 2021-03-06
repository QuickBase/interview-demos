using Abp.Domain.Entities;
using QuickBase.Demo.Domain.Shared;

namespace QuickBase.Demo.Domain.Models
{
    public class City : Entity<int>
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }

        /* Full DDD approach
        protected City()
        {

        }

        public City(string name, int population, State state)
        {
            Name = Validations.CheckEntityName(name);
            Population = population;
            State = state;
            StateId = state.Id;
        }

        public virtual void ChangeName(string name)
        {
            Name = Validations.CheckEntityName(name);
        }
        */
    }
}
