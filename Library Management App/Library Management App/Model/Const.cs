using Library_Management_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_App.Model
{
    public class Const : BaseViewModel
    {
        public static string UserName { get; set; }
        public static int Role {  get; set; }

        public static NGUOIDUNG ND { get; set; }
        public static string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
    }
}
