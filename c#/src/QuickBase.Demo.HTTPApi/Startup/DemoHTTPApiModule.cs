using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuickBase.Demo.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using QuickBase.Demo.Application;
using QuickBase.Demo.Domain;
using QuickBase.Demo.HTTPApi.Configuration;

namespace QuickBase.Demo.HTTPApi.Startup
{
    [DependsOn(
        typeof(DemoApplicationModule), 
        typeof(DemoEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class DemoHTTPApiModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public DemoHTTPApiModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(DemoConsts.ConnectionStringName);

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(DemoApplicationModule).GetAssembly());
            Configuration.Modules.AbpAspNetCore().DefaultWrapResultAttribute.WrapOnSuccess = false;
            Configuration.Modules.AbpAspNetCore().DefaultWrapResultAttribute.WrapOnError = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoHTTPApiModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DemoHTTPApiModule).Assembly);
        }
    }
}