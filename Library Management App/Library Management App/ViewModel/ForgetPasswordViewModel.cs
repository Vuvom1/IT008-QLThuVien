using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library_Management_App.Model;
using System.Net.Mail;
using System.Net;
using System.Windows;

namespace Library_Management_App.ViewModel
{

    public class ForgetPasswordViewModel : BaseViewModel
    {
        public ICommand CancelCM { get; set; }
        public ICommand SendPassCM { get; set; }
        public ForgetPasswordViewModel()
        {
            CancelCM = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                LoginViewModel.MainFrame.Content = new LoginPageView();
            });

            SendPassCM = new RelayCommand<ForgetPasswordView>((p) => true, (p) => _SendPass(p));

        }

        void _SendPass(ForgetPasswordView parameter)
        {
            int dem = DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.MAIL == parameter.MailAddress.Text).Count();
            if (dem == 0)
            {
                MessageBox.Show("Email này chưa được đăng ký !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Random rand = new Random();
            string newpass = rand.Next(100000, 999999).ToString();
            foreach (NGUOIDUNG temp in DataProvider.Ins.DB.NGUOIDUNGs)
            {
                if (temp.MAIL == parameter.MailAddress.Text)
                {
                    temp.PASS = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(newpass));
                    break;
                }
            }
            DataProvider.Ins.DB.SaveChanges();
            string nd = "Vui lòng nhập mật khẩu " + newpass + " để đăng nhập. Trân trọng !";
            MailMessage message = new MailMessage("21522808@gm.uit.edu.vn", "21149374@student.hcmute.edu.vn", "Lấy lại mật khẩu", nd);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("21522808@gm.uit.edu.vn", "vuvo@1143");
            smtpClient.Send(message);
            MessageBox.Show("Đã gửi mật khẩu vào Email đăng ký !", "Thông báo");
        }
    }
}
