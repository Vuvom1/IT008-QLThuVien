using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using System.Windows.Navigation;
using Library_Management_App.Model;

namespace Library_Management_App.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        private string _selectedOption;
        public string SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }
        public ICommand Loadwd { get; set; }
        public static Frame MainFrame { get; set; }

        public ICommand TenDangNhap_Loaded { get; set; }
        public ICommand Quyen_Loaded { get; set; }

        public ICommand LoadPageCM { get; set; }

        public ICommand SignoutCM { get; set; }

        public ICommand BookCM { get; set; }

        public ICommand ReaderCM { get; set; }

        public ICommand SettingCM { get; set; }

        public ICommand BorrowCM { get; set; }

        public ICommand FineMoneyCM { get; set; }

        public ICommand ImportCM { get; set; }

        public ICommand AddImport { get; set; }
        public ICommand QLNVCM { get; set; }


        private NGUOIDUNG _User;

        public NGUOIDUNG User { get => _User; set { _User = value; OnPropertyChanged(); } }

        private Visibility _SetRole;
        public Visibility SetQuanLy { get => _SetRole; set { _SetRole = value; OnPropertyChanged(); } }
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }

        public void LoadTenND(MainView p)
        {
            p.TenDangNhap.Text = string.Join(" ", User.TENND.Split().Reverse().Take(2).Reverse());
        }

        void _Loadwd(MainView p)
        {
            if (LoginViewModel.IsLogin)
            {
                string a = Const.UserName;
                User = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.USERNAME == a).FirstOrDefault();
                Const.ND = User;
                if (User.MAROLE == 0)
                {
                    SetQuanLy = Visibility.Visible;
                   
                } else
                {
                    SetQuanLy = Visibility.Collapsed;
                }
                //Const.Admin = User.MAROLE;
                Ava = User.AVA;
                LoadTenND(p);
            }
        }
        public void LoadQuyen(MainView p)
        {
            if (User.MAROLE == 0)
            { 
                p.Quyen.Text = "Quản lý"; 
            }
            else 
            {
                p.Quyen.Text = "Nhân viên"; 
            }
        }

        public MainViewModel()
        {
            Loadwd = new RelayCommand<MainView>((p) => true, (p) => _Loadwd(p));
            Quyen_Loaded = new RelayCommand<MainView>((p) => true, (p) => LoadQuyen(p));
            TenDangNhap_Loaded = new RelayCommand<MainView>((p) => true, (p) => LoadTenND(p));


            LoadPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new HomeView();
            });

            ReaderCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ReadersView();
            });

            BookCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new BooksView();
            });

            BorrowCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new BorrowView();
            });

            SettingCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new SettingView();
            });

            ImportCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new ImportBookView();
            });

            AddImport = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new AddImportBookView();
            });

            FineMoneyCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new FineMoneyView();
            });

            QLNVCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new QLNVView();
            });


            SignoutCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParentWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Hide();
                    LoginView w1 = new LoginView();
                    w1.ShowDialog();
                    w.Close();
                }
            });

            FrameworkElement GetParentWindow(FrameworkElement p)
            {
                FrameworkElement parent = p;

                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }
                return parent;
            }
        }


    }
}
