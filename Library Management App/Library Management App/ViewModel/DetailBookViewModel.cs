using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xamarin.Forms;

namespace Library_Management_App.ViewModel
{
    internal class DetailBookViewModel:BaseViewModel
    {
        public string tenbook;
        public ICommand back {  get; set; }
        public ICommand UpdateBook { get; set; }
        public ICommand DeleteBook { get; set; }
        public ICommand GetName {  get; set; }
        public ICommand Loadwd { get; set; }

        public DetailBookViewModel() 
        {
            back = new RelayCommand<DetailBookView>((p) => true, (p) => _back(p));
            UpdateBook = new RelayCommand<DetailBookView>((p) => true, (p) => _UpdateBook(p));
            DeleteBook = new RelayCommand<DetailBookView>((p) => true, (p) => _DeleteBook(p));
            GetName = new RelayCommand<DetailBookView>((p) => true, (p) => _GetName(p));
        }

        public void _back(DetailBookView detailBookView)
        {
            BooksView booksView = new BooksView();
            MainViewModel.MainFrame.Content = booksView;
        }

        void _GetName(DetailBookView p)
        {
            tenbook = p.TenSach.Text;
        }
        void _DeleteBook(DetailBookView detailBookView)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa sách ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (SACH a in DataProvider.Ins.DB.SACHes)
                {
                    if(a.TENSACH == tenbook)
                    {
                        a.TONGSL = -1;

                        // delete book

                        break;
                    }
                }


                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa sách thành công !", "THÔNG BÁO");
                BooksView booksView = new BooksView();
                booksView.ListViewBooks.ItemsSource = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACHes.Where(p => p.TONGSL > 0));
                MainViewModel.MainFrame.Content = booksView;
            }
        }
        void _UpdateBook(DetailBookView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn cập nhật sách ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(p.TenSach.Text) || string.IsNullOrEmpty(p.GiaSach.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO");
                }
                else
                {
                    foreach (SACH a in DataProvider.Ins.DB.SACHes.Where(pa => (pa.TENSACH == tenbook && pa.TONGSL >= 0)))
                    {
                        a.TENSACH = p.TenSach.Text;
                        a.MOTA = p.Mota.Text;

                        string formattedString = string.Format("{0:0,0}", p.GiaSach.Text);
                        string numericString = formattedString.Replace(",", "");

                        if (int.TryParse(numericString, out int numericValue))
                        {
                            a.TRIGIA = numericValue;
                        }
                        else
                        {
                            MessageBox.Show("sai format");
                        }
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật sách thành công !", "THÔNG BÁO");
                    BooksView booksView = new BooksView();
                    booksView.ListViewBooks.ItemsSource = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACHes.Where(a => a.TONGSL>0));
                    MainViewModel.MainFrame.Content = booksView;
                }
            }
        }
    }

}
