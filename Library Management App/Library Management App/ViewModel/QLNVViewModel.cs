using Library_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    public class QLNVViewModel:BaseViewModel
    {
        public ICommand LoadCsCommand {  get; set; }
        public ICommand SearchQLNVCM { get; set; }

        private ObservableCollection<NGUOIDUNG> _ListQLNV;
        public ObservableCollection<NGUOIDUNG> ListQLNV { get => _ListQLNV; set { _ListQLNV = value; OnPropertyChanged(); } }

        public QLNVViewModel() 
        {
            ListQLNV = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs.Where(p => p.MAROLE == 1));
        }
    }
}
