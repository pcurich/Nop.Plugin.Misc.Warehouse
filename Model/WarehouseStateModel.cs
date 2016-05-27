using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Misc.Warehouse.Model
{
    public class WarehouseStateModel : BaseNopEntityModel
    {
        public int WarehouseId { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.WarehouseName")]
        public string WarehouseName { get; set; }

        public int ParentStateId { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.ParentStateName")]
        public string ParentStateName { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.StateName")]
        public string NameState { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.Active")]
        public bool Published { get; set; }
    }
}