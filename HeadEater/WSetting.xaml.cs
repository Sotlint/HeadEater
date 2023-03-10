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
    /// Логика взаимодействия для WSetting.xaml
    /// </summary>
   
    public partial class WSetting : Window
    {
        HeContext db = new HeContext();
        public WSetting()
        {
            InitializeComponent();
            WorkerDatum worker = new WorkerDatum();
            Auth user = new Auth();
            worker = db.WorkerData.Find(GRUD.id);
            user= db.Auths.Find(worker.LoginId);

            TextBox_Login.Text = user.Login;
            TextBox_Password.Text =user.Password;
            TextBox_Patronomic.Text = worker.Patronymic;
            TextBox_Surname.Text = worker.Patronymic;
            TextBox_Name.Text = worker.Name;
            TextBox_Mail.Text =worker.Mail;
            TextBox_Telephone.Text = worker.Telephone;
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            WProfile next_wpf = new WProfile();
            next_wpf.Show();
            Close();
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            WorkerDatum worker = new WorkerDatum();
            Auth user = new Auth();
            worker = db.WorkerData.Find(GRUD.id);
            user = db.Auths.Find(worker.LoginId);
            GRUD.WDelete(user);

            MainWindow next_wpf = new MainWindow();
            next_wpf.Show();
            Close();
        }

        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            WorkerDatum worker = new WorkerDatum();
            Auth user = new Auth();
            worker = db.WorkerData.Find(GRUD.id);
            user = db.Auths.Find(worker.LoginId);

            user.Login = TextBox_Login.Text;
            user.Password = TextBox_Password.Text;

            worker.Name = TextBox_Name.Text;
            worker.Surname= TextBox_Surname.Text;
            worker.Patronymic = TextBox_Patronomic.Text;
            worker.Telephone= TextBox_Telephone.Text;
            worker.Mail= TextBox_Mail.Text;

            GRUD.WUpdate(user,worker);
            WProfile next_wpf = new WProfile();
            next_wpf.Show();
            Close();
        }
    }
}
