using System.Linq;
using System.Web.Routing;
using Nop.Core.Domain.Security;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Plugin.Misc.Warehouse.Data;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.Warehouse
{
    public class WarehousePlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        private readonly WarehouseObjectContext _context;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public WarehousePlugin(WarehouseObjectContext context, ISettingService settingService, ILocalizationService localizationService)
        {
            _context = context;
            _settingService = settingService;
            _localizationService = localizationService;
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            var permissionRecord = new PermissionRecord
            {
                Category = "Plugin",
                SystemName = "ManagerWarehouse",
                Name = "Admin area. Manager Warehouse"
            };

            //if (permissionService.Authorize(permissionRecord))
            //{
            var parentNode = new SiteMapNode
            {
                SystemName = "ManagerWarehouse",
                Title = "Manager Of Warehouse",
                //ActionName = " ",
                ControllerName = "ManagerWarehouse",
                Visible = true,
                RouteValues = new RouteValueDictionary { { "area", null } }
            };

            var manageState = new SiteMapNode
            {
                SystemName = "WidgetPromoSlider",
                Title = "States of Flow",//_localizationService.GetResource("Plugins.Widget.PromoSlider.Menu.ManagerSliders"),
                ActionName = "WarehouseState",
                ControllerName = "ManagerWarehouse",
                Visible = true,
                RouteValues = new RouteValueDictionary { { "area", null } }
            };

            parentNode.ChildNodes.Add(manageState);

            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "ManagerWarehouse");
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(parentNode);
            else
                rootNode.ChildNodes.Add(parentNode);

            //}
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName,
            out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "ManagerWarehouse";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "Nop.Plugin.Widget.PromoSlider.Controllers"},
                {"area", null}
            };
        }

        #region Install / Uninstall

        public override void Install()
        {
            #region Localization

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ProductName", "Product", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ProductName.Hint", "Id Product as used as part of sku code", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.AttributeName", "Attribute", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.AttributeName.Hint", "Id Attribute of a Product as used as part of sku code", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ValueName", "Value", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ValueName.Hint", "Id Value of a atribute in a Product as used as part of sku code", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Length", "Length", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Length.Hint", "Length's part of code", "en-US");

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Title", "Manager and Configration of Warehouses", "en-US");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Description", "In this module you can manager the code of your products", "en-US");

            #endregion

            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            var permissionRecord = new PermissionRecord
            {
                Category = "Plugin",
                SystemName = "ManagerWarehouse",
                Name = "Admin area. Manager Warehouse"
            };
            permissionService.InsertPermissionRecord(permissionRecord);

            var settings = new WarehouseSettings
            {
                ProductLength = 4,
                AttributeLength = 2,
                ValueLength = 2
            };
            _settingService.SaveSetting(settings);
            _context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<WarehouseSettings>();

            #region Localization

            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ProductName");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ProductName.Hint");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.AttributeName");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.AttributeName.Hint");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ValueName");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.ValueName.Hint");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Length");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Length.Hint");


            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Title");
            this.DeletePluginLocaleResource("Plugins.Misc.Warehouse.Fields.Description");

            #endregion

            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            var permission = permissionService.GetPermissionRecordBySystemName("ManagerWarehouse");
            
            if (permission!=null)
                permissionService.DeletePermissionRecord(permission);

            _context.Uninstall();
            base.Uninstall();
        }

        #endregion
    }
}