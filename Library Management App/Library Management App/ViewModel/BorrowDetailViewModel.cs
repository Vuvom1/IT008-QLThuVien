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
using System.Net.Mail;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace Library_Management_App.ViewModel
{
    public class BorrowDetailViewModel : BaseViewModel
    {

        public static Frame MainFrame { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand CompleteBorrow { get; set; }
        public ICommand SendMailCM { get; set; }

        private Visibility _isReturnVis;
        public Visibility isReturnVis { get => _isReturnVis; set { _isReturnVis = value; OnPropertyChanged(); } }

        public BorrowDetailViewModel()
        {
            SendMailCM = new RelayCommand<BorrowDetailView>((p) => true, (p) => _SendMail(p));
            CompleteBorrow = new RelayCommand<BorrowDetailView>((p) => true, (p) => _CompleteBorrow(p));
        
        }

        void _SendMail(BorrowDetailView parameter)
        {

            string nd = "Hệ thống thư viện thông báo: bạn đang có phiếu trả sách hết hạn, vui lòng trả sách. Trân trọng !";
            MailMessage message = new MailMessage("21522808@gm.uit.edu.vn", "21149374@student.hcmute.edu.vn", "Nhắc nhở trả sách", nd);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("21522808@gm.uit.edu.vn", "vuvo@1143");
            smtpClient.Send(message);
            MessageBox.Show("Đã gửi mật khẩu vào Email đăng ký !", "Thông báo");
        } 
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

                        TimeSpan differenceDate = DateTime.Now - temp.TGMUON.Value;


                        if (temp.TRANGTHAI == "Hết hạn")
                        {
                            temp.TIENPHAT = temp.TRIGIA * 5;
                        }

                        temp.TRANGTHAI = "Đã trả";
                        temp.TGTRA = DateTime.Now;

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
