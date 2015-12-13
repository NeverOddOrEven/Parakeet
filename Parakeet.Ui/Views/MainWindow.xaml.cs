﻿using Parakeet.Ui.ViewModel;
using System;
using System.Windows;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.MainFrame.Navigate(HomeViewModel.Uri);

            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}