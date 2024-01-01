using Library_Management_App.Model;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    public class AddFineMoneyViewModel : BaseViewModel
    {
        public ICommand AddCsCommand { get; set; }

        public ICommand LoadFineMNCM { get; set; }

        private List<DOCGIA> _LDG;

        public List<DOCGIA> LDG { get => _LDG; set { _LDG = value; OnPropertyChanged(); } }

        private List<PHIEUMUON> _LPM;

        public List<PHIEUMUON> LPM { get => _LPM; set { _LPM = value; OnPropertyChanged(); } }
        public ICommand chooseDG { get; set; }

        public ICommand choosePM { get; set; }

        public AddFineMoneyViewModel()
        {
            AddCsCommand = new RelayCommand<AddFineMoneyView>((p) => true, (p) => _AddCsCommand(p));
            LoadFineMNCM = new RelayCommand<AddFineMoneyView>((p) => true, (p) => _LoadFineMNCM(p));
            chooseDG = new RelayCommand<AddFineMoneyView>((p) => true, (p) => _chooseDG(p));
            choosePM = new RelayCommand<AddFineMoneyView>((p) => true, (p) => _choosePM(p));
        }

        void _chooseDG(AddFineMoneyView parameter)
        {
            DOCGIA temp = (DOCGIA)parameter.LDG.SelectedItem;
        }

        void _choosePM(AddFineMoneyView parameter)
        {
            PHIEUMUON temp = (PHIEUMUON)parameter.LPM.SelectedItem;
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

        void _LoadFineMNCM(AddFineMoneyView paramater) 
        {
            LDG = DataProvider.Ins.DB.DOCGIAs.ToList();
            paramater.LDG.ItemsSource = LDG;
            LPM = DataProvider.Ins.DB.PHIEUMUONs.ToList();
            paramater.LPM.ItemsSource = LPM;
            paramater.NGAY.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            
        }
        void _AddCsCommand(AddFineMoneyView paramater)
        {
            
            if (paramater.MAPT.Text == ""  || paramater.TONGNO.Text == "" || paramater.SOTIENTHU.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn thêm phiếu thu ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(paramater.MAPT.Text) ||  string.IsNullOrEmpty(paramater.TONGNO.Text) || string.IsNullOrEmpty(paramater.SOTIENTHU.Text) )
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO");
                }
                if (!int.TryParse(paramater.TONGNO.Text, out int TongNo) || !int.TryParse(paramater.SOTIENTHU.Text, out int TienThu) || TongNo < TienThu)
                {
                    MessageBox.Show("Số tiền thu không thể lớn hơn tổng nợ!", "THÔNG BÁO");
                    return;
                }
                else
                {
                    if (DataProvider.Ins.DB.PHIEUTHUs.Where(p => p.MAPT == paramater.MAPT.Text).Count() > 0)
                    {
                        MessageBox.Show("Mã phiếu thu đã tồn tại !", "THÔNG BÁO");
                    }
                    else
                    {
                        
                        DOCGIA a = (DOCGIA)paramater.LDG.SelectedItem;
                        PHIEUMUON b = (PHIEUMUON)paramater.LPM.SelectedItem; 

                        PHIEUTHU temp = new PHIEUTHU();
                        temp.MAPT = paramater.MAPT.Text.ToString();

                        temp.MAPM = b.MAPM;
                        temp.MAND = Const.ND.MAND;
                        temp.TENND = a.TENDG.ToString();
                        temp.MADG = a.MADG.ToString();
                                                
                        if (int.TryParse(paramater.SOTIENTHU.Text, out int tienThu))
                        {
                            temp.TIENTHU = tienThu;
                        }

                        if (int.TryParse(paramater.TONGNO.Text, out int tongNo))
                        {
                            temp.TONGNO = tongNo;
                        }

                        int tienconlai =(int) (temp.TONGNO - temp.TIENTHU);
                        temp.TIENCONLAI = tienconlai;

                        if (int.TryParse(paramater.CONLAI.Text, out tienconlai))
                        {
                            temp.TIENCONLAI = tienconlai;
                        }

                        temp.TGPT = DateTime.Now;
                        DataProvider.Ins.DB.PHIEUTHUs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thêm phiếu thu thành công.", "THÔNG BÁO");
                        paramater.MAPT.Text = rdma();
                        paramater.TONGNO.Clear();
                        paramater.SOTIENTHU.Clear();
                        paramater.CONLAI.Clear();
                        FineMoneyView fineMoneyView = new FineMoneyView();
                        fineMoneyView.ListViewPT.ItemsSource = new ObservableCollection<PHIEUTHU>(DataProvider.Ins.DB.PHIEUTHUs);
                        MainViewModel.MainFrame.Content = fineMoneyView;
                    }
                }
            }
        }
    }
}
