using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.ViewModel;

namespace WarehouseManager.Model.ModelExtended
{
    public class UserModel : BaseViewModel
    {
        public int Id { get; set; }
        private string _DisplayName;
        public string DisplayName
        {
            get => _DisplayName;
            set
            {
                _DisplayName = value;
                OnPropertyChanged("DisplayName");

            }
        }
    }
}
