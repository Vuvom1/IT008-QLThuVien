using Library_Management_App.Model;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    public class DetailQLNVViewModel:BaseViewModel
    {
        private string manv;
        public ICommand GetNV { get; set; }
        public ICommand Back { get; set; }
        public ICommand Update { get; set; }
        public ICommand Remove { get; set; }
        public DetailQLNVViewModel() 
        {
            Back = new RelayCommand<DetailQLNV>((p) => true, (p) => _Back(p));
            Update = new RelayCommand<DetailQLNV>((p) => true,(p)=> _Update(p));
            GetNV = new RelayCommand<DetailQLNV>((p) => true, (p) => _GetNV(p));
            Remove = new RelayCommand<DetailQLNV>((p) => true, (p) => _Remove(p));
        }

        public void _Back(DetailQLNV detailQLNV)
        {
            QLNVView qLNVView = new QLNVView();
            MainViewModel.MainFrame.Content = qLNVView;
        }

        public void _Remove(DetailQLNV detailQLNV)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa nhân viên ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (NGUOIDUNG a in DataProvider.Ins.DB.NGUOIDUNGs.Where(p => (p.MAROLE == 1 && p.TTND == true)))
                {
                    if (manv == a.MAND)
                    {
                        a.TTND = false;
                        break;
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa nhân viên thành công !", "THÔNG BÁO");
                QLNVView qLNV = new QLNVView();
                qLNV.ListViewQLNV.ItemsSource = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => (p.MAROLE == 1 && p.TTND == true)));
                MainViewModel.MainFrame.Content = qLNV;
            }
        }

        public void _GetNV(DetailQLNV paramater)
        {
            manv = paramater.MaNV.Text;
        }

        public void _Update(DetailQLNV detailQLNV)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn cập nhật thông tin ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(detailQLNV.TenNV.Text) || string.IsNullOrEmpty(detailQLNV.eMAILNV.Text) || string.IsNullOrEmpty(detailQLNV.NgaySinhNV.Text) || string.IsNullOrEmpty(detailQLNV.SDTNV.Text)  || string.IsNullOrEmpty(detailQLNV.gioitinhNV.Text) || string.IsNullOrEmpty(detailQLNV.DCNV.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var temp = DataProvider.Ins.DB.NGUOIDUNGs.Where(pa => pa.MAND == manv);
                    foreach (NGUOIDUNG a in temp)
                    {
                        a.TENND = detailQLNV.TenNV.Text;
                        a.SDT = detailQLNV.SDTNV.Text;
                        a.DIACHI = detailQLNV.DCNV.Text;
                        a.MAIL = detailQLNV.eMAILNV.Text;
                        a.GIOITINH = detailQLNV.gioitinhNV.Text;
                        a.NGSINH = (DateTime)detailQLNV.NgaySinhNV.SelectedDate;
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công !", "THÔNG BÁO");
                    QLNVView qlnvview = new QLNVView();
                    qlnvview.ListViewQLNV.ItemsSource = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p =>( p.MAROLE == 1 &&  p.TTND == true)));
                    MainViewModel.MainFrame.Content = qlnvview;
                }
            }
        }
    }
}
