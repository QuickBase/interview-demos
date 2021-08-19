using QuickBaseDemoExercise.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBaseDemoExercise.Services
{
    public interface ICountryIdFactory
    {
        string BuildId(Country country);
    }
}
