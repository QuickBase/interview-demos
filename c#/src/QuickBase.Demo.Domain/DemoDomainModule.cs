using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickBase.Demo.Domain.EqualityComparers;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Shared;
using System.Collections.Generic;

namespace QuickBase.Demo.Domain
{
    [DependsOn(typeof(DemoDomainSharedModule))]
    public class DemoDomainModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoDomainModule).GetAssembly());
            IocManager.Register(typeof(IEqualityComparer<CountryPopulation>), typeof(CountryPopulationEqualityComparer), DependencyLifeStyle.Singleton);
        }
    }
}