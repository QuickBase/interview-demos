using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBaseDemoExercise.Services
{
    public interface ICountrySourceService : ICountryService
    {
       int Order { get; }
    }
}
