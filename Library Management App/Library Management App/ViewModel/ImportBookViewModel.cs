using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Library_Management_App.ViewModel
{


    public class Display1
    {
        public string MASACH { get; set; }
        public string TENSACH { get; set; }
        public int DONGIA { get; set; }
        public int SL { get; set; }
        public int TIENNHAP { get; set; }
        public Display1(string MaSp = "", string TenSP = "", int Dongia = 0, int SL = 0, int Tiennhap = 0)
        {
            this.MASACH = MaSp;
            this.TENSACH = TenSP;
            this.SL = SL;
            this.DONGIA = Dongia;
            this.TIENNHAP = Tiennhap;
        }
    }
    class ImportBookViewModel : BaseViewModel
    {
        private ObservableCollection<PHIEUNHAP> _listPN;
        public ObservableCollection<PHIEUNHAP> listPN { get => _listPN; set { _listPN = value; OnPropertyChanged(); } }
        public ICommand OpenAddImport { get; set; }

        public ICommand SearchCommand { get; set; }

        public ImportBookViewModel()
        {
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            SearchCommand = new RelayCommand<ImportBookView>((p) => true, (p) => _SearchCommand(p));
            OpenAddImport = new RelayCommand<ImportBookView>((p) => true, (p) => _OpenAdd(p));
            
        }


        bool check(int m)
        {
            foreach (CTPN temp in DataProvider.Ins.DB.CTPNs)
            {
                if (temp.MAPN == m)
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
        void _OpenAdd(ImportBookView paramater)
        {
            AddImportBookView addBook = new AddImportBookView();
            addBook.MaPN.Text = rdma().ToString();
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            paramater.ListViewPN.ItemsSource = listPN;
            paramater.ListViewPN.Items.Refresh();
            MainViewModel.MainFrame.Content = addBook;
        }

        void _Detail(ImportBookView p)
        {
            DetailImportBookView detailImport = new DetailImportBookView();
            PHIEUNHAP temp = (PHIEUNHAP)p.ListViewPN.SelectedItem;
            detailImport.MaND.Text = temp.NGUOIDUNG.MAND;
            detailImport.Ngay.Text = temp.TGNHAP.ToString("dd/MM/yyyy hh:mm tt");
            detailImport.MaPN.Text = temp.MAPN.ToString();
            List<Display1> list = new List<Display1>();
            int tong = 0;
            foreach (CTPN a in temp.CTPNs)
            {
                list.Add(new Display1(a.MASACH, a.SACH.TENSACH,  (int)((float)a.SACH.TRIGIA * 5 / 6), a.SL, (int)((float)(a.SL * a.SACH.TRIGIA) * 5 / 6)));
                tong += (int)((float)(a.SL * a.SACH.TRIGIA) * 5 / 6);
            }
            detailImport.ttn.Text = String.Format("{0:0,0}", tong) + " VND";
            detailImport.ListViewSP.ItemsSource = list;
            p.ListViewPN.SelectedItem = null;
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            p.ListViewPN.ItemsSource = listPN;
            _SearchCommand(p);
            MainViewModel.MainFrame.Content = detailImport;
        }

        void _SearchCommand(ImportBookView p)
        {
            ObservableCollection<PHIEUNHAP> temp = new ObservableCollection<PHIEUNHAP>();
            if (p.txbSearch.Text != "")
            {
                foreach (PHIEUNHAP s in listPN)
                {
                    if (s.NGUOIDUNG.TENND.ToLower().Contains(p.txbSearch.Text.ToLower()))
                    {
                        temp.Add(s);
                    }
                }
                p.ListViewPN.ItemsSource = temp;
            }
            else
                p.ListViewPN.ItemsSource = listPN;
        }
    }
}
