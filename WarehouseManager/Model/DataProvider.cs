using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IEnumerable<Inventory> GetInventories()
        {
            IEnumerable<Inventory> inventories = null;
            try
            {
                inventories = DB.Database.SqlQuery<Inventory>("exec GetInventoryData ");
                return inventories;
            }
            catch(Exception ex)
            {
                return new List<Inventory>();
            }    
        }
    }
}
