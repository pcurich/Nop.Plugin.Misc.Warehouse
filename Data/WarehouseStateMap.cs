
using Nop.Data.Mapping;
using Nop.Plugin.Misc.Warehouse.Domain;

namespace Nop.Plugin.Misc.Warehouse.Data
{
    public class WarehouseStateMap : NopEntityTypeConfiguration<WarehouseState>
    {
        public WarehouseStateMap()
        {
            ToTable("WarehouseState");
            HasKey(ws => ws.Id);

            Property(ws => ws.NameState)
                .IsRequired()
                .HasMaxLength(400);

            HasRequired(ws => ws.Warehouse)
                .WithMany()
                .HasForeignKey(ws => ws.WarehouseId);


        }
    }
}