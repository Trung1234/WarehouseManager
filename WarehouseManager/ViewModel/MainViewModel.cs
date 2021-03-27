using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WarehouseManager.Log;
using WarehouseManager.Model;
using WarehouseManager.Utility;
using static WarehouseManager.Utility.Constant;

namespace WarehouseManager.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Properites
        public bool isloaded = false;
        public bool Isloaded
        {
            get { return isloaded; }
            set { isloaded = value; }
        }
        private ObservableCollection<Inventory> inventories;
        public ObservableCollection<Inventory> Inventories
        {
            get => inventories;
            set
            {
                inventories = value;
                OnPropertyChanged("Inventories");
            }
        } 
        #endregion

        #region Command Region
        public ICommand LoadedWindowCommand { get; set; }

        public ICommand UnitCommand
        {
            get
            {
                return new RelayCommand(() => OpenUnitWindow());
            }
        }

        private void OpenUnitWindow()
        {
            UnitWindow wd = new UnitWindow();
            wd.ShowDialog();
        }

        public ICommand SuplierCommand
        {
            get
            {
                return new RelayCommand(() => OpenSuplierWindow());
            }
        }

        public ICommand CustomerCommand
        {
            get
            {
                return new RelayCommand(() => OpenCustomerWindow());
            }
        }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand ExportExcelCommand
        {
            get
            {
                return new RelayCommand(() => OnExportExcelCommand());
            }
        }

        public ICommand ExportCsvCommand
        {
            get
            {
                return new RelayCommand(() => OnExportCsvCommand());
            }
        } 
        #endregion

        /// <summary>
        /// constructor for MainViewdow
        /// </summary>
        public MainViewModel()
        {
            try
            {
                LoadedWindowCommand = new WMRelayCommand<Window>((p) => { return true; }, (p) => {
                    Isloaded = true;
                    if (p == null)
                        return;
                    p.Hide();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();

                    if (loginWindow.DataContext == null)
                        return;
                    var loginVM = loginWindow.DataContext as LoginViewModel;

                    if (loginVM.IsLogin)
                    {
                        p.Show();
                        try
                        {
                            Inventories = new ObservableCollection<Inventory>(DataProvider.Instance.GetInventories());
                        }
                        catch (SqlException ex)
                        {
                            LoggerManager.LogError(nameof(MainViewModel), nameof(MainViewModel), ex);
                            Inventories = new ObservableCollection<Inventory>();
                        }
                        
                    }
                    else
                    {
                        p.Close();
                    }
                    }
                  );
            }
            catch(Exception ex)
            {
                LoggerManager.LogError(nameof(MainViewModel), nameof(MainViewModel), ex);
            }             
        }

        #region private method
        private void OpenCustomerWindow()
        {
            CustomerWindow cwd = new CustomerWindow();
            cwd.ShowDialog();
        }
        private void OpenSuplierWindow()
        {
            SuplierWindow wd = new SuplierWindow();
            wd.ShowDialog();
        }

        private void OnExportCsvCommand()
        {
            if (Inventories != null)
            {
                ExportResult exportResult = ExportFileFactory.CreateFactory(ExportMode.Csv).Export(Inventories.ToList());
                if (exportResult == ExportResult.Success)
                {
                    // Confirm to the user it has been completed.
                    System.Windows.MessageBox.Show("Excel file đã được lưu.");
                }
                else if (exportResult == ExportResult.Error)
                {
                    System.Windows.MessageBox.Show(Constant.ErrorFileMessage);
                }
            }
            else
            {
                System.Windows.MessageBox.Show(Constant.InventoryNotExist);
            }
        }

        private void OnExportExcelCommand()
        {
            if (Inventories != null)
            {
                ExportResult exportResult = ExportFileFactory.CreateFactory(ExportMode.Excel).Export(Inventories.ToList());
                if (exportResult == ExportResult.Success)
                {
                    // Confirm to the user it has been completed.
                    System.Windows.MessageBox.Show("Excel file đã được lưu.");
                }
                else if (exportResult == ExportResult.Error)
                {
                    System.Windows.MessageBox.Show(Constant.ErrorFileMessage);
                }
            }
            else
            {
                System.Windows.MessageBox.Show(Constant.InventoryNotExist);
            }
        } 
        #endregion

        //public ObservableCollection<Inventory> GetInventories()
        //{
        //    var objectList = DataProvider.Ins.DB.Objects;

        //    int i = 1;
        //    foreach (var item in objectList)
        //    {
        //        var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
        //        var outputList = DataProvider.Ins.DB.OutputInfoes.Where(p => p.IdObject == item.Id);

        //        int sumInput = inputList != null ? (int)inputList.Sum(p => p.Count) : 0;
        //        int sumOutput = outputList != null ? (int)outputList.Sum(p => p.Count) : 0;
        //        result.Add(new Inventory
        //        {
        //            OrderNumber = i,
        //            Quantity = sumInput - sumOutput,
        //            Object = item
        //        });
        //        i++;
        //    }
        //    return result;
        //}
    }
}
