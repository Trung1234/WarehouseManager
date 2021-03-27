using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Utility
{
    public class Constant
    {
        public enum ExportMode
        {
            Csv,
            Excel,
        }
        public enum ExportResult
        {
            Cancel,
            Error,
            Success,
        }
        public const string ErrorFileMessage = "Có lỗi xảy ra khi lưu file .";
        public const string InventoryNotExist =  "Không có hàng tồn nào cả.";
    }
}
