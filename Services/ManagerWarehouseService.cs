using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Plugin.Misc.Warehouse.Domain;
using Nop.Services.Events;

namespace Nop.Plugin.Misc.Warehouse.Services
{
    public class ManagerWarehouseService : IManagerWarehouseService
    {
        #region Ctor

        public ManagerWarehouseService(IRepository<WarehouseState> warehouseStateRepository, ICacheManager cacheManager, IEventPublisher eventPublisher)
        {
            _warehouseStateRepository = warehouseStateRepository;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
        }

        #endregion

        #region Constants

        /// <summary>
        ///     Key for caching
        /// </summary>
        /// <remarks>
        ///     {0} : warehouseState ID
        /// </remarks>
        private const string WAREHOUSESTATE_BY_ID_KEY = "Nop.warehousestate.id-{0}";

        /// <summary>
        ///     Key for caching
        /// </summary>
        /// <remarks>
        ///     {0} : warehouse ID
        /// </remarks>
        private const string WAREHOUSESTATE_BY_WAREHOUSEID_KEY = "Nop.warehousestate.warehouseId-{0}";

        /// <summary>
        ///     Key pattern to clear cache
        /// </summary>
        private const string WAREHOUSESTATE_PATTERN_KEY = "Nop.warehousestate.";

        #endregion

        #region Fields

        private readonly IRepository<WarehouseState> _warehouseStateRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Methods

        #region WarehouseState

        public virtual void DeleteWarehouseSatte(WarehouseState warehouseState)
        {
            if (warehouseState == null)
                throw new ArgumentNullException("warehouseState");

            _warehouseStateRepository.Delete(warehouseState);

            //clear cache
            _cacheManager.RemoveByPattern(WAREHOUSESTATE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityDeleted(warehouseState);
        }

        public virtual WarehouseState GetWarehouseStateById(int warehouseStateId)
        {
            if (warehouseStateId == 0)
                return null;

            var key = string.Format(WAREHOUSESTATE_BY_ID_KEY, warehouseStateId);
            return _cacheManager.Get(key, () => _warehouseStateRepository.GetById(warehouseStateId));
        }

        public virtual IList<WarehouseState> GetStatesByWarehouse(int warehouseId = 0)
        {
            if (warehouseId == 0)
                return null;

            var key = string.Format(WAREHOUSESTATE_BY_WAREHOUSEID_KEY, warehouseId);
            return _cacheManager.Get(key, () =>
            {
                var states = from s in _warehouseStateRepository.Table
                             orderby s.ParentStateId
                             where s.WarehouseId == warehouseId
                             select s;

                return states.ToList();
            });
        }

        public virtual void InsertWarehouseState(WarehouseState warehouseState)
        {
            if (warehouseState == null)
                throw new ArgumentNullException("warehouseState");

            _warehouseStateRepository.Insert(warehouseState);

            //clear cache
            _cacheManager.RemoveByPattern(WAREHOUSESTATE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(warehouseState);
        }

        public virtual void UpdateWarehouseState(WarehouseState warehouseState)
        {
            if (warehouseState == null)
                throw new ArgumentNullException("warehouseState");

            _warehouseStateRepository.Update(warehouseState);

            //clear cache
            _cacheManager.RemoveByPattern(WAREHOUSESTATE_PATTERN_KEY);

            //event notification
            _eventPublisher.EntityInserted(warehouseState);
        }

        #endregion

        #endregion
    }
}