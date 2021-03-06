using Abp.Domain.Services;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Domain.Services
{
    public class CityManager: DomainService, ICityManager
    {
        private readonly ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
    }
}
