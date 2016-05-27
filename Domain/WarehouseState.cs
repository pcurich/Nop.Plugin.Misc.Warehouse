using System.Collections.Generic;
using Nop.Core;

namespace Nop.Plugin.Misc.Warehouse.Domain
{
    public class WarehouseState : BaseEntity
    {
        private ICollection<WarehouseStateFlowControl> _warehouseStateFlowControls;
        public int WarehouseId { get; set; }
        public int ParentStateId { get; set; }
        public string NameState { get; set; }
        public bool Active { get; set; }

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