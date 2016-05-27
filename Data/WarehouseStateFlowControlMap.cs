using Nop.Data.Mapping;
using Nop.Plugin.Misc.Warehouse.Domain;

namespace Nop.Plugin.Misc.Warehouse.Data
{
    public class WarehouseStateFlowControlMap : NopEntityTypeConfiguration<WarehouseStateFlowControl>
    {
        public WarehouseStateFlowControlMap()
        {
            ToTable("WarehouseStateFlowControl");

            Property(fc => fc.WarehouseStateFromId).IsRequired();
            Property(fc => fc.WarehouseStateToId).IsRequired();

            HasRequired(fc => fc.WarehouseStateDocument)
                .WithMany(fc => fc.WarehouseStateFlowControls)
                .HasForeignKey(fc => fc.WarehouseStateDocumentId);
        }
    }
}