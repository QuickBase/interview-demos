using Abp.Application.Services;
using QuickBase.Demo.Application.Contracts.AppServices;
using QuickBase.Demo.Application.Contracts.Dtos;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using QuickBase.Demo.Domain.Services;

namespace QuickBase.Demo.Application.AppServices
{
    public class StateAppService : CrudAppService<State, StateDto, int>, IStateAppService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IStateManager _stateManager;

        public StateAppService(IStateRepository stateRepository, IStateManager stateManager) : base(stateRepository)
        {
            _stateRepository = stateRepository;
            _stateManager = stateManager;
        }
    }
}
