using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Model
{
    public class Inventory
    {
        public long SerialNumber { get; set; }
        public string DisplayName { get; set; }
        public int Quantity { get; set; }
    }
}
