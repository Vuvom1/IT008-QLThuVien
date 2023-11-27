﻿using Library_Management_App.ViewModel;
using Library_Management_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Library_Management_App.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public static Frame MainFrame { get; set; }

        public ICommand LoadPageCM { get; set; }

        public ICommand SignoutCM { get; set; }

        public ICommand SettingCM { get; set; }

        public ICommand BorrowCM { get; set; }

        public void LoadTenND(MainView p)
        {
        }

        void _Loadwd(MainView p)
        {
            
        }
        public void LoadQuyen(MainView p)
        {
            
        }

        public MainViewModel()
        {
            LoadPageCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame = p;
                p.Content = new BorrowView();
            });

            BorrowCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new BorrowView();
            });

            SettingCM = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                MainFrame.Content = new SettingView();
            });

            SignoutCM = new RelayCommand<FrameworkElement>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetParentWindow(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Hide();
                    LoginView w1 = new LoginView();
                    w1.ShowDialog();
                    w.Close();
                }
            });

            FrameworkElement GetParentWindow(FrameworkElement p)
            {
                FrameworkElement parent = p;

                while (parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;
                }
                return parent;
            }
        }
    }
}
