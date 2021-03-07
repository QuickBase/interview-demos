using System;
using System.Threading.Tasks;
using Abp.TestBase;
using QuickBase.Demo.EntityFrameworkCore;
using QuickBase.Demo.TestBase.TestData;

namespace QuickBase.Demo.TestBase
{
    public class DemoTestBase : AbpIntegratedTestBase<DemoTestBaseModule>
    {
        public DemoTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<DemoDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<DemoDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<DemoDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<DemoDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<DemoDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<DemoDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<DemoDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<DemoDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
