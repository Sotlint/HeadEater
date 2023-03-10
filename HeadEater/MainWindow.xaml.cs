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


namespace HeadEater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            HeContext.Context(this);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {

            RegisterChoise Reg_wpf = new RegisterChoise();
            Reg_wpf.Show();
            Close();
        }

        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
         int switcher; 
            switcher=GRUD.Enter(TextBox_login.Text,TextBox_Password.Password);
            if(switcher==1)
            {
                OrgMenu next_wpf = new OrgMenu();
                next_wpf.Show();
                Close();
            }
            if(switcher==2)
            {
                WorkerMenu next_wpf = new WorkerMenu();
                next_wpf.Show();
                Close();
            }
            if(switcher ==-1)
            {
                MessageBox.Show("Неверный логин или пароль!", "HeadEater");
            }
        }
    }
}
