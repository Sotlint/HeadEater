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
    /// Логика взаимодействия для CreateVacancy.xaml
    /// </summary>
    public partial class CreateVacancy : Window
    {
        HeContext db = new HeContext();
        OrganizationDatum org = new OrganizationDatum();
        public CreateVacancy()
        {
            InitializeComponent();
            org=db.OrganizationData.Find(GRUD.id);
            TMail.Text = org.Mail;
            TTelephone.Text = org.Telephone;
            TName.Text = org.Name;
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            VacancyDatum vac = new VacancyDatum();
            vac.Name = org.Name;
            vac.OrgId = GRUD.id;
            vac.Position =TPosition.Text;
            vac.Salary =Convert.ToInt32(TSalary.Text);
            vac.Description =TDis.Text;
            GRUD.ONewVacancy(vac);

            OrgMenu next_wpf = new OrgMenu();
            next_wpf.Show();
            Close();
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            OrgMenu next_wpf = new OrgMenu();
            next_wpf.Show();
            Close();
        }
    }
}
