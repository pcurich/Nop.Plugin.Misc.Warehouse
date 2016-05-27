using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.Warehouse.Model;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.Warehouse.Controllers
{
    public class ManagerWarehouseController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IStoreService _storeService;
        private readonly IWorkContext _workContext;

        public ManagerWarehouseController(ISettingService settingService, IStoreService storeService,
            IWorkContext workContext, ILocalizationService localizationService)
        {
            _settingService = settingService;
            _storeService = storeService;
            _workContext = workContext;
            _localizationService = localizationService;
        }

        #region Configure

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            //load settings for a chosen store scope
            var storeScope = GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var wareouseSettings = _settingService.LoadSetting<WarehouseSettings>(storeScope);
            var model = new List<ConfigurationModel>
            {
                new ConfigurationModel
                {
                    Name = _localizationService.GetResource("Plugins.Misc.Warehouse.Fields.Product"),
                    Length = wareouseSettings.ProductLength,
                },
                new ConfigurationModel
                {
                    Name = _localizationService.GetResource("Plugins.Misc.Warehouse.Fields.Attribute"),
                    Length = wareouseSettings.AttributeLength,
                },
                new ConfigurationModel
                {
                    Name = _localizationService.GetResource("Plugins.Misc.Warehouse.Fields.Value"),
                    Length = wareouseSettings.ValueLength,
                }
            };
 
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(List<ConfigurationModel> model)
        {
            //load settings for a chosen store scope
            var storeScope = GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var warehouseSettings = _settingService.LoadSetting<WarehouseSettings>(storeScope);

            foreach (var configurationModel in model)
            {
                 
                if (_localizationService.GetResource("Plugins.Misc.Warehouse.Fields.Product") == configurationModel.Name)
                {
                    warehouseSettings.ProductLength = configurationModel.Length;
                }
                if (_localizationService.GetResource("Plugins.Misc.Warehouse.Fields.Attribute") == configurationModel.Name)
                {
                    warehouseSettings.AttributeLength = configurationModel.Length;
   }
                if (_localizationService.GetResource("Plugins.Misc.Warehouse.Fields.Value") == configurationModel.Name)
                {
                    warehouseSettings.ValueLength = configurationModel.Length;
                }
            }
            _settingService.SaveSetting(warehouseSettings);

            //now clear settings cache
            _settingService.ClearCache();

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }

        #endregion

        #region WarehouseState

        [AdminAuthorize]
        public ActionResult WarehouseState()
        {
            var model = new WarehouseStateModel()
            {
                Active = true
            };
            return View(model);
        }

        #endregion
    }
}