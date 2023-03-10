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
    /// Логика взаимодействия для OSetting.xaml
    /// </summary>
    public partial class OSetting : Window
    {
        HeContext db = new HeContext();

        public OSetting()
        {
            InitializeComponent();
            OrganizationDatum org = new OrganizationDatum();
            Auth user = new Auth();
            org = db.OrganizationData.Find(GRUD.id);
            user = db.Auths.Find(org.LoginId);

            TextBox_Login.Text = user.Login;
            TextBox_Password.Text = user.Password;
            TextBox_Discription.Text = org.Description;
            TextBox_Name.Text = org.Name;
            TextBox_mail.Text = org.Mail;
            TextBox_Telephone.Text = org.Telephone;
            TextBox_Addres.Text = org.Addres;
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            OrgMenu next_wpf = new OrgMenu();
            next_wpf.Show();
            Close();
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            OrganizationDatum org = new OrganizationDatum();
            org = db.OrganizationData.Find(GRUD.id);
            Auth user = new Auth();
            org = db.OrganizationData.Find(GRUD.id);
            user = db.Auths.Find(org.LoginId);
            GRUD.ODelete(user);
            MainWindow next_wpf = new MainWindow();
            next_wpf.Show();
            Close();
        }

        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            OrganizationDatum org = new OrganizationDatum();
            Auth user = new Auth();
            org = db.OrganizationData.Find(GRUD.id);
            user = db.Auths.Find(org.LoginId);

            user.Login = TextBox_Login.Text;
            user.Password = TextBox_Password.Text;

            org.Name = TextBox_Name.Text;
            org.Description = TextBox_Discription.Text;
            org.Addres = TextBox_Addres.Text;
            org.Telephone = TextBox_Telephone.Text;
            org.Mail = TextBox_mail.Text;

            GRUD.OUpdate(user, org);
            OProfile next_wpf = new OProfile();
            next_wpf.Show();
            Close();
        }
    }
}
