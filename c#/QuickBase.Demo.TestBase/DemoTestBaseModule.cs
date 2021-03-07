using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using QuickBase.Demo.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickBase.Demo.Application;

namespace QuickBase.Demo.TestBase
{
    [DependsOn(
        typeof(DemoApplicationModule),
        typeof(DemoEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule)
        )]
    public class DemoTestBaseModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
            SetupInMemoryDb();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoTestBaseModule).GetAssembly());
        }

        private void SetupInMemoryDb()
        {
            var services = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
                IocManager.IocContainer,
                services
            );

            var builder = new DbContextOptionsBuilder<DemoDbContext>();
            builder.UseInMemoryDatabase("Test").UseInternalServiceProvider(serviceProvider);

            IocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<DemoDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}