using Abp.Modules;
using Abp.Reflection.Extensions;

namespace QuickBase.Demo.Domain.Shared
{
    public class DemoDomainSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoDomainSharedModule).GetAssembly());
        }
    }
}