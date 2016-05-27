using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Misc.Warehouse.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            ViewEngines.Engines.Insert(0, new WarehouseViewEngine());
        }

        public int Priority
        {
            get { return 1; }
        }
    }
}