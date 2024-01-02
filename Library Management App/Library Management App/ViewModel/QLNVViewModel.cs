using Library_Management_App.Model;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Library_Management_App.ViewModel
{
    public class QLNVViewModel:BaseViewModel
    {
        public ICommand LoadQLNVCM {  get; set; }
        public ICommand SearchQLNVCM { get; set; }
        public ICommand AddQLNVCM { get; set; }
        public ICommand DetailQLNVCM { get; set; }

        private ObservableCollection<NGUOIDUNG> _ListQLNV;
        public ObservableCollection<NGUOIDUNG> ListQLNV { get => _ListQLNV; set { _ListQLNV = value; /*OnPropertyChanged();*/ } }
        private ObservableCollection<string> _listTKQLNV;
        public ObservableCollection<string> listTKQLNV { get => _listTKQLNV; set { _listTKQLNV = value; OnPropertyChanged(); } }

        public QLNVViewModel() 
        {
            listTKQLNV = new ObservableCollection<string>() {"Mã nhân viên","Tên nhân viên", "Số điện thoại" };
            ListQLNV = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => (p.MAROLE == 1 && p.TTND == true)));
            SearchQLNVCM = new RelayCommand<QLNVView>((p) => true, (p) => _SearchQLNVCM(p));
            LoadQLNVCM = new RelayCommand<QLNVView>((p) => true, (p) => _LoadQLNVCM(p));
            DetailQLNVCM = new RelayCommand<QLNVView>((p) => { return p.ListViewQLNV.SelectedItem == null ? false : true; }, (p) => _DetailQLNVCM(p));
        }

        public void _LoadQLNVCM(QLNVView qlnvview)
        {
            qlnvview.cbxChon.SelectedIndex = 0;
            ListQLNV = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => (p.MAROLE == 1 && p.TTND == true)));
        }

       

        public void _SearchQLNVCM(QLNVView qlnvview)
        {
            ObservableCollection<NGUOIDUNG> temp = new ObservableCollection<NGUOIDUNG>();
            if (qlnvview.txbSearch.Text != "")
            {
                switch (qlnvview.cbxChon.SelectedItem.ToString())
                {
                    case "Mã nhân viên":
                        {
                            foreach (NGUOIDUNG s in ListQLNV)
                            {
                                if (s.MAND.Contains(qlnvview.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Tên nhân viên":
                        {
                            foreach (NGUOIDUNG s in ListQLNV)
                            {
                                if (s.TENND.ToLower().Contains(qlnvview.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Số điện thoại":
                        {
                            foreach (NGUOIDUNG s in ListQLNV)
                            {
                                if (s.SDT.Contains(qlnvview.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            foreach (NGUOIDUNG s in ListQLNV)
                            {
                                if (s.TENND.Contains(qlnvview.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                qlnvview.ListViewQLNV.ItemsSource = temp;
            }
            else
                qlnvview.ListViewQLNV.ItemsSource = ListQLNV;
        }



        public void _DetailQLNVCM(QLNVView qlnvview)
        {
            DetailQLNV detailQLNV = new DetailQLNV();
            NGUOIDUNG temp = (NGUOIDUNG)qlnvview.ListViewQLNV.SelectedItem;
            detailQLNV.MaNV.Text = temp.MAND;
            detailQLNV.TenNV.Text = temp.TENND;
            detailQLNV.SDTNV.Text = temp.SDT;
            detailQLNV.gioitinhNV.Text = temp.GIOITINH;
            detailQLNV.NgaySinhNV.SelectedDate = (DateTime)temp.NGSINH;
            detailQLNV.eMAILNV.Text = temp.MAIL;
            detailQLNV.DCNV.Text = temp.DIACHI;
            ListQLNV = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => (p.MAROLE == 1 && p.TTND == true)));
            qlnvview.ListViewQLNV.ItemsSource = ListQLNV;
            qlnvview.ListViewQLNV.SelectedItem = null;
            MainViewModel.MainFrame.Content = detailQLNV;
        }
    }
}
