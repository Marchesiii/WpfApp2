﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Lógica interna para TelaEmprestimo.xaml
    /// </summary>
    public partial class TelaEmprestimo : Window
    {

        public TelaEmprestimoVm Tela { get; set; }
        public TelaEmprestimo()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = Tela.EmprestarItem();

        }
    }
}
