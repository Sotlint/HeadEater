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
using System.Windows.Shapes;

namespace HeadEater
{
    /// <summary>
    /// Логика взаимодействия для RegisterChoise.xaml
    /// </summary>
    public partial class RegisterChoise : Window
    {
        public RegisterChoise()
        {
            InitializeComponent();
        }

        private void Button_RegW_Click(object sender, RoutedEventArgs e)
        {
            RegisterWorker Reg_wpf = new RegisterWorker();
            Reg_wpf.Show();
            Close();
        }

        private void Button_RegO_Click(object sender, RoutedEventArgs e)
        {
            RegisterOrg Reg_wpf = new RegisterOrg();
            Reg_wpf.Show();
            Close();
        }
    }
}
