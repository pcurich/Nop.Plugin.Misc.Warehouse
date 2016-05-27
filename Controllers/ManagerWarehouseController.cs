using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Plugin.Misc.Warehouse.Model;
using Nop.Plugin.Misc.Warehouse.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;

namespace Nop.Plugin.Misc.Warehouse.Controllers
{
    public class ManagerWarehouseController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IStoreService _storeService;
        private readonly IWorkContext _workContext;
        private readonly IShippingService _shippingService;
        private readonly IManagerWarehouseService _managerWarehouseService;

        private readonly IPermissionService _permissionService;
        private PermissionRecord permissionRecord = new PermissionRecord
        {
            Category = "Plugin",
            SystemName = "ManagerWarehouse",
            Name = "Admin area. Manager Warehouse"
        };

        public ManagerWarehouseController(ILocalizationService localizationService, ISettingService settingService, IStoreService storeService, IWorkContext workContext, IShippingService shippingService, IPermissionService permissionService)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _storeService = storeService;
            _workContext = workContext;
            _shippingService = shippingService;
            _permissionService = permissionService;
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
            var model = new WarehouseStateListModel()
            {
                Availablewarehouses = _shippingService.GetAllWarehouses()
                .Select(x=> new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                   
                }).ToList()
            };
            model.Availablewarehouses.Insert(0,new SelectListItem{Text = _localizationService.GetResource(""), Value = "0"});
            return View(model);
        }

        [HttpPost]
        public ActionResult WarehouseStateList(DataSourceRequest command, WarehouseStateListModel model)
        {
            var states = _managerWarehouseService.GetStatesByWarehouse(model.WarehouseId);
            var gridModel = new DataSourceResult
            {
                Data = states.Select(x => new WarehouseStateModel
                {
                    Id = x.Id,
                    WarehouseName= x.Warehouse.Name,
                    Published = x.Published,
                    WarehouseId = x.WarehouseId,
                    NameState = x.NameState,
                    ParentStateId = x.ParentStateId,
                    ParentStateName = _managerWarehouseService.GetWarehouseStateById(x.Id).NameState,
                }),
                Total = states.Count
            };

            return Json(gridModel);
        }
        #endregion
    }
}