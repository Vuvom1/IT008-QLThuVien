using Library_Management_App.Model;
using Library_Management_App.ViewModel;
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
    public class DetailReaderViewModel:BaseViewModel
    {
        private string maDG;
        public ICommand GetDG { get; set; }
        public ICommand Update { get; set; }
        public ICommand back { get; set; }
        public DetailReaderViewModel()
        {
            GetDG = new RelayCommand<DetailReaderView>((p) => true, (p) => _GetMADG(p));
            Update = new RelayCommand<DetailReaderView>((p) => true, (p) => _Update(p));
            back = new RelayCommand<DetailReaderView>((p) => true, p => _back(p));
        }
        void _GetMADG(DetailReaderView paramater)
        {
            maDG = paramater.MaDG.Text;
        }
        void _back(DetailReaderView paramater)
        {
            ReadersView readersView = new ReadersView();
            MainViewModel.MainFrame.Content = readersView;
        }
        void _Update(DetailReaderView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn cập nhật thông tin ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(p.TenDG.Text) || string.IsNullOrEmpty(p.SDTDG.Text) || string.IsNullOrEmpty(p.NgaySinhDG.Text) || string.IsNullOrEmpty(p.NgaySinhDG.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var temp = DataProvider.Ins.DB.DOCGIAs.Where(pa => pa.MADG == maDG);
                    foreach (DOCGIA a in temp)
                    {
                        a.TENDG = p.TenDG.Text;
                        a.SDT = p.SDTDG.Text;
                        a.DCHI = p.DCDG.Text;
                        a.EMAIL = p.eMAILDG.Text;
                        a.NGSINH = (DateTime)p.NgaySinhDG.SelectedDate;
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công !", "THÔNG BÁO");
                    ReadersView readerview = new ReadersView();
                    readerview.ListViewDG.ItemsSource = new ObservableCollection<DOCGIA>(DataProvider.Ins.DB.DOCGIAs);
                    MainViewModel.MainFrame.Content = readerview;
                }
            }
        }
    }
}
