using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Library_Management_App.Model;
using System.Data.Common;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Runtime.Remoting.Contexts;

namespace Library_Management_App.ViewModel
{
    public class BooksViewModel: BaseViewModel
    {
        private string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        private ObservableCollection<SACH> _ListBook;
        public ObservableCollection<SACH> ListBook { get => _ListBook; set => _ListBook = value; }
        private ObservableCollection<SACH> _ListBookFilter;
        public ObservableCollection<SACH> ListBookFilter { get => _ListBookFilter; set => _ListBookFilter = value; }
        public ObservableCollection<string> ListTK { get => _ListTK; set { _ListTK = value; OnPropertyChanged(); } }
        private ObservableCollection<string> _ListTK;
        public ICommand AddBookCommand { get; set; }
        public ICommand DetailBooksCommand { get; set; }
        public ICommand LoadBooksCommand { get; set; }
        public ICommand FilterBooksCommand { get; set; }
        public ICommand SearchBooksCommand { get; set; }

        public BooksViewModel() 
        {
            ListTK = new ObservableCollection<string>() {"Tên sách","Giá sách" };
            ListBook = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACHes.Where(p => p.SLCONLAI >= 0));
            ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()));
            AddBookCommand = new RelayCommand<BooksView>((p) => { return p == null ? false : true; }, (p) => _AddBookCommand(p));
            SearchBooksCommand = new RelayCommand<BooksView>((p) => { return p == null ? false : true; }, (p) => _SearchBooksCommand(p));
            DetailBooksCommand = new RelayCommand<BooksView>((p) => { return p.ListViewBooks.SelectedItem == null ? false : true; }, (p) => _DetailBooksCommand(p));
            LoadBooksCommand = new RelayCommand<BooksView>((p) => true, (p) => _LoadBooksCommand(p));
            FilterBooksCommand = new RelayCommand<BooksView>((p) => true, (p) => _FilterBooksCommand(p));
        }

        void _LoadBooksCommand(BooksView booksView) 
        {
            ListTK = new ObservableCollection<string>() { "Tên sách", "Giá sách" };
            ListBook = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACHes.Where(p => p.SLCONLAI >= 0));
            ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()));
            booksView.cbxBoLoc.SelectedIndex = 0;
            booksView.cbxTimKiem.SelectedIndex = 0;
        }

        void _AddBookCommand(BooksView booksView)
        {
            AddBooksView addBooksView = new AddBooksView();
            MainViewModel.MainFrame.Content = addBooksView;
        }
        void _DetailBooksCommand(BooksView booksView)
        {
            DetailBookView detailBookView = new DetailBookView();
            SACH temp = (SACH)booksView.ListViewBooks.SelectedItem;
            detailBookView.TenSach.Text = temp.TENSACH;
            detailBookView.GiaSach.Text = string.Format("{0:0,0}", temp.TRIGIA) + " VNĐ";
            int sotheloai = int.Parse(ListBook.Where(p => p.TENSACH == temp.TENSACH).Select(p => p.MATL).Sum().ToString());
            List<THELOAI> theloai = new List<THELOAI>(DataProvider.Ins.DB.THELOAIs);
            string tentheloai = theloai.Where(p => p.MATL == sotheloai).Select(p => p.TENTL).FirstOrDefault();
            detailBookView.LoaiSach.Text = tentheloai;
            string SL = ListBook.Where(p => p.TENSACH == temp.TENSACH && p.TONGSL >= 0).Select(p => p.TONGSL).Sum().ToString();
            detailBookView.SLSach.Text = "Số lượng: " + SL;
            int somaNXB = int.Parse(ListBook.Where(p => p.TENSACH == temp.TENSACH).Select(p => p.MANXB).Sum().ToString());
            List<NHAXUATBAN> NXB = new List<NHAXUATBAN>(DataProvider.Ins.DB.NHAXUATBANs);
            string tenmaNXB = NXB.Where(p => p.MANXB == somaNXB).Select(p => p.TENNXB).FirstOrDefault();
            detailBookView.TenNXB.Text = tenmaNXB;
            detailBookView.Mota.Text = temp.MOTA;
            Uri fileUri = new Uri(temp.IMAGESACH, UriKind.Relative);
            detailBookView.HinhAnhSach.Source = new BitmapImage(fileUri);
            ListBook = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACHes.Where(p => p.SLCONLAI > 0));
            booksView.ListViewBooks.ItemsSource = ListBook;
            booksView.ListViewBooks.SelectedItem = null;
            _FilterBooksCommand(booksView);
            _SearchBooksCommand(booksView);
            MainViewModel.MainFrame.Content = detailBookView;
        }
        void _FilterBooksCommand(BooksView booksView) 
        {
            switch (booksView.cbxBoLoc.SelectedIndex.ToString())
            {
                case "0":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "1":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 1));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "2":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 2));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "3":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 3));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "4":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 4));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "5":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 5));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "6":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 6));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "7":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 7));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
                case "8":
                    {
                        ListBookFilter = new ObservableCollection<SACH>(ListBook.GroupBy(p => p.TENSACH).Select(grp => grp.FirstOrDefault()).Where(p => p.MATL == 8));
                        booksView.ListViewBooks.ItemsSource = ListBookFilter;
                        break;
                    }
            }
        }


        void _SearchBooksCommand(BooksView booksView)
        {
            ObservableCollection<SACH> temp = new ObservableCollection<SACH>();
            if (booksView.cbxTimKiem.Text != "")
            {
                switch (booksView.cbxTimKiem.SelectedItem.ToString())
                {
                    case "Tên sách":
                        {
                            foreach (SACH s in ListBookFilter)
                            {
                                if (s.TENSACH.ToLower().Contains(booksView.tbxSearchBooks.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Giá sách":
                        {
                            try
                            {
                                foreach (SACH s in ListBookFilter)
                                {
                                    if (s.TRIGIA <= int.Parse(booksView.tbxSearchBooks.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }
                            }
                            catch { }
                            break;
                        }
                    default:
                        {
                            foreach (SACH s in ListBookFilter)
                            {
                                if (s.TENSACH.ToLower().Contains(booksView.tbxSearchBooks.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                booksView.ListViewBooks.ItemsSource = temp;
            }
            else
                booksView.ListViewBooks.ItemsSource = ListBookFilter;
        }
    }
}
