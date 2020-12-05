using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseManager.Model;
using WarehouseManager.Model.ModelExtended;
using WarehouseManager.Proccess;

namespace WarehouseManager.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<UserModel> _List;
        public ObservableCollection<UserModel> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private readonly UnitProcess unitProcess = new UnitProcess();
        private UserModel _SelectedItem;
        public UserModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public UnitViewModel()
        {
            List = new ObservableCollection<UserModel>();
            var units = DataProvider.Instance.DB.Units;
            foreach (var unit in units)
            {
                List.Add(new UserModel
                {
                    Id = unit.Id,
                    DisplayName = unit.DisplayName
                });
            }
            AddCommand = new RelayCommand<object>((p) =>
            {
                //condition for excuting AddCommand
                return unitProcess.CanAddOrEdit(DisplayName);
            }, (p) =>
            {
                var newUnit = unitProcess.Add(DisplayName);
                List.Add(new UserModel() { 
                    Id = newUnit.Id,
                    DisplayName = DisplayName
                });
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                //condition for excuting EditCommand
                return unitProcess.CanAddOrEdit(DisplayName, SelectedItem, true);

            }, (p) =>
            {
                unitProcess.Edit(SelectedItem.Id, DisplayName);        
                SelectedItem.DisplayName = DisplayName;
            });
        }
    }
}
