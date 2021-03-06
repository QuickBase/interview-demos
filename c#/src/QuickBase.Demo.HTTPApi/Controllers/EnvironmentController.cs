using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace QuickBase.Demo.HTTPApi.Controllers
{
    [Route("env")]
    [ApiController]
    public class EnvironmentController : DemoBaseController
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public EnvironmentController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        [HttpGet("routes", Name = "EnvironmentGetAllRoutes")]
        [Produces(typeof(ListResult<RouteModel>))]
        public IActionResult GetAllRoutes()
        {

            var result = new ListResult<RouteModel>();
            var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                ad => ad.AttributeRouteInfo != null).Select(ad => new RouteModel
                {
                    Name = ad.AttributeRouteInfo.Name,
                    Template = ad.AttributeRouteInfo.Template
                }).ToList();
            if (routes != null && routes.Any())
            {
                result.Items = routes;
                result.Success = true;
            }
            return Ok(result);
        }
    }
    internal class RouteModel
    {
        public string Name { get; set; }
        public string Template { get; set; }
    }

    internal class ListResult<T>
    {
        public ListResult()
        {
        }

        public List<RouteModel> Items { get; internal set; }
        public bool Success { get; internal set; }
    }
}
