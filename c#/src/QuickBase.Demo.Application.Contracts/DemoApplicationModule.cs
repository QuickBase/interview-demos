using Abp.Modules;
using Abp.Reflection.Extensions;

namespace QuickBase.Demo.Application.Contracts
{
    public class DemoApplicationContractModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoApplicationContractModule).GetAssembly());
        }
    }
}