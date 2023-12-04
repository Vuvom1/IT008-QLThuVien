using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        }
    }
}
