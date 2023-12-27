using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Controls;

namespace Library_Management_App.ViewModel
{
    internal class FineMoneyViewModel : BaseViewModel
    {
        public static Frame MainFrame { get; set; }

        private ObservableCollection<PHIEUTHU> _listPT;
        public ObservableCollection<PHIEUTHU> listPT { get => _listPT; set { _listPT = value; OnPropertyChanged(); } }

        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand AddCsCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }

        public FineMoneyViewModel()
        {
            //listPT = new ObservableCollection<PHIEUTHU>(DataProvider.Ins.DB.PHIEUTHUs);
            //SearchCommand = new RelayCommand<FineMoneyView>((p) => true, (p) => _SearchCommand(p));
            AddCsCommand = new RelayCommand<FineMoneyView>((p) => true, (p) => _AddCs(p));
            LoadCsCommand = new RelayCommand<FineMoneyView>((p) => true, (p) => _LoadCsCommand(p));

        }

        void _LoadCsCommand(FineMoneyView parameter)
        {
            parameter.cbxChon.SelectedIndex = 0;
        }


        bool check(string m)
        {
            foreach (PHIEUTHU temp in DataProvider.Ins.DB.PHIEUTHUs)
            {
                if (temp.MAPT == m)
                    return true;
            }
            return false;
        }
        string rdma()
        {
            string ma;
            do
            {
                Random rand = new Random();
                ma = "PT" + rand.Next(0, 10000).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddCs(FineMoneyView paramater)
        {
            AddFineMoneyView addFineMoneyView = new AddFineMoneyView();
            addFineMoneyView.MAPT.Text = rdma().ToString();
            listPT = new ObservableCollection<PHIEUTHU>(DataProvider.Ins.DB.PHIEUTHUs);
            paramater.ListViewHD.ItemsSource = listPT;
            paramater.ListViewHD.Items.Refresh();
            MainViewModel.MainFrame.Content = addFineMoneyView;
        }

    }
}
