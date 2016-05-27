using System.Collections.Generic;
using Nop.Plugin.Misc.Warehouse.Domain;

namespace Nop.Plugin.Misc.Warehouse.Services
{
    public interface IManagerWarehouseService
    {
        #region WarehouseState

        void DeleteWarehouseSatte(WarehouseState warehouseState);
        WarehouseState GetWarehouseStateById(int warehouseStateId);
        IList<WarehouseState> GetStatesByWarehouse(int warehouseId = 0);
        void InsertWarehouseState(WarehouseState warehouseState);
        void UpdateWarehouseState(WarehouseState warehouseState);

        #endregion
    }
}