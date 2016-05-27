using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.Misc.Warehouse.Data;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Misc.Warehouse.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_manager_warehouse";

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            this.RegisterPluginDataContext<WarehouseObjectContext>(builder, CONTEXT_NAME);

            //builder.RegisterType<EfRepository<PromoSliderRecord>>()
            //    .As<IRepository<PromoSliderRecord>>()
            //    .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME));

            //builder.RegisterType<EfRepository<PromoImageRecord>>()
            //    .As<IRepository<PromoImageRecord>>()
            //    .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME));
        }

        public int Order
        {
            get { return 1; }
        }
    }
}