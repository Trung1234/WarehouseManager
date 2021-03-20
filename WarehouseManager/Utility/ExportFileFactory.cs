using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WarehouseManager.Utility.Constant;

namespace WarehouseManager.Utility
{
    public class ExportFileFactory
    {
        public static IExportFile CreateFactory(ExportMode mode)
        {
            switch (mode)
            {
                case ExportMode.Csv:
                    return new ExportCsvFile();
                case ExportMode.Excel:
                    return new ExportExcelFile();
                default:
                    return new ExportCsvFile();
            }
            
        }
    }
}
