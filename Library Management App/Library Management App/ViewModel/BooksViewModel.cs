﻿using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Management_App.ViewModel
{
    internal class BooksViewModel: BaseViewModel
    {
        public ICommand AddPdPdCommand { get; set; }

        public BooksViewModel() 
        {
        }
    }
}