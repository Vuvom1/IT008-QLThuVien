using Library_Management_App.Model;
using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Library_Management_App.ViewModel
{
    public class BorrowViewModel : BaseViewModel
    {
        public ICommand OpenAddBorrowCM { get; set; }

        public BorrowViewModel()
        {
           
            //OpenAddBorrowCM = new RelayCommand<BorrowView>((p) => true, (p) => _OpenAdd(p));
            
        }
        //void _OpenAdd(OrderView paramater)
        //{
        //    AddBorrowView addOrder = new AddBorrowView();
        //    addOrder.SoHD.Text = rdma().ToString();
        //    listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
        //    paramater.ListViewHD.ItemsSource = listHD;
        //    paramater.ListViewHD.Items.Refresh();
        //    MainViewModel.MainFrame.Content = addOrder;
        //}
    }
}
