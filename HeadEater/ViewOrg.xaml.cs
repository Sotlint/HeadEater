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
    /// Логика взаимодействия для ViewOrg.xaml
    /// </summary>
    /// 
    public partial class ViewOrg : Window
    {
        HeContext db = new HeContext();
        VacancyDatum vacancy = new VacancyDatum();
        OrganizationDatum org = new OrganizationDatum();
        public ViewOrg()
        {
            InitializeComponent();
           
            vacancy = db.VacancyData.Find(GRUD.select_id);
            org = db.OrganizationData.Find(vacancy.OrgId);
            lAddres.Content = org.Addres;
            ldis.Content = org.Description;
            lMail.Content = org.Mail;
            lName.Content = org.Name;
            lTelephone.Content = org.Telephone;
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
