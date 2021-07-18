using MediatR;
using QuickBase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace QuickBase.Application.Countries.Queries.GetCountriesList
{
    public class GetCountriesListQuery : IRequest<CountriesListVM>
    {
        public class GetCountriesListQueryHandler : IRequestHandler<GetCountriesListQuery, CountriesListVM>
        {
            private readonly ICountryRepository countryRepository;
            private readonly IMapper mapper;

            public GetCountriesListQueryHandler(ICountryRepository countryRepository,
                IMapper mapper)
            {
                this.countryRepository = countryRepository;
                this.mapper = mapper;
            }

            public async Task<CountriesListVM> Handle(GetCountriesListQuery request, CancellationToken cancellationToken)
            {
                var countries = mapper.Map<List<CountryDTO>>(await countryRepository.GetCountries());

                return new CountriesListVM() { Countries = countries };
            }
        }
    }
}
