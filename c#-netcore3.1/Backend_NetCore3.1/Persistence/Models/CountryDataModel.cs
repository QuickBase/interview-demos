using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.Models
{
    public class CountryDataModel : DataModelBase
    {
        public int CountryId { get; private set; }
        public string CountryName { get; set; }
    }
}
