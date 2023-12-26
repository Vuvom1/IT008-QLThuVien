﻿using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    class AddImportBookViewModel:  BaseViewModel
    {
        private List<SACH> _LSP;
        public List<SACH> LSP { get => _LSP; set { _LSP = value; OnPropertyChanged(); } }
        private ObservableCollection<Display1> _LHT;
        public ObservableCollection<Display1> LHT { get => _LHT; set { _LHT = value; OnPropertyChanged(); } }
        private ObservableCollection<SACH> _LSPSelected;
        public ObservableCollection<SACH> LSPSelected { get => _LSPSelected; set { _LSPSelected = value; OnPropertyChanged(); } }
        private ObservableCollection<CTPN> _LCTPN;
        public ObservableCollection<CTPN> LCTPN { get => _LCTPN; set { _LCTPN = value; OnPropertyChanged(); } }
        public ICommand Loadwd { get; set; }
        public ICommand AddSP { get; set; }
        public ICommand DeleteSP { get; set; }
        public ICommand SavePN { get; set; }
        public ICommand Choose { get; set; }
        public int tongtien { get; set; }

        public AddImportBookViewModel()
        {
            tongtien = 0;
            LSPSelected = new ObservableCollection<SACH>();
            LHT = new ObservableCollection<Display1>();
            LCTPN = new ObservableCollection<CTPN>();
            Choose = new RelayCommand<AddImportBookView>((p) => true, (p) => _Choose(p));
            Loadwd = new RelayCommand<AddImportBookView>((p) => true, (p) => _Loadwd(p));
            AddSP = new RelayCommand<AddImportBookView>((p) => true, (p) => _AddSP(p));
            DeleteSP = new RelayCommand<AddImportBookView>((p) => true, (p) => _DeleteSP(p));
            SavePN = new RelayCommand<AddImportBookView>((p) => true, (p) => _SavePN(p));
        }

        void _Loadwd(AddImportBookView paramater)
        {
            LSP = DataProvider.Ins.DB.SACHes.Where(p => p.TONGSL >= 0).ToList();
            paramater.SP.ItemsSource = LSP;
            paramater.MaND.Text = Const.ND.MAND;
            paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
            paramater.Ngay.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        }

        void _Choose(AddImportBookView paramater)
        {
            if (paramater.SP.SelectedItem != null)
            {
                SACH temp = (SACH)paramater.SP.SelectedItem;
                paramater.DG.Text = String.Format("{0:#,###} VNĐ", ((int)(float)temp.TRIGIA * 5 / 6));
            }
            else
            {
                paramater.DG.Text = "";
            }
        }

        void _AddSP(AddImportBookView paramater)
        {
            if (paramater.MaPN.Text == "")
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã phiếu nhập!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (PHIEUNHAP s in DataProvider.Ins.DB.PHIEUNHAPs)
            {
                if (int.Parse(paramater.MaPN.Text) == s.MAPN)
                {
                    System.Windows.MessageBox.Show("Mã phiếu nhập đã tồn tại !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {
                if (int.Parse(paramater.SL.Text) < 10)
                {
                    System.Windows.MessageBox.Show("Số lượng nhập không được nhỏ hơn 10!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Số lượng nhập không hợp lệ!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SACH a = (SACH)paramater.SP.SelectedItem;
            foreach (Display1 display in paramater.ListViewSP.Items)
            {
                if (display.MASACH == a.MASACH)
                {
                    display.SL += int.Parse(paramater.SL.Text);
                    display.TIENNHAP = display.SL * (int)(a.TRIGIA * 5 / 6);
                    foreach (CTPN ct in LCTPN)
                    {
                        if (ct.MASACH == display.MASACH)
                            ct.SL = display.SL;
                    }
                    goto There;
                }
            }
            Display1 b = new Display1(a.MASACH, a.TENSACH, (int)((float)a.TRIGIA * 5 / 6), int.Parse(paramater.SL.Text), (int)((float)(int.Parse(paramater.SL.Text) * a.TRIGIA) * 5 / 6));
            CTPN ctpn = new CTPN()
            {
                MASACH = a.MASACH,
                SL = int.Parse(paramater.SL.Text),
                SACH = a,
                MAPN = int.Parse(paramater.MaPN.Text),
            };
            LCTPN.Add(ctpn);
            LHT.Add(b);
        There:
            tongtien += int.Parse(paramater.SL.Text) * (int)(a.TRIGIA * 5 / 6);
            paramater.ListViewSP.ItemsSource = LHT;
            paramater.ListViewSP.Items.Refresh();
            paramater.SP.ItemsSource = LSP;
            paramater.SP.Items.Refresh();
            paramater.SP.SelectedItem = null;
            paramater.SL.Text = "";
            paramater.TT.Text = tongtien.ToString("#,### VNĐ");
        }

        void _DeleteSP(AddImportBookView paramater)
        {
            if (paramater.ListViewSP.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sách !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sách.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                Display1 a = (Display1)paramater.ListViewSP.SelectedItem;
                tongtien -= a.TIENNHAP;
                paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                LHT.Remove(a);
                foreach (SACH b in LSPSelected)
                {
                    if (b.MASACH == a.MASACH)
                    {
                        LSPSelected.Remove(b);
                        break;
                    }
                }
                foreach (CTPN b in LCTPN)
                {
                    if (b.MASACH == a.MASACH && b.SL == a.SL)
                    {
                        LCTPN.Remove(b);
                        break;
                    }
                }
                paramater.ListViewSP.Items.Refresh();
            }
            else
                return;
        }
        void _SavePN(AddImportBookView paramater)
        {
            if (paramater.ListViewSP.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("Thông tin phiếu nhập chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("Xác nhận sách?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                PHIEUNHAP temp = new PHIEUNHAP()
                {
                    MAPN = int.Parse(paramater.MaPN.Text),
                    MAND = Const.ND.MAND,
                    TGNHAP = DateTime.Now,
                    CTPNs = new ObservableCollection<CTPN>(LCTPN),
                };
                foreach (CTPN s in LCTPN)
                {
                    foreach (SACH x in DataProvider.Ins.DB.SACHes)
                    {
                        if (x.MASACH == s.SACH.MASACH)
                        {
                            x.TONGSL += s.SL;
                        }
                    }
                }
                DataProvider.Ins.DB.PHIEUNHAPs.Add(temp);
                DataProvider.Ins.DB.SaveChanges();
                System.Windows.MessageBox.Show("Nhập hàng thành công", "THÔNG BÁO");
                LHT = new ObservableCollection<Display1>();
                paramater.MaPN.Clear();
                LCTPN = new ObservableCollection<CTPN>();
                paramater.ListViewSP.ItemsSource = LHT;
                LSP = DataProvider.Ins.DB.SACHes.Where(p => p.TONGSL >= 0).ToList();
                paramater.SP.Items.Refresh();
                ImportBookView importView = new ImportBookView();
                importView.ListViewPN.ItemsSource = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
                MainViewModel.MainFrame.Content = importView;
            }
            else
                return;
        }

    }
}
