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
    /// Логика взаимодействия для OUodateVacancy.xaml
    /// </summary>
    public partial class OUodateVacancy : Window
    {
        HeContext db = new HeContext();
        OrganizationDatum org = new OrganizationDatum();
        VacancyDatum vacancy = new VacancyDatum();

        public OUodateVacancy()
        {
            InitializeComponent();
            org = db.OrganizationData.Find(GRUD.id);
            vacancy = db.VacancyData.Find(GRUD.select_id);

            TMail.Text = org.Mail;
            TTelephone.Text = org.Telephone;
            TName.Text = org.Name;
            TPosition.Text = vacancy.Position;
            TSalary.Text = Convert.ToString(vacancy.Salary);
            TDis.Text = vacancy.Description;
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
           
            vacancy.Position = TPosition.Text;
            vacancy.Salary = Convert.ToInt32(TSalary.Text);
            vacancy.Description = TDis.Text;

            GRUD.OUpdateVacancy(vacancy);

            OViewVacancy next_wpf = new OViewVacancy();
            next_wpf.Show();
            Close();
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            OViewVacancy next_wpf = new OViewVacancy();
            next_wpf.Show();
            Close();
        }
    }
}
