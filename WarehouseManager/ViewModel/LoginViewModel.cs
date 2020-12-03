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
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ProcessLogin(p); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        private void ProcessLogin(Window p)
        {
            if (p == null)
                return;
            // pass = admin
            string passEncode = MD5Hash(Base64Encode(Password));
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

        /// <summary>
        /// convert string to base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// convert string to MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
