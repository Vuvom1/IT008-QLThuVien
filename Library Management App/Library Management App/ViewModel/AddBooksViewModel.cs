using Library_Management_App.Model;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using Library_Management_App.View;

namespace Library_Management_App.ViewModel
{
    internal class AddBooksViewModel:BaseViewModel
    {
        private string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        public ICommand AddImage { get; set; }
        private string _linkimage;
        public string linkimage { get => _linkimage; set { _linkimage = value; OnPropertyChanged(); } }
        public ICommand AddBookCM { get; set; }
        public ICommand LoadCM { get; set; }
        public AddBooksViewModel()
        {
            linkimage = "/Resource/Image/add.png";
            AddImage = new RelayCommand<Image>((p) => true, (p) => _AddImage(p));
            AddBookCM = new RelayCommand<AddBooksView>((p) => true, (p) => _AddBookCM(p));
            LoadCM = new RelayCommand<AddBooksView>((p)=>true,(p) => _LoadCM(p));
        }

        void _LoadCM(AddBooksView addBooksView)
        {
            linkimage = "/Resource/Image/add.png";
        }

        void _AddImage(Image image)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                linkimage = open.FileName;
            };
            if (linkimage == "/Resource/Image/add.png")
            {
                Uri fileUri = new Uri(linkimage, UriKind.Relative);
                image.Source = new BitmapImage(fileUri);
            }
            else
            {
                Uri fileUri = new Uri(linkimage);
                image.Source = new BitmapImage(fileUri);
            }
        }

        void _AddBookCM(AddBooksView addBooksView) 
        {
            if (string.IsNullOrEmpty(addBooksView.MaSach.Text) || string.IsNullOrEmpty(addBooksView.TenSach.Text) || string.IsNullOrEmpty(addBooksView.LoaiSach.Text) || string.IsNullOrEmpty(addBooksView.GiaSach.Text) || string.IsNullOrEmpty(addBooksView.NXB.Text) || string.IsNullOrEmpty(addBooksView.SlSach.Text) || string.IsNullOrEmpty(addBooksView.Namxuatban.Text) || linkimage == "/Resource/Image/add.png")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn thêm sản phẩm mới ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (h == MessageBoxResult.Yes)
                {
                    if (DataProvider.Ins.DB.SACHes.Where(p => p.MASACH == addBooksView.MaSach.Text).Count() > 0)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại.", "Thông Báo");
                    }
                    else
                    {
                        SACH a = new SACH();
                        a.MASACH = addBooksView.MaSach.Text;
                        a.TENSACH = addBooksView.TenSach.Text;
                        try
                        {
                            a.TRIGIA = int.Parse(addBooksView.GiaSach.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Giá sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (int.Parse(addBooksView.GiaSach.Text) < 0)
                        {
                            MessageBox.Show("Giá sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        string tentheloai = addBooksView.LoaiSach.Text;
                        int matheloai = DataProvider.Ins.DB.THELOAIs.Where(p => p.TENTL == tentheloai).Select(p => p.MATL).FirstOrDefault();
                        a.MATL = matheloai;

                        string tenNXB = addBooksView.NXB.Text;
                        int maNXB = DataProvider.Ins.DB.NHAXUATBANs.Where(p => p.TENNXB == tenNXB).Select(p => p.MANXB).FirstOrDefault();
                        a.MANXB = maNXB;

                        try
                        {
                            a.TONGSL = int.Parse(addBooksView.SlSach.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (a.TONGSL < 0)
                        {
                            MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        a.NAMXUATBAN = int.Parse(addBooksView.Namxuatban.Text.ToString());
                        a.MOTA = addBooksView.MotaSach.Text;
                        a.IMAGESACH = "/Resource/ImageBooks/" + "book_" + addBooksView.MaSach.Text + ((linkimage.Contains(".jpg")) ? ".jpg" : ".png").ToString();
                        try
                        {
                            File.Copy(linkimage, _localLink + @"Resource\ImageBooks\" + "book_" + addBooksView.MaSach.Text + ((linkimage.Contains(".jpg")) ? ".jpg" : ".png").ToString(), true);
                        }
                        catch { }
                        MessageBox.Show("Thêm sản phẩm mới thành công !", "THÔNG BÁO");
                        DataProvider.Ins.DB.SACHes.Add(a);
                        DataProvider.Ins.DB.SaveChanges();
                        addBooksView.TenSach.Clear();
                        //addBooksView..SelectedItem = null;
                        addBooksView.GiaSach.Clear();
                        addBooksView.SlSach.Clear();
                        addBooksView.NXB.SelectedItem = null;
                        BooksView booksView = new BooksView();
                        booksView.ListViewBooks.ItemsSource = new ObservableCollection<SACH>(DataProvider.Ins.DB.SACHes.Where(p => p.TONGSL >= 0));
                        MainViewModel.MainFrame.Content = booksView;
                    }
                }
            }
        }
    }
}
