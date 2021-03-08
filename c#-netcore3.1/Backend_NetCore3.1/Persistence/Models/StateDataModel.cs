using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.Models
{
    public class StateDataModel : DataModelBase
    {
        public int StateId { get; private set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
