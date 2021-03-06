using Abp.Application.Services;
using QuickBase.Demo.Application.Contracts.AppServices;
using QuickBase.Demo.Application.Contracts.Dtos;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using QuickBase.Demo.Domain.Services;

namespace QuickBase.Demo.Application.AppServices
{
    public class CityAppService : CrudAppService<City, CityDto, int>, ICityAppService 
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICityManager _cityManager;

        public CityAppService(ICityRepository cityRepository, ICityManager cityManager) : base(cityRepository)
        {
            _cityRepository = cityRepository;
            _cityManager = cityManager;
        }
    }
}
