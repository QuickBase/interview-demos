using QuickBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
    }
}
