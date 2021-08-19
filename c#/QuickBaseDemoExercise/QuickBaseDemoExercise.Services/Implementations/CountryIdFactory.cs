using QuickBaseDemoExercise.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBaseDemoExercise.Services.Implementations
{
    public class CountryIdFactory : ICountryIdFactory
    {
        private Dictionary<string, string> _idsByName = new Dictionary<string, string>()
        {
            {"United States of America", "U.S.A." }
        };

        public string BuildId(Country country)
        {
            if (_idsByName.TryGetValue(country.Name, out string id))
                return id;
            else
                return country.Name;
        }
    }
}
