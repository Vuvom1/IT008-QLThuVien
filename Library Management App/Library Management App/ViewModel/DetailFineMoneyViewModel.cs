using System;
using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    public class DetailFineMoneyViewModel:BaseViewModel
    {

        public ICommand Delete { get; set; }
        public ICommand Back { get; set; }

        public DetailFineMoneyViewModel()
        {
            Back = new RelayCommand<DetailFineMoneyView>((p) => true, (p) => _Back(p));
            Delete = new RelayCommand<DetailFineMoneyView>((p) => true, (p) => _Delete(p));
        }

        void _Back(DetailFineMoneyView p)
        {
            FineMoneyView fineMNView = new FineMoneyView();
            MainViewModel.MainFrame.Content = fineMNView;
        }

        void _Delete(DetailFineMoneyView parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa phiếu thu này?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (PHIEUTHU temp in DataProvider.Ins.DB.PHIEUTHUs)
                {
                    if (temp.MAPT == parameter.MaPT.Text)
                    {
                        DataProvider.Ins.DB.PHIEUTHUs.Remove(temp);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                FineMoneyView fineMNView = new FineMoneyView();
                fineMNView.ListViewPT.ItemsSource = new ObservableCollection<PHIEUTHU>(DataProvider.Ins.DB.PHIEUTHUs);
                MainViewModel.MainFrame.Content = fineMNView;
            }
        }
    }
}
