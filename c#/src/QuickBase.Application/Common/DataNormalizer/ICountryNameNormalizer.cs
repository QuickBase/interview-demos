using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Common.DataNormalizer
{
    public interface ICountryNameNormalizer
    {
        string NormalizeName(string countryName);

    }
}
