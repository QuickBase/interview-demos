using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Common.DataNormalizer
{
    public class CountryNameNormalizer : ICountryNameNormalizer
    {
        private Dictionary<string, string> aliases = new Dictionary<string, string>()
        {
            { "United States of America", "U.S.A." }
        };

        public string NormalizeName(string countryName)
        {
            return aliases.TryGetValue(countryName, out string realName) 
                ? realName
                : countryName;
        }
    }
}
