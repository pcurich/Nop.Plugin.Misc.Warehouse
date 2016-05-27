using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.Warehouse
{
    public class WarehouseSettings : ISettings
    {
        public int ProductLength { get; set; }
        public int AttributeLength { get; set; }
        public int ValueLength { get; set; }
    }
}