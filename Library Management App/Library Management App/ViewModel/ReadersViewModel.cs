using Library_Management_App.Model;
using Library_Management_App.View;
using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    public class ReadersViewModel:BaseViewModel
    {
        private ObservableCollection<DOCGIA> _ListDG;
        public ObservableCollection<DOCGIA> ListDG { get => _ListDG; set { _ListDG = value;/* OnPropertyChanged();*/ } }
        private ObservableCollection<string> _ListTK;
        public ObservableCollection<string> ListTK { get => _ListTK; set { _ListTK = value; OnPropertyChanged(); } }
        public ICommand SearchReadersCommand { get; set; }
        public ICommand LoadReadersCommand { get; set; }
        public ICommand DetailReadersCommand { get; set; }
        public ICommand AddReadersCommand { get; set; }

        public ReadersViewModel() 
        {
            ListDG = new ObservableCollection<DOCGIA>(DataProvider.Ins.DB.DOCGIAs);
            ListTK = new ObservableCollection<string>() { "Mã ĐG", "Tên ĐG", "SĐT" };
            SearchReadersCommand = new RelayCommand<ReadersView>((p) => { return p == null ? false : true; }, (p) => _SearchReadersCommand(p));
            DetailReadersCommand = new RelayCommand<ReadersView>((p) => { return p.ListViewDG.SelectedItem == null ? false : true; }, (p) => _DetailReadersCommand(p));
            LoadReadersCommand = new RelayCommand<ReadersView>((p) => true, (p) => _LoadReadersCommand(p));
            AddReadersCommand = new RelayCommand<ReadersView>((p) => true, (p) => _AddReadersCommand(p));
        }

        void _AddReadersCommand(ReadersView readersView)
        {
            AddReadersView addReadersView = new AddReadersView();
            MainViewModel.MainFrame.Content = addReadersView;
        }

        void _LoadReadersCommand(ReadersView readersView)
        {
            readersView.cbxChon.SelectedIndex = 0;
        }

        void _SearchReadersCommand(ReadersView readersView)
        {
            ObservableCollection<DOCGIA> temp = new ObservableCollection<DOCGIA>();
            if (readersView.cbxChon.Text != "")
            {
                switch (readersView.cbxChon.SelectedItem.ToString())
                {
                    case "Mã ĐG":
                        {
                            foreach (DOCGIA s in ListDG)
                            {
                                if (s.MADG.ToLower().Contains(readersView.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Tên ĐG":
                        {
                            foreach (DOCGIA s in ListDG)
                            {
                                if (s.TENDG.ToLower().Contains(readersView.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "SĐT":
                        {
                            foreach (DOCGIA s in ListDG)
                            {
                                if (s.SDT.ToLower().Contains(readersView.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            foreach (DOCGIA s in ListDG)
                            {
                                if (s.TENDG.ToLower().Contains(readersView.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                readersView.ListViewDG.ItemsSource = temp;
            }
            else
                readersView.ListViewDG.ItemsSource = ListDG;
        }

        void _DetailReadersCommand(ReadersView readersView)
        {
            DetailReaderView detailReader = new DetailReaderView();
            DOCGIA temp = (DOCGIA)readersView.ListViewDG.SelectedItem;
            detailReader.MaDG.Text = temp.MADG;
            detailReader.TenDG.Text = temp.TENDG;
            detailReader.SDTDG.Text = temp.SDT;
            detailReader.eMAILDG.Text = temp.EMAIL;
            detailReader.DCDG.Text = temp.DCHI;
            detailReader.NgaySinhDG.Text = temp.NGSINH.ToString();
            ListDG = new ObservableCollection<DOCGIA>(DataProvider.Ins.DB.DOCGIAs);
            readersView.ListViewDG.ItemsSource = ListDG;
            readersView.ListViewDG.SelectedItem = null;
            MainViewModel.MainFrame.Content = detailReader;
        }
    }
    
}
