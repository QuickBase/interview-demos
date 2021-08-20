using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Services
{
    public interface ISourcesService
    {
        IEnumerable<ICountrySourceService> GetCountrySources();
    }
}
