using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
    public class CityDataModel
    {
        public int CityId { get; private set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int Population { get; set; }
    }
}
