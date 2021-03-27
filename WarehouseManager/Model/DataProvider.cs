using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Log;
using WarehouseManager.ViewModel;

namespace WarehouseManager.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Instance
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public WarehouseEntities DB { get; set; }

        private DataProvider()
        {
            DB = new WarehouseEntities();
        }
        /// <summary>
        /// get all Inventory info using store proc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Inventory> GetInventories()
        {
            IEnumerable<Inventory> inventories = null;
            try
            {
                inventories = DB.Database.SqlQuery<Inventory>("exec GetInventoryData ");
                return inventories;
            }           
            catch (Exception ex)
            {
                LoggerManager.LogError(nameof(DataProvider), nameof(GetInventories), ex);
                return new List<Inventory>();
            }
        }
    }
}
