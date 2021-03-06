﻿using Nop.Core;

namespace Nop.Plugin.Misc.Warehouse.Domain
{
    public class WarehouseStateFlowControl : BaseEntity
    {
        public int WarehouseStateFromId { get; set; }
        public int WarehouseStateToId { get; set; }
        public int WarehouseStateDocumentId { get; set; }
        public virtual WarehouseStateDocument WarehouseStateDocument { get; set; }
        public bool Published { get; set; }
    }
}