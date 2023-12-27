﻿using Library_Management_App.Model;
using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Library_Management_App.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public static bool IsLogin { get; set; }

        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public static Frame MainFrame { get; set; }

        public Button LoginButton { get; set; }

        public ICommand LoginCM { get; set; }

        public ICommand LoadLoginPageCM { get; set; }

        public ICommand ForgetPasswordCM { get; set; }

        public ICommand Login { get; set; }

        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

            IsLogin = false;
            Password = "";
            Username = "";

            LoadLoginPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                LoginView lgView = new LoginView();


                p.Content = new LoginPageView();
            });


            LoginCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                try
                {
                    //MessageBox.Show(Password);
                    string PassEncode = MD5Hash(Base64Encode(Password));

                    var accCount = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.USERNAME == Username && x.PASS == PassEncode && x.TTND).Count();

                    foreach (NGUOIDUNG temp in DataProvider.Ins.DB.NGUOIDUNGs)
                    {
                        if ((temp.USERNAME == Username) && (temp.PASS == PassEncode))
                        {
                            accCount++;
                            break;
                        }

                    }



                    if (accCount > 0)
                    {
                        IsLogin = true;
                        Const.UserName = Username;
                        Window oldWindow = App.Current.MainWindow;
                        MainView mainView = new MainView();
                        App.Current.MainWindow = oldWindow;
                        oldWindow.Close();
                        mainView.Show();
                        Username = "";
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK);
                    }
                }
                catch
                {
                    MessageBox.Show("Mất kết nối đến cơ sở dữ liệu!", "Thông báo", MessageBoxButton.OK);
                }
            });

            ForgetPasswordCM = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ForgotPasswordPageView();
            });




        }

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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


    }
}
