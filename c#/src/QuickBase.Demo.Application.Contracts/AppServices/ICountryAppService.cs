using Abp.Application.Services;
using Abp.Application.Services.Dto;
using QuickBase.Demo.Application.Contracts.Dtos;
using System.Threading.Tasks;

namespace QuickBase.Demo.Application.Contracts.AppServices
{
    public interface ICountryAppService : ICrudAppService<CountryDto,int>
    {
        Task<ListResultDto<CountryPopulationDto>> GetAllPopulations();
    }
}
