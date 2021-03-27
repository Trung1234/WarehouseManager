using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WarehouseManager.Model;
using WarehouseManager.Utility;

namespace WarehouseManager.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get;private set; }
        private string _UserName;
        public string UserName 
        { 
            get => _UserName; 
            set 
            { 
                _UserName = value;
                OnPropertyChanged("UserName");
            }
        }
        private string _Password;
        public string Password
        {
            get => _Password;
            set { 
                _Password = value;
                OnPropertyChanged("Password");
            } 
        }

        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        /// <summary>
        /// logic for login process
        /// </summary>
        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new WMRelayCommand<Window>((p) => { return true; }, (p) => { ProcessLogin(p); });
            CloseCommand = new WMRelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new WMRelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        private void ProcessLogin(Window p)
        {
            if (p == null)
                return;
            // pass = admin
            string passEncode = StringUtil.MD5Hash(StringUtil.Base64Encode(Password));
            int accCount = DataProvider.Instance.DB.Users.Count(x => 
                                    x.UserName.Equals(UserName)
                                    && x.Password.Equals(passEncode));
            if (accCount > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }        
    }
}
