using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend;

public class ConcreteStatService : IStatService
{
    public IDictionary<string, int> GetCountryPopulations()
    {
        // Pretend this calls a REST API somewhere
		return new Dictionary<string, int>
		{
			{ "India", 1182105000 },
			{ "United Kingdom", 62026962 },
			{ "Chile", 17094270 },
			{ "Mali", 15370000 },
			{ "Greece", 11305118 },
			{ "Armenia", 3249482 },
			{ "Slovenia", 2046976 },
			{ "Saint Vincent and the Grenadines", 109284 },
			{ "Bhutan", 695822 },
			{ "Aruba (Netherlands)", 101484 },
			{ "Maldives", 319738 },
			{ "Mayotte (France)", 202000 },
			{ "Vietnam", 86932500 },
			{ "Germany", 81802257 },
			{ "Botswana", 2029307 },
			{ "Togo", 6191155 },
			{ "Luxembourg", 502066 },
			{ "U.S. Virgin Islands (US)", 106267 },
			{ "Belarus", 9480178 },
			{ "Myanmar", 59780000 },
			{ "Mauritania", 3217383 },
			{ "Malaysia", 28334135 },
			{ "Dominican Republic", 9884371 },
			{ "New Caledonia (France)", 248000 },
			{ "Slovakia", 5424925 },
			{ "Kyrgyzstan", 5418300 },
			{ "Lithuania", 3329039 },
			{ "United States of America", 309349689 }
		};
    }

    public async Task<IDictionary<string, int>> GetCountryPopulationsAsync()
    {
        return await Task.FromResult(GetCountryPopulations());
    }
}
