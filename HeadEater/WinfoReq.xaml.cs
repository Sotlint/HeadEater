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
    /// Логика взаимодействия для WinfoReq.xaml
    /// </summary>
    public partial class WinfoReq : Window
    {
        HeContext db = new HeContext();
        WorkerDatum worker = new WorkerDatum();
        OrganizationDatum org = new OrganizationDatum();
        VacancyDatum vacancy = new VacancyDatum();
        VacancyRequest Rvacancy = new VacancyRequest();
        public WinfoReq()
        {
            InitializeComponent();
            worker = db.WorkerData.Find(GRUD.id);
           
            Rvacancy = db.VacancyRequests.Find(GRUD.select_id);
            vacancy = db.VacancyData.Find(Rvacancy.VacId);
            org = db.OrganizationData.Find(vacancy.OrgId);

            lName.Content = vacancy.Name;
            lPosition.Content = vacancy.Position;
            lDis.Text = vacancy.Description;
            lMail.Content = org.Mail;
            lTelephone.Content = org.Telephone;
            lSalary.Content = vacancy.Salary;

            lwName.Content = worker.Name;
            lwSurname.Content = worker.Surname;
            lwPatronomic.Content = worker.Patronymic;
            lwMail.Content = worker.Mail;
            lwTelephone.Content = worker.Telephone;
            lwDis.Text = Rvacancy.Discription;
            lwPosition.Text = Rvacancy.Position;
            lwSalary.Text = Convert.ToString(Rvacancy.Salary);
            
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_info_Click(object sender, RoutedEventArgs e)
        {
            GRUD.select_id = vacancy.VacId;
            ViewOrg next_wpf = new ViewOrg();
            next_wpf.Show();
        }
    }
}
