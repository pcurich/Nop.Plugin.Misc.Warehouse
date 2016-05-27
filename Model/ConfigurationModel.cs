using Nop.Web.Framework;

namespace Nop.Plugin.Misc.Warehouse.Model
{
    public class ConfigurationModel
    {
        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.Length")]
        public int Length { get; set; }
        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.Name")]
        public string Name { get; set; }
 
    }
}
 