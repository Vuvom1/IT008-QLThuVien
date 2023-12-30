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
    public class DetailImportBookViewModel
    {
        public ICommand Loadwd { get; set; }
        public ICommand Back { get; set; }
        public ICommand Delete { get; set; }
        public DetailImportBookViewModel()
        {
            Back = new RelayCommand<DetailImportBookView>((p) => true, (p) => _Back(p));
            Delete = new RelayCommand<DetailImportBookView>((p) => true, (p) => _Delete(p));
        }
        void _Back(DetailImportBookView p)
        {
            ImportBookView importView = new ImportBookView();
            MainViewModel.MainFrame.Content = importView;
        }

        void _Delete(DetailImportBookView parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa phiếu nhập này?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (PHIEUNHAP temp in DataProvider.Ins.DB.PHIEUNHAPs)
                {
                    if (temp.MAPN == int.Parse(parameter.MaPN.Text))
                    {                       
                        DataProvider.Ins.DB.PHIEUNHAPs.Remove(temp);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                ImportBookView importView = new ImportBookView();
                importView.ListViewPN.ItemsSource = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
                MainViewModel.MainFrame.Content = importView;
            }
        }

    }
}
