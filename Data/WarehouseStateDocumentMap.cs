using Nop.Data.Mapping;
using Nop.Plugin.Misc.Warehouse.Domain;

namespace Nop.Plugin.Misc.Warehouse.Data
{
    public class WarehouseStateDocumentMap : NopEntityTypeConfiguration<WarehouseStateDocument>
    {
        public WarehouseStateDocumentMap()
        {
            ToTable("WarehouseStateDocument");
            HasKey(wsd => wsd.Id);

            Property(wsd => wsd.DocumentName)
                .IsRequired()
                .HasMaxLength(400);

            Property(wsd => wsd.DocumentTemplate)
                .IsRequired()
                .HasMaxLength(400);
        }
    }
}