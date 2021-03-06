using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickBase.Demo.Domain;

namespace QuickBase.Demo.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
        typeof(DemoDomainModule),
        typeof(DemoEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class DemoEntityFrameworkCoreModuleDbMigrations : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoEntityFrameworkCoreModuleDbMigrations).GetAssembly());
        }
    }
}