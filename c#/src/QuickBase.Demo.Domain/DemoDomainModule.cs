using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickBase.Demo.Domain.Shared;

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
        }
    }
}