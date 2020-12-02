using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Model
{
    public class Inventory
    {
        public int OrderNumber { get; set; }
        public Object Object { get; set; }
        public int Quantity { get; set; }
    }
}
