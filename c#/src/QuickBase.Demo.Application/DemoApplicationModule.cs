using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickBase.Demo.Application.Contracts.Dtos;
using QuickBase.Demo.Domain;
using QuickBase.Demo.Domain.Models;

namespace QuickBase.Demo.Application
{
    [DependsOn(
        typeof(DemoDomainModule), 
        typeof(AbpAutoMapperModule))]
    public class DemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoApplicationModule).GetAssembly());
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<Country, CountryDto>();
                config.CreateMap<CountryDto, Country>();
                config.CreateMap<CountryPopulation, CountryPopulationDto>();
                config.CreateMap<CountryPopulationDto, CountryPopulation>();
                config.CreateMap<City, CityDto>();
                config.CreateMap<CityDto, City>();
                config.CreateMap<State, StateDto>();
                config.CreateMap<StateDto, State>();
            });
        }
    }
}