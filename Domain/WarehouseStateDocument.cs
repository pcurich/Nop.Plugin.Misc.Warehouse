using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Nop.Plugin.Misc.Warehouse.Domain
{
    public class WarehouseStateDocument : BaseEntity
    {
        private ICollection<WarehouseStateFlowControl> _warehouseStateFlowControls;
        public string DocumentName { get; set; }
        public string DocumentTemplate { get; set; }

        public virtual ICollection<WarehouseStateFlowControl> WarehouseStateFlowControls
        {
            get
            {
                return _warehouseStateFlowControls ??
                       (_warehouseStateFlowControls = new List<WarehouseStateFlowControl>());
            }
            protected set { _warehouseStateFlowControls = value; }
        }
    }
}