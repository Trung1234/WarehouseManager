﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManager.Model;

namespace WarehouseManager.Utility
{
    public interface IExportFile
    {
        bool Export(List<Inventory> inventories);
    }
}
