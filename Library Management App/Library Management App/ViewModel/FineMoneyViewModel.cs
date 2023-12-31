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

        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand AddCsCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }

        public FineMoneyViewModel()
        {
            listTK = new ObservableCollection<string>() { "Mã PT", "Họ tên" };
            listPT = new ObservableCollection<PHIEUTHU>(DataProvider.Ins.DB.PHIEUTHUs);
            SearchCommand = new RelayCommand<FineMoneyView>((p) => true, (p) => _SearchCommand(p));
            AddCsCommand = new RelayCommand<FineMoneyView>((p) => true, (p) => _AddCs(p));
            LoadCsCommand = new RelayCommand<FineMoneyView>((p) => true, (p) => _LoadCsCommand(p));
            Detail = new RelayCommand<FineMoneyView>((p) => true, (p) => _Detail(p));

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
            listTK = new ObservableCollection<string>() { "Họ tên", "Mã PT" };
            paramater.ListViewPT.ItemsSource = listPT;
            paramater.ListViewPT.Items.Refresh();
            MainViewModel.MainFrame.Content = addFineMoneyView;
        }


        void _SearchCommand(FineMoneyView paramater)
        {
            ObservableCollection<PHIEUTHU> temp = new ObservableCollection<PHIEUTHU>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã PT":
                        {
                            foreach (PHIEUTHU s in listPT)
                            {
                                if (s.MAPT.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Họ tên":
                        {
                            foreach (PHIEUTHU s in listPT)
                            {
                                if (s.NGUOIDUNG.TENND.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    
                    default:
                        {
                            foreach (PHIEUTHU s in listPT)
                            {
                                if (s.NGUOIDUNG.TENND.ToLower().Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.ListViewPT.ItemsSource = temp;
            }
            else
                paramater.ListViewPT.ItemsSource = listPT;
        }

        void _Detail(FineMoneyView paramater)
        {
            DetailFineMoneyView detailFineMoneyView = new DetailFineMoneyView();
            PHIEUTHU temp = (PHIEUTHU)paramater.ListViewPT.SelectedItem;
            detailFineMoneyView.MaPT.Text = temp.MAPT;
            detailFineMoneyView.TenDG.Text = temp.TENND;
            detailFineMoneyView.TONGNO.Text = temp.TONGNO.ToString();
            detailFineMoneyView.STT.Text = temp.TIENTHU.ToString();
            detailFineMoneyView.CL.Text = temp.TIENCONLAI.ToString();
            MainViewModel.MainFrame.Content = detailFineMoneyView;
        }
    }
}
