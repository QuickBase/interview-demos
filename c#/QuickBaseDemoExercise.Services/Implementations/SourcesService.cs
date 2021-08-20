using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBaseDemoExercise.Services.Implementations
{
    public class SourcesService : ISourcesService
    {
        private readonly IServiceProvider _serviceProvider;

        public SourcesService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<ICountrySourceService> GetCountrySources()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(ICountrySourceService)))
                .Select(x =>
                {
                    return _serviceProvider.GetService(x) as ICountrySourceService;
                })
                .ToList();
        }
    }
}
