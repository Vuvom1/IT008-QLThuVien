using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

namespace Library_Management_App.ViewModel
{
    public class AddReadersViewModel:BaseViewModel
    {
        public ICommand AddAddReadersCM { get; set; }
        public AddReadersViewModel()
        {
            AddAddReadersCM = new RelayCommand<AddReadersView>((p) => true, (p) => _AddAddReadersCM(p));

        }
        bool check(string m)
        {
            foreach (DOCGIA temp in DataProvider.Ins.DB.DOCGIAs)
            {
                if (temp.MADG == m)
                    return true;
            }
            return false;
        }
        string rdma()
        {
            string ma;
            do
            {
                Random rand = new Random();
                ma = "DG" + rand.Next(0, 10000).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddAddReadersCM(AddReadersView paramater)
        {
            if (paramater.Tendg.Text == "" || paramater.SDTdg.Text == "" || paramater.Ngaysinhdg.SelectedDate == null || paramater.DCdg.Text == ""  || paramater.emaildg.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn thêm khách hàng ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(paramater.Madg.Text) || string.IsNullOrEmpty(paramater.Tendg.Text) || string.IsNullOrEmpty(paramater.SDTdg.Text) || string.IsNullOrEmpty(paramater.Ngaysinhdg.Text) || string.IsNullOrEmpty(paramater.DCdg.Text) || string.IsNullOrEmpty(paramater.emaildg.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO");
                }
                else
                {
                    if (DataProvider.Ins.DB.DOCGIAs.Where(p => p.MADG == paramater.Madg.Text).Count() > 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại !", "THÔNG BÁO");
                    }
                    else
                    {
                        DOCGIA temp = new DOCGIA();
                        temp.MADG = paramater.Madg.Text.ToString();
                        temp.TENDG = paramater.Tendg.Text.ToString();
                        temp.SDT = paramater.SDTdg.Text.ToString();
                        temp.DCHI = paramater.DCdg.Text.ToString();
                        temp.NGSINH = (DateTime)paramater.Ngaysinhdg.SelectedDate;
                        temp.EMAIL = paramater.emaildg.Text.ToString();
                        DataProvider.Ins.DB.DOCGIAs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thêm khách hàng thành công.", "THÔNG BÁO");
                        paramater.Madg.Text = rdma();
                        paramater.Tendg.Clear();
                        paramater.SDTdg.Clear();
                        paramater.emaildg.Clear();
                        paramater.DCdg.Clear();
                        ReadersView readersView = new ReadersView();
                        readersView.ListViewDG.ItemsSource = new ObservableCollection<DOCGIA>(DataProvider.Ins.DB.DOCGIAs);
                        MainViewModel.MainFrame.Content = readersView;
                    }
                }
            }
        }
    }
}
