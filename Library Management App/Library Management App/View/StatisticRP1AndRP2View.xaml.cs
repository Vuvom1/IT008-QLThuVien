using MaterialDesignThemes.Wpf;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_App.View
{
    /// <summary>
    /// Interaction logic for StatisticRP1AndRP2View.xaml
    /// </summary>
    public partial class StatisticRP1AndRP2View : UserControl
    {
        public StatisticRP1AndRP2View()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticReport1 w = new StatisticReport1();
            w.ShowDialog(Application.Current.MainWindow);

        }


    }
}
