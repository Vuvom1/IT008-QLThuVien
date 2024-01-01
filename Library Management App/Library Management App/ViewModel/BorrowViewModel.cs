using Library_Management_App.Model;
using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows;
using System.Data;

namespace Library_Management_App.ViewModel
{
    public class BorrowViewModel : BaseViewModel
    {
        public ICommand OpenAddBorrowCM { get; set; }

        ObservableCollection<PHIEUMUON> _listPM;

        public ObservableCollection<PHIEUMUON> listPM { get => _listPM; set { _listPM = value; OnPropertyChanged(); } }

        public ICommand SearchCM { get; set; }

        public ICommand Detail { get; set; }
        public ICommand LoadCsCommand { get; set; }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }

        public BorrowViewModel()
        {
            listTK = new ObservableCollection<string>() { "Họ tên", "Mã PM", "Ngày" };
            listPM = new ObservableCollection<PHIEUMUON>(DataProvider.Ins.DB.PHIEUMUONs);
            OpenAddBorrowCM = new RelayCommand<BorrowView>((p) => true, (p) => _OpenAdd(p));
            SearchCM = new RelayCommand<BorrowView>((p) => true, (p) => _SearchCommand(p));
            Detail = new RelayCommand<BorrowView>((p) => p.ListViewPM.SelectedItem != null ? true : false, (p) => _Detail(p));
            LoadCsCommand = new RelayCommand<BorrowView>((p) => true, (p) => _LoadCsCommand(p));
            updateStatus();
        }

        private void updateStatus()
        {

            foreach (PHIEUMUON temp in listPM)
            {
                if (temp.TRANGTHAI == "Chưa trả")
                {
                    TimeSpan differenceDate = DateTime.Now - temp.TGMUON.Value;

                    if (differenceDate.TotalDays > 30)
                    {
                        temp.TIENPHAT = temp.TRIGIA * 5;
                    }

                    temp.TRANGTHAI = "Hết hạn";
                }
                
            }

            DataProvider.Ins.DB.SaveChanges();

        }


        void _LoadCsCommand(BorrowView parameter)
        {
            parameter.cbxChon.SelectedIndex = 0;
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

        void _OpenAdd(BorrowView paramater)
        {
            AddBorrowView addBorrow = new AddBorrowView();
            addBorrow.MaPM.Text = rdma().ToString();
            listPM = new ObservableCollection<PHIEUMUON>(DataProvider.Ins.DB.PHIEUMUONs);
            //paramater.ListViewPM.ItemsSource = listPM;
            //paramater.ListViewPM.Items.Refresh();
            MainViewModel.MainFrame.Content = addBorrow;
        }

        void _SearchCommand(BorrowView paramater)
        {
            ObservableCollection<PHIEUMUON> temp = new ObservableCollection<PHIEUMUON>();
            if (paramater.txbSearch.Text != "" && paramater.cbxChon.SelectedItem != null)
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã PM":
                        {
                            try
                            {
                                foreach (PHIEUMUON s in listPM)
                                {
                                    if (s.MAPM == int.Parse(paramater.txbSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }

                            }
                            catch { }
                            break;
                        }
                    case "Họ tên":
                        {
                            foreach (PHIEUMUON s in listPM)
                            {
                                if (s.DOCGIA.TENDG.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Ngày":
                        {
                            foreach (PHIEUMUON s in listPM)
                            {
                                if (s.TGMUON.Value.ToString("dd/MM/yyyy").Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            foreach (PHIEUMUON s in listPM)
                            {
                                if (s.DOCGIA.TENDG.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.ListViewPM.ItemsSource = temp;
            }
            else
                paramater.ListViewPM.ItemsSource = listPM;
        }

        void _Detail(BorrowView parameter)
        {
            BorrowDetailView p = new BorrowDetailView();
            PHIEUMUON temp = (PHIEUMUON)parameter.ListViewPM.SelectedItem;
            p.MaND.Text = temp.NGUOIDUNG.MAND;
            p.TenND.Text = temp.NGUOIDUNG.TENND;
            if (temp.TGMUON.HasValue == true)
            {
                p.Ngay.Text = temp.TGMUON.Value.ToString("dd/MM/yyyy hh:mm tt");

            }
            p.MaPM.Text = temp.MAPM.ToString();
            p.MaDG.Text = temp.MADG.ToString();
            p.TenDG.Text = temp.DOCGIA.TENDG;
            p.TRANGTHAI.Text = temp.TRANGTHAI.ToString();
            List<Display> list = new List<Display>();
            foreach (CTPM a in temp.CTPMs)
            {
                list.Add(new Display(a.MASACH, a.SACH.TENSACH, a.SACH.THELOAI.TENTL, a.SACH.NHAXUATBAN.TENNXB, a.SACH.TRIGIA.Value));
            }
            p.ListViewSach.ItemsSource = list;
            p.GG.Text = Convert.ToString(temp.SL) + " quyển";
            p.TT1.Text = String.Format("{0:0,0}", temp.TRIGIA) + " VND";
            p.TT.Text = String.Format("{0:0,0}", temp.TIENPHAT) + " VND";
            if (temp.TRANGTHAI == "Chưa trả")
            {
                p.completeBtn.Visibility = Visibility.Visible;
            } 
            else if (temp.TRANGTHAI == "Hết hạn")
            {
                p.completeBtn.Visibility = Visibility.Visible;
                p.sendMail.Visibility = Visibility.Visible;
                
            }
            else
            {
                p.sendMail.Visibility = Visibility.Hidden;
                p.completeBtn.Visibility = Visibility.Hidden;
            }
            
            //TimeSpan differenceDate = DateTime.Now - temp.TGMUON.Value;

            //if (differenceDate.TotalDays > 30)
            //{
            //    temp.TIENPHAT = temp.TRIGIA * 5;
            //}

            parameter.ListViewPM.SelectedItem = null;
            listPM = new ObservableCollection<PHIEUMUON>(DataProvider.Ins.DB.PHIEUMUONs);
            parameter.ListViewPM.ItemsSource = listPM;
            _SearchCommand(parameter);
            MainViewModel.MainFrame.Content = p;
        }

    }
}
