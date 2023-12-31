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

        public AddFineMoneyViewModel()
        {
            AddCsCommand = new RelayCommand<AddFineMoneyView>((p) => true, (p) => _AddCsCommand(p));
            LoadFineMNCM = new RelayCommand<AddFineMoneyView>((p) => true, (p) => _LoadFineMNCM(p));

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
            paramater.NGAY.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        }
        void _AddCsCommand(AddFineMoneyView paramater)
        {
            
            if (paramater.MAPT.Text == "" || paramater.TENDG.Text == "" || paramater.TONGNO.Text == "" || paramater.SOTIENTHU.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn thêm phiếu thu ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(paramater.MAPT.Text) || string.IsNullOrEmpty(paramater.TENDG.Text) || string.IsNullOrEmpty(paramater.TONGNO.Text) || string.IsNullOrEmpty(paramater.SOTIENTHU.Text) /*|| string.IsNullOrEmpty(paramater.DC.Text)*/)
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO");
                }
                else
                {
                    if (DataProvider.Ins.DB.PHIEUTHUs.Where(p => p.MAPT == paramater.MAPT.Text).Count() > 0)
                    {
                        MessageBox.Show("Mã phiếu thu đã tồn tại !", "THÔNG BÁO");
                    }
                    else
                    {
                        PHIEUTHU temp = new PHIEUTHU();
                        temp.MAPT = paramater.MAPT.Text.ToString();
                        temp.MAPM = 2487;
                        temp.MAND = "NV01";
                        temp.TENND = paramater.TENDG.Text.ToString();
                      
                        if (int.TryParse(paramater.SOTIENTHU.Text, out int tienThu))
                        {
                            temp.TIENTHU = tienThu;
                        }

                        if (int.TryParse(paramater.TONGNO.Text, out int tongNo))
                        {
                            temp.TONGNO = tongNo;
                        }

                        if (int.TryParse(paramater.CONLAI.Text, out int tienconlai))
                        {
                            temp.TIENCONLAI = tienconlai;
                        }

                        temp.TGPT = DateTime.Now;
                        DataProvider.Ins.DB.PHIEUTHUs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thêm phiếu thu thành công.", "THÔNG BÁO");
                        paramater.MAPT.Text = rdma();
            
                        paramater.TENDG.Clear();
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
