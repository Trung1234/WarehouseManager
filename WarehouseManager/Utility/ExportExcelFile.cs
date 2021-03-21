﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManager.Model;

namespace WarehouseManager.Utility
{
    public class ExportExcelFile : IExportFile
    {
        public bool Export(List<Inventory> inventories)
        {
            try
            { 
                // use EPPlus in a noncommercial context according to the Polyform Noncommercial license:
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //create a new Worksheet
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                 
                    int totalRows = inventories.Count;
                    //add some text to cell A1
                    worksheet.Cells[1, 2].Value = " SerialNumber";
                    worksheet.Cells[1, 3].Value = " DisplayName";
                    worksheet.Cells[1, 4].Value = " Quantity";
                    int i = 0;
                    for (int row = 2; row <= totalRows + 1; row++)
                    {
                        worksheet.Cells[row, 2].Value = inventories[i].SerialNumber;
                        worksheet.Cells[row, 3].Value = inventories[i].DisplayName;
                        worksheet.Cells[row, 4].Value = inventories[i].Quantity;
                        i++;
                    }
                    //create a SaveFileDialog instance with some properties
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "Save Excel sheet";
                    saveFileDialog1.Filter = "Excel files|*.xlsx|All files|*.*";
                    saveFileDialog1.FileName = "ExcelSheet_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                    //check if user clicked the save button
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Get the FileInfo
                        FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                        //write the file to the disk
                        excelPackage.SaveAs(fi);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;           
        }
    }
}