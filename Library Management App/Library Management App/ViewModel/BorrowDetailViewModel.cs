using Library_Management_App.View;
using Library_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Library_Management_App.ViewModel
{
    public class BorrowDetailViewModel
    {

        public static Frame MainFrame { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand CompleteBorrow { get; set; }
        public ICommand PrintOrderCM { get; set; }

        public BorrowDetailViewModel()
        {
            //PrintOrderCM = new RelayCommand<BorrowDetailView>((p) => true, (p) => _PrintBorrowView(p));
            CompleteBorrow = new RelayCommand<BorrowDetailView>((p) => true, (p) => _CompleteBorrow(p));
        }
        //void _PrintOrderView(DetailsOrder paramater)
        //{

        //    KHACHHANG tempKH = new KHACHHANG();
        //    HOADON tempHD = new HOADON();
        //    foreach (HOADON temp in DataProvider.Ins.DB.HOADONs)
        //    {
        //        if (temp.SOHD == int.Parse(paramater.SoHD.Text))
        //        {
        //            tempHD = temp;
        //            foreach (KHACHHANG kh in DataProvider.Ins.DB.KHACHHANGs)
        //            {
        //                if (temp.MAKH == kh.MAKH)
        //                {
        //                    tempKH = kh;
        //                    break;
        //                }
        //            }
        //            break;
        //        }
        //    }

        //    PrintOrderView printOrderView = new PrintOrderView();
        //    printOrderView.TenKH.Text = tempKH.HOTEN;
        //    printOrderView.sdt.Text = tempKH.SDT;
        //    printOrderView.dc.Text = tempKH.DCHI;
        //    printOrderView.ngay.Text = tempHD.NGHD.ToShortDateString();
        //    printOrderView.sohd.Text = paramater.SoHD.Text;
        //    printOrderView.GG.Text = "- " + String.Format("{0:0,0}", (tempHD.TRIGIA * 100 / (100 - tempHD.KHUYENMAI)) * tempHD.KHUYENMAI / 100) + " VND";
        //    printOrderView.TT1.Text = String.Format("{0:0,0}", tempHD.TRIGIA) + " VND";
        //    printOrderView.TT.Text = String.Format("{0:0,0}", tempHD.TRIGIA) + " VND";
        //    List<HienThi> list = new List<HienThi>();
        //    foreach (CTHD a in tempHD.CTHDs)
        //    {
        //        list.Add(new HienThi(a.MASP, a.SANPHAM.TENSP, a.SANPHAM.SIZE, a.SL, a.SANPHAM.GIA, a.SL * a.SANPHAM.GIA));
        //    }
        //    printOrderView.ListSP.ItemsSource = list;
        //    MainViewModel.MainFrame.Content = printOrderView;
        //}
        void _CompleteBorrow(BorrowDetailView parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Xác nhận?", "THÔNG BÁO", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (PHIEUMUON temp in DataProvider.Ins.DB.PHIEUMUONs)
                {
                    if (temp.MAPM == int.Parse(parameter.MaPM.Text))
                    {
                        foreach (CTPM temp1 in temp.CTPMs)
                        {
                            foreach (SACH temp2 in DataProvider.Ins.DB.SACHes)
                            {
                                if (temp1.MASACH == temp2.MASACH)
                                {
                                    if (temp2.SLCONLAI == -1)
                                        temp2.SLCONLAI += 1;
                                    else if (temp2.SLCONLAI >= 0)
                                        temp2.SLCONLAI += 1;
                                }
                            }
                        }

                        temp.TRANGTHAI = "Đã trả";

                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                BorrowView borrowView = new BorrowView();
                borrowView.ListViewPM.ItemsSource = new ObservableCollection<PHIEUMUON>(DataProvider.Ins.DB.PHIEUMUONs);
                MainViewModel.MainFrame.Content = borrowView;
            }
        }

    }
}
