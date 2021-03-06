using Abp.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.HTTPApi.Controllers
{
    public abstract class DemoBaseController : AbpController
    {
        protected DemoBaseController()
        {
        }
    }
}
