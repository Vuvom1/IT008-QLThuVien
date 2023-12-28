using Library_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Library_Management_App.View;

namespace Library_Management_App.ViewModel
{

    public class Display
    {
        private string tENTL;
        private string tENNXB;
        private int? tRIGIA;

        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string NXB { get; set; }

        public int GiaTri { get; set; }

        public Display(string MaSach = "", string TenSach = "", string TheLoai = "", string NXB = "", int GiaTri = 0)
        {
            this.MaSach = MaSach;
            this.TenSach = TenSach;
            this.TheLoai = TheLoai;
            this.NXB = NXB;
            this.GiaTri = GiaTri;
        }

        public Display(string mASACH, string tENSACH, string tENTL, string tENNXB, int? tRIGIA)
        {
            MaSach = mASACH;
            TenSach = tENSACH;
            this.tENTL = tENTL;
            this.tENNXB = tENNXB;
            this.tRIGIA = tRIGIA;
        }
    }
    public class AddBorrowViewModel : BaseViewModel
    {
        public ICommand Loadwd { get; set; }
        public ICommand Choose { get; set; }

        private List<DOCGIA> _LDG;

        public List<DOCGIA> LDG { get => _LDG; set { _LDG = value; OnPropertyChanged(); } }
        private List<SACH> _LSach;
        public List<SACH> LSach { get => _LSach; set { _LSach = value; OnPropertyChanged(); } }

        private ObservableCollection<Display> _LDisplay;
        public ObservableCollection<Display> LDisplay { get => _LDisplay; set { _LDisplay = value; OnPropertyChanged(); } }
        private ObservableCollection<SACH> _LSachSelected;
        //public ObservableCollection<string> LDG { get; set; }
        public ObservableCollection<SACH> LSachSelected { get => _LSachSelected; set { _LSachSelected = value; OnPropertyChanged(); } }
        private ObservableCollection<CTPM> _LCTPM;
        public ObservableCollection<CTPM> LCTPM { get => _LCTPM; set { _LCTPM = value; OnPropertyChanged(); } }
        public ICommand AddSach { get; set; }
        public ICommand DeleteSach { get; set; }
        public ICommand PrintSach { get; set; }
        public ICommand SavePM { get; set; }
        public ICommand chooseDG { get; set; }


        public ICommand chooseSach { get; set; }
        public int tongSoLuong { get; set; }
        public int tongTien { get; set; }
        public AddBorrowViewModel()
        {
            tongTien = 0;
            LSachSelected = new ObservableCollection<SACH>();
            //LDG = new ObservableCollection<string>() { "1", "2", "3", "4", "5" };
            LDisplay = new ObservableCollection<Display>();

            LCTPM = new ObservableCollection<CTPM>();

            Loadwd = new RelayCommand<AddBorrowView>((p) => true, (p) => _Loadwd(p));

            chooseSach = new RelayCommand<AddBorrowView>((p) => true, (p) => _chooseSach(p));

            chooseDG = new RelayCommand<AddBorrowView>((p) => true, (p) => _chooseDG(p));
            AddSach = new RelayCommand<AddBorrowView>((p) => true, (p) => _AddSach(p));
            DeleteSach = new RelayCommand<AddBorrowView>((p) => true, (p) => _DeleteSach(p));
            //PrintSach = new RelayCommand<AddBorrowView>((p) => true, (p) => print(p));
            SavePM = new RelayCommand<AddBorrowView>((p) => true, (p) => _SavePM(p));
        }

        void _Loadwd(AddBorrowView paramater)
        {
            LDG = DataProvider.Ins.DB.DOCGIAs.ToList();
            LSach = DataProvider.Ins.DB.SACHes.Where(p => p.SLCONLAI >= 0).ToList();
            paramater.LDG.ItemsSource = LDG;
            paramater.MaND.Text = Const.ND.MAND;
            paramater.TenND.Text = Const.ND.TENND;
            paramater.Ngay.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

            paramater.TT.Text = String.Format("{0:0,0}", tongSoLuong) + " quyển";
            paramater.TT1.Text = String.Format("{0:0,0}", tongTien) + " VND";
        }
        void _chooseDG(AddBorrowView parameter)
        {
            DOCGIA temp = (DOCGIA)parameter.LDG.SelectedItem;
        }
        void _chooseSach(AddBorrowView paramater)
        {
            if (paramater.LSach.SelectedItem != null)
            {
                SACH temp = (SACH)paramater.LSach.SelectedItem;
                //paramater.TT.Text = String.Format("{0:0,0}", tongSoLuong) + " quyển"; ;
                //paramater.TT1.Text = String.Format("{0:0,0}", tongTien) + " VND";
            }
            else
            {
                //paramater.TT.Text = "";
                //paramater.TT1.Text = "";
            }
        }
        void _AddSach(AddBorrowView paramater)
        {
            if (paramater.LSach.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm để thêm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (paramater.MaPM.Text == "")
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã phiếu mượn !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (paramater.LDG.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn độc giả !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SACH a = (SACH)paramater.LSach.SelectedItem;
            if (a.SLCONLAI > 0)
            {
                bool isAdded = false;
                foreach (Display temp in LDisplay)
                {
                    if (temp.MaSach == a.MASACH)
                    {
                        foreach (CTPM temp1 in LCTPM)
                        {
                            if (temp1.MASACH == a.MASACH)
                            {
                                MessageBox.Show("Mỗi quyển sách chỉ được mượn một lần");
                                isAdded = true;
                            } 
                        }
                        //tongSoLuong = tongSoLuong + 1;
                        //tongTien = (int)(int.Parse(paramater.TT1.Text) + a.TRIGIA);
                        //paramater.TT.Text = String.Format("{0:0,0}", tongSoLuong) + " VND";
                        //paramater.TT1.Text = String.Format("{0:0,0}", tongTien) + " VND";
                        //paramater.ListViewSach.ItemsSource = LDisplay;
                        //paramater.ListViewSach.Items.Refresh();
                        //paramater.LSach.SelectedItem = null;
                        //return;
                    }
                }

                if (!isAdded)
                {
                    Display b = new Display(a.MASACH, a.TENSACH, a.THELOAI.TENTL, a.NHAXUATBAN.TENNXB, (int)a.TRIGIA);
                    CTPM ctpm = new CTPM()
                    {
                        MASACH = a.MASACH,
                        SACH = a,
                        MAPM = int.Parse(paramater.MaPM.Text),
                    };
                    tongSoLuong += 1;
                    tongTien += a.TRIGIA.Value;
                    paramater.TT.Text = String.Format("{0:0,0}", tongSoLuong) + " quyển";
                    paramater.TT1.Text = String.Format("{0:0,0}", tongTien) + " VND";
                    LCTPM.Add(ctpm);
                    LDisplay.Add(b);
                    paramater.ListViewSach.ItemsSource = LDisplay;
                    paramater.ListViewSach.Items.Refresh();
                    paramater.LSach.SelectedItem = null;
                    paramater.LSach.Text = "";
                }
                
            }
            else
                System.Windows.MessageBox.Show("Sách tồn kho không đủ cung cấp !", "THÔNG BÁO");
        }
        void _DeleteSach(AddBorrowView paramater)
        {
            if (paramater.ListViewSach.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sách để xóa !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sách.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                Display a = (Display)paramater.ListViewSach.SelectedItem;
                tongTien -= a.GiaTri;
                tongSoLuong -= 1;
                paramater.TT.Text = String.Format("{0:0,0}", tongSoLuong) + " quyển";
                paramater.TT1.Text = String.Format("{0:0,0}", tongTien) + " VND";
                LDisplay.Remove(a);
                foreach (CTPM b in LCTPM)
                {
                    if (b.MASACH == a.MaSach)
                    {
                        LCTPM.Remove(b);
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
        bool check(int m)
        {
            foreach (PHIEUMUON temp in DataProvider.Ins.DB.PHIEUMUONs)
            {
                if (temp.MAPM == m)
                    return true;
            }
            return false;
        }
        int rdma()
        {
            int ma;
            do
            {
                Random rand = new Random();
                ma = rand.Next(0, 10000);
            } while (check(ma));
            return ma;
        }
        void _SavePM(AddBorrowView paramater)
        {
            DataProvider.Ins.DB.SaveChangesAsync();
            if (paramater.LDG.SelectedItem == null || paramater.ListViewSach.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("Thông tin phiếu mượn chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("Xác nhận ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                DOCGIA a = (DOCGIA)paramater.LDG.SelectedItem;

                int sl = 0;
                int tonggia = 0;
                foreach (Display b in LDisplay)
                {
                    sl = sl + 1;
                    tonggia += b.GiaTri;
                }

                PHIEUMUON temp = new PHIEUMUON()
                {
                    MAPM = int.Parse(paramater.MaPM.Text),
                    MADG = a.MADG,
                    MAND = Const.ND.MAND,
                    TGMUON = DateTime.Now,
                    CTPMs = new ObservableCollection<CTPM>(LCTPM),
                    DOCGIA = a,
                    //NGUOIDUNG = Const.ND,
                    SL = sl,
                    TRIGIA = tonggia,
                    TGTRA = null,
                    TRANGTHAI = "Chưa trả",
                    TIENPHAT = 0,
                };
                foreach (CTPM s in LCTPM)
                {
                    foreach (SACH x in DataProvider.Ins.DB.SACHes)
                    {
                        if (x.MASACH == s.SACH.MASACH)
                        {
                            x.SLCONLAI -= 1;
                        }
                    }
                }
                DataProvider.Ins.DB.PHIEUMUONs.Add(temp);
                DataProvider.Ins.DB.SaveChanges();
                ////MessageBoxResult d = System.Windows.MessageBox.Show("  Bạn có muốn in hóa đơn ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                ////if (d == MessageBoxResult.Yes)
                ////{
                ////    print(paramater);
                ////}

                tongSoLuong = 0;
                tongTien = 0;
                LSachSelected.Clear();
                paramater.LDG.SelectedItem = null;
                LDisplay.Clear();
                LCTPM.Clear();
                paramater.ListViewSach.ItemsSource = LDisplay;
                paramater.TT.Text = String.Format("{0:0,0}", tongSoLuong) + " quyển";
                paramater.TT1.Text = String.Format("{0:0,0}", tongTien) + " VND";
                paramater.MaPM.Text = rdma().ToString();
                MessageBox.Show("Thêm phiếu mượn thành công !", "THÔNG BÁO");
                BorrowView borrowView = new BorrowView();
                borrowView.ListViewPM.ItemsSource = new ObservableCollection<PHIEUMUON>(DataProvider.Ins.DB.PHIEUMUONs);
                MainViewModel.MainFrame.Content = borrowView;
            }
            else
                return;
        }
    }

}
