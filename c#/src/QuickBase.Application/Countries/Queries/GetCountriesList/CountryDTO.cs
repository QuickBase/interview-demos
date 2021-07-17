using QuickBase.Application.Common.Mappings;
using QuickBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Countries.Queries.GetCountriesList
{
    public class CountryDTO : IMapFrom<Country>
    {
        public string Name { get; set; }

        public int Population { get; set; }
    }
}
