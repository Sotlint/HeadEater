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
    /// Логика взаимодействия для RegisterWorker.xaml
    /// </summary>
    public partial class RegisterWorker : Window
    {
        public RegisterWorker()
        {
            InitializeComponent();
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main_wpf = new MainWindow();
            Main_wpf.Show();
            Close();
        }

        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text != "" && TextBox_Password.Text != "" && TextBox_Name.Text != "" && TextBox_Surname.Text != "" && TextBox_Mail.Text != "" && TextBox_Telephone.Text != ""  && TextBox_Patronomic.Text != "")
            {

                if (GRUD.RegisterWorker(TextBox_Login.Text, TextBox_Password.Text, TextBox_Patronomic.Text, TextBox_Surname.Text, TextBox_Name.Text, TextBox_Mail.Text, TextBox_Telephone.Text) == true)
                {
                    MessageBox.Show("Успешно!", "HeadEater");
                    MainWindow Main_wpf = new MainWindow();
                   Main_wpf.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "HeadEater");
            }
        }
    }
}
