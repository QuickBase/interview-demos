using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickBase.Demo.Domain;

namespace QuickBase.Demo.EntityFrameworkCore
{
    [DependsOn(
        typeof(DemoDomainModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class DemoEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoEntityFrameworkCoreModule).GetAssembly());
        }
    }
}