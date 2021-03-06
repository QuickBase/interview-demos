using Abp.Domain.Services;
using QuickBase.Demo.Domain.Repositories;

namespace QuickBase.Demo.Domain.Services
{
    public class StateManager: DomainService, IStateManager
    {
        private readonly IStateRepository _stateRepository;

        public StateManager(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
    }
}
