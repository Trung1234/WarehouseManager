using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WarehouseManager.Model;
using WarehouseManager.Utility;
using static WarehouseManager.Utility.Constant;

namespace WarehouseManager.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
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
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand ExportCsvCommand { get; set; }
        public ICommand ExportExcelCommand { get; set; }
        private IEnumerable<Inventory> inventoryList;

        /// <summary>
        /// logic events for MainViewdow
        /// </summary>
        public MainViewModel()
        {
            CustomerWindow cwd = null;
            try
            {
                LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
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
                        inventoryList = DataProvider.Instance.GetInventories();
                        Inventories = new ObservableCollection<Inventory>(inventoryList);
                    }
                    else
                    {
                        p.Close();
                    }
                    }
                  );

                CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    cwd = new CustomerWindow();
                    cwd.ShowDialog();
                });
                InputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    InputWindow wd = new InputWindow();
                    wd.ShowDialog();
                });
                OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    OutputWindow wd = new OutputWindow();
                    wd.ShowDialog();
                });

                UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    UnitWindow wd = new UnitWindow();
                    wd.ShowDialog();
                });
                UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    UnitWindow wd = new UnitWindow();
                    wd.ShowDialog();
                });
                SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    SuplierWindow wd = new SuplierWindow();
                    wd.ShowDialog();
                });
                ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    ObjectWindow wd = new ObjectWindow();
                    wd.ShowDialog();
                });
                UserCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    UserWindow wd = new UserWindow();
                    wd.ShowDialog();
                });
                bool canExport = true;
                ExportCsvCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    canExport = ExportFileFactory.CreateFactory(ExportMode.Csv).Export(inventoryList.ToList());
                    if (canExport)
                    {
                        // Confirm to the user it has been completed.
                        System.Windows.MessageBox.Show("CSV file  đã được lưu.");
                    }
                    else{
                        System.Windows.MessageBox.Show("Có lỗi xảy ra khi lưu file .");
                    }
                });
                ExportExcelCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    canExport = ExportFileFactory.CreateFactory(ExportMode.Excel).Export(inventoryList.ToList());
                    if (canExport)
                    {
                        // Confirm to the user it has been completed.
                        System.Windows.MessageBox.Show("Excel file  đã được lưu.");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Có lỗi xảy ra khi lưu Excel .");
                    }
                });
            }
            catch(Exception ex)
            {

            }             
        }

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
