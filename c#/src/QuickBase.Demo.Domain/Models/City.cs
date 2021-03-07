using Abp.Domain.Entities;

namespace QuickBase.Demo.Domain.Models
{
    public class City : Entity<int>
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}
