﻿using Bank2.Navigators;
using Bank2.ViewModel;
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

namespace Bank2.View.Pages
{
    /// <summary>
    /// Interaction logic for PracownikKlienciPage.xaml
    /// </summary>
    public partial class PracownikKlienciPage :Page
    { 
        public PracownikKlienciPage()
        {
 
            InitializeComponent();

          
           // DataContext = new VMPracownikKlienci(navigator);
        }
    }
}
