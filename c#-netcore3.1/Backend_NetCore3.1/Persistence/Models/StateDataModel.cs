using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
    public class StateDataModel
    {
        public int StateId { get; private set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
