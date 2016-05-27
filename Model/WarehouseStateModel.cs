using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework;

namespace Nop.Plugin.Misc.Warehouse.Model
{
    public class WarehouseStateModel
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
        public bool Active { get; set; }
    }
}
