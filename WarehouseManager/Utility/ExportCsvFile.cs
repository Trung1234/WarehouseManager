

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WarehouseManager.Log;
using WarehouseManager.Model;

namespace WarehouseManager.Utility
{
    public class ExportCsvFile : IExportFile
    {
       
        public bool Export(List<Inventory> inventories)
        {
            LoggerManager.LogInfo(nameof(ExportCsvFile), nameof(Export));
            try
            {
                StringBuilder sb = new StringBuilder();
                // Column headers
                sb.Append("STT,Tên vật tư,Số lượng tồn"  + Environment.NewLine);
                foreach (Inventory inventory in inventories)
                {
                    // Append the cells data followed by a comma to delimit.
                    sb.Append(inventory.SerialNumber.ToString() + ","+inventory.DisplayName + ","+inventory.Quantity.ToString());
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
                // Load up the save file dialog with the default option as saving as a .csv file.
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV files (*.csv)|*.csv";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // If user has selected a save location...
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, Encoding.Unicode))
                    {
                        // Write the stringbuilder text to the the file.
                        sw.WriteLine(sb.ToString());
                    }
                }                
            }
            catch(Exception ex)
            {
                return false;
            }          
            return true;
        }
    }
}
