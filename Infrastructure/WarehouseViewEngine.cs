using Nop.Web.Framework.Themes;

namespace Nop.Plugin.Misc.Warehouse.Infrastructure
{
    public class WarehouseViewEngine : ThemeableRazorViewEngine
    {
        public WarehouseViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Plugins/Misc.Warehouse/Views/{1}/{0}.cshtml",
                "~/Plugins/Misc.Warehouse/Views/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new[]
            {
                "~/Plugins/Misc.Warehouse/Views/{1}/{0}.cshtml" ,
                "~/Plugins/Misc.Warehouse/Views/Shared/{0}.cshtml"
            };
        }
    }
}