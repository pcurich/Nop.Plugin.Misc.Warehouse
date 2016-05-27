using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;

namespace Nop.Plugin.Misc.Warehouse.Model
{
    public class WarehouseStateListModel
    {
        public WarehouseStateListModel()
        {
            Availablewarehouses= new List<SelectListItem>();
        }

        [NopResourceDisplayName("Plugins.Misc.Warehouse.Fields.WarehouseName")]
        public int WarehouseId { get; set; }
        public IList<SelectListItem> Availablewarehouses { get; set; }
    }
}