using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ConcreteStatService : IStatService
    {
        public List<Tuple<string, int>> GetCountryPopulations()
        {
            // Pretend this calls a REST API somewhere
            return new List<Tuple<string, int>>
            {
		        Tuple.Create("India",1182105000),
		        Tuple.Create("United Kingdom",62026962),
		        Tuple.Create("Chile",17094270),
		        Tuple.Create("Mali",15370000),
		        Tuple.Create("Greece",11305118),
		        Tuple.Create("Armenia",3249482),
		        Tuple.Create("Slovenia",2046976),
		        Tuple.Create("Saint Vincent and the Grenadines",109284),
		        Tuple.Create("Bhutan",695822),
		        Tuple.Create("Aruba (Netherlands)",101484),
		        Tuple.Create("Maldives",319738),
		        Tuple.Create("Mayotte (France)",202000),
		        Tuple.Create("Vietnam",86932500),
		        Tuple.Create("Germany",81802257),
		        Tuple.Create("Botswana",2029307),
		        Tuple.Create("Togo",6191155),
		        Tuple.Create("Luxembourg",502066),
		        Tuple.Create("U.S. Virgin Islands (US)",106267),
		        Tuple.Create("Belarus",9480178),
		        Tuple.Create("Myanmar",59780000),
		        Tuple.Create("Mauritania",3217383),
		        Tuple.Create("Malaysia",28334135),
		        Tuple.Create("Dominican Republic",9884371),
		        Tuple.Create("New Caledonia (France)",248000),
		        Tuple.Create("Slovakia",5424925),
		        Tuple.Create("Kyrgyzstan",5418300),
		        Tuple.Create("Lithuania",3329039),
		        Tuple.Create("United States of America",309349689)
            };
        }


        public Task<List<Tuple<string, int>>> GetCountryPopulationsAsync()
        {
            return Task.FromResult<List<Tuple<string, int>>>(GetCountryPopulations());
        }
    }
}
