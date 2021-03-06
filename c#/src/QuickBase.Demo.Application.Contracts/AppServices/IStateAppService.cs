using Abp.Application.Services;
using QuickBase.Demo.Application.Contracts.Dtos;

namespace QuickBase.Demo.Application.Contracts.AppServices
{
    public interface IStateAppService : ICrudAppService<StateDto, int>
    {
    }
}
