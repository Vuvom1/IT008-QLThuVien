using Library_Management_App.Model;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{

    public class Display1
    {
        public string MASACH { get; set; }
        public string TENSACH { get; set; }
        public int SL { get; set; }
        public int THANHTIEN { get; set; }
        public Display1(string MaSach = "", string TenSach = "",  int SL = 0, int Thanhtien = 0)
        {
            this.MASACH = MaSach;
            this.TENSACH = TenSach;
            this.SL = SL;
            this.THANHTIEN = Thanhtien;
        }

    }
    public class AddImportBookViewModel:BaseViewModel
    {
        private List<SACH> _LSach;
        public List<SACH> LSach { get => _LSach; set { _LSach = value; OnPropertyChanged(); } }
        private ObservableCollection<Display1> _LHT;
        public ObservableCollection<Display1> LHT { get => _LHT; set { _LHT = value; OnPropertyChanged(); } }
        private ObservableCollection<SACH> _LSPSelected;
        public ObservableCollection<SACH> LSachSelected { get => _LSPSelected; set { _LSPSelected = value; OnPropertyChanged(); } }
        private ObservableCollection<CTPN> _LCTPN;
        public ObservableCollection<CTPN> LCTPN { get => _LCTPN; set { _LCTPN = value; OnPropertyChanged(); } }
        public ICommand LoadImportCM { get; set; }
        public ICommand AddImportCM { get; set; }
        public ICommand DeleteSach { get; set; }
        public ICommand SavePN { get; set; }
        public ICommand Choose { get; set; }
        public int tongtien { get; set; }

        public AddImportBookViewModel()
        {
            tongtien = 0;
            LSachSelected = new ObservableCollection<SACH>();
            LHT = new ObservableCollection<Display1>();
            LCTPN = new ObservableCollection<CTPN>();
            Choose = new RelayCommand<AddImportBookView>((p) => true, (p) => _Choose(p));
            LoadImportCM = new RelayCommand<AddImportBookView>((p) => true, (p) => _LoadImportCM(p));
            AddImportCM = new RelayCommand<AddImportBookView>((p) => true, (p) => _AddImportCM(p));
            DeleteSach = new RelayCommand<AddImportBookView>((p) => true, (p) => _DeleteSach(p));
            SavePN = new RelayCommand<AddImportBookView>((p) => true, (p) => _SavePN(p));
        }

        void _LoadImportCM(AddImportBookView paramater)
        {
            LSach = DataProvider.Ins.DB.SACHes.Where(p => p.SLCONLAI >= 0).ToList();
            paramater.MaND.Text = Const.ND.MAND;
            paramater.TenND.Text = Const.ND.TENND;
            paramater.NGAY.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";

        }

        void _Choose(AddImportBookView paramater)
        {
            if (paramater.LSach.SelectedItem != null)
            {
                SACH temp = (SACH)paramater.LSach.SelectedItem;
                paramater.DG.Text = String.Format("{0:#,###} VNĐ", ((int)(float)temp.TRIGIA * 5 / 6));
            }
            else
            {
                paramater.DG.Text = "";
            }
        }

        void _AddImportCM(AddImportBookView paramater)
        {
            if (paramater.MaPN.Text == "")
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã phiếu nhập!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (paramater.LSach.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm để thêm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
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
            SACH a = (SACH)paramater.LSach.SelectedItem;
            foreach (Display1 display in paramater.ListViewSach.Items)
            {
                if (display.MASACH == a.MASACH)
                {
                    display.SL += int.Parse(paramater.SL.Text);
                    display.THANHTIEN = display.SL * (int)(a.TRIGIA * 5 / 6);
                    foreach (CTPN ct in LCTPN)
                    {
                        if (ct.MASACH == display.MASACH)
                            ct.SL = display.SL;
                    }
                    goto There;
                }
            }
            Display1 b = new Display1(a.MASACH, a.TENSACH, int.Parse(paramater.SL.Text), (int)((float)(int.Parse(paramater.SL.Text) * a.TRIGIA) * 5 / 6));
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
            paramater.ListViewSach.ItemsSource = LHT;
            paramater.ListViewSach.Items.Refresh();
            paramater.LSach.ItemsSource = LSach;
            paramater.LSach.Items.Refresh();
            paramater.LSach.SelectedItem = null;
            paramater.SL.Text = "";
            paramater.TT.Text = tongtien.ToString("#,### VNĐ");
        }

        void _DeleteSach(AddImportBookView paramater)
        {
            if (paramater.ListViewSach.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sách !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sách.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                Display1 a = (Display1)paramater.ListViewSach.SelectedItem;
                tongtien -= a.THANHTIEN;
                paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                LHT.Remove(a);
                foreach (SACH b in LSachSelected)
                {
                    if (b.MASACH == a.MASACH)
                    {
                        LSachSelected.Remove(b);
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
                paramater.LSach.ItemsSource = LSach;
                paramater.LSach.Items.Refresh();
                paramater.ListViewSach.Items.Refresh();
            }
            else
                return;
        }
        void _SavePN(AddImportBookView paramater)
        {
            if (paramater.ListViewSach.Items.Count == 0)
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
                System.Windows.MessageBox.Show("Nhập sách thành công", "THÔNG BÁO");
                LHT = new ObservableCollection<Display1>();
                paramater.MaPN.Clear();
                LCTPN = new ObservableCollection<CTPN>();
                paramater.ListViewSach.ItemsSource = LHT;
                paramater.TT.Text = String.Format("{0:0,0}", tongtien) + " VND";
                LSach = DataProvider.Ins.DB.SACHes.Where(p => p.SLCONLAI >= 0).ToList();
                paramater.LSach.Items.Refresh();
                ImportBookView importView = new ImportBookView();
                importView.ListViewPN.ItemsSource = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
                MainViewModel.MainFrame.Content = importView;
            }
            else
                return;
        }

    }
}
