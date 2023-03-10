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
    /// Логика взаимодействия для OProfile.xaml
    /// </summary>
    public partial class OProfile : Window
    {
        HeContext db = new HeContext();
        public OProfile()
        {
            InitializeComponent();
            OrganizationDatum org = new OrganizationDatum();
            org = db.OrganizationData.Find(GRUD.id);

            lName.Content = org.Name;
            TextBox_Discription.Text = org.Description;
            la.Content = org.Addres;
            lMail.Content = org.Mail;
            lTelephone.Content = org.Telephone;
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            OrgMenu next_wpf = new OrgMenu();
            next_wpf.Show();
            Close();
        }

        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            OSetting next_wpf = new OSetting();
            next_wpf.Show();
            Close();
        }
    }
}
