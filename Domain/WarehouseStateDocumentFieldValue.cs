using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Nop.Plugin.Misc.Warehouse.Domain
{
    public class WarehouseStateDocumentFieldValue : BaseEntity
    {
        public int WarehouseStateDocumentId { get; set; }
        public WarehouseStateDocument WarehouseStateDocument { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }


    }
}