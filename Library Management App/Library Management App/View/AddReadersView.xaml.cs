using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_Management_App.View
{
    /// <summary>
    /// Interaction logic for AddReadersView.xaml
    /// </summary>
    public partial class AddReadersView : Page
    {
        public AddReadersView()
        {
            InitializeComponent();
        }
        public void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private void lbl_Click(object sender, RoutedEventArgs e)
        {
            //MainViewModel.MainFrame.Content = new ReadersView();
        }
    }
}
