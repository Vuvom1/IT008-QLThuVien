using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Library_Management_App.Model;

namespace Library_Management_App.ViewModel
{
    internal class BooksViewModel: BaseViewModel
    {
        private string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        private ObservableCollection<SACH> _ListBook;
        public ObservableCollection<SACH> ListBook { get => _ListBook; set => _ListBook = value; }
        public ICommand AddBookCommand { get; set; }
        public ICommand DetailBooksCommand { get; set; }

        public BooksViewModel() 
        {
            AddBookCommand = new RelayCommand<BooksView>((p) => { return p == null ? false : true; }, (p) => _AddBookCommand(p));
            DetailBooksCommand = new RelayCommand<BooksView>((p) => { return p.ListViewBooks.SelectedItem == null ? false : true; }, (p) => _DetailBooksCommand(p));
        }

        void _AddBookCommand(BooksView booksView)
        {

        }
        void _DetailBooksCommand(BooksView booksView)
        {

        }
    }
}
