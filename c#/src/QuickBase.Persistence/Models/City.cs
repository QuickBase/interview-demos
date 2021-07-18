using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Persistence.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StateId { get; set; }

        public int? Population { get; set; }
    }
}
