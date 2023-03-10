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
    /// Логика взаимодействия для Wvanacy.xaml
    /// </summary>
    public partial class Wvanacy : Window
    {

        HeContext db = new HeContext();
        WorkerDatum worker = new WorkerDatum();
        OrganizationDatum org = new OrganizationDatum();
        VacancyDatum vacancy = new VacancyDatum();


        public Wvanacy()
        {
            InitializeComponent();
            worker = db.WorkerData.Find(GRUD.id);
            vacancy = db.VacancyData.Find(GRUD.select_id);
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

        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            WorkerMenu next_wpf = new WorkerMenu();
            next_wpf.Show();
            Close();
        }

        private void Button_vacancy_Click(object sender, RoutedEventArgs e)
        {
            var spisok = db.VacancyRequests.ToList();
            bool check = true;
            VacancyRequest vacr = new VacancyRequest();
            try
            {
                vacr.ReqId = spisok.Count() + 1;
                vacr.VacId = vacancy.VacId;
                vacr.WorkerId = worker.WorkerId;
                vacr.Position = lwPosition.Text;
                vacr.Salary = Convert.ToInt32(lwSalary.Text);
                vacr.Discription = lwDis.Text;
                vacr.Status = 1;
            }
            catch
            {
                check = false;
                MessageBox.Show("Проверьте корректность введенных данных!", "HeadEater");
            }
            if (check == true)
            {

                foreach (VacancyRequest i in spisok)
                    if (i.VacId==vacr.VacId)
                    {
                        if (i.WorkerId == worker.WorkerId)
                        {
                            MessageBox.Show("Вы уже отправляли резюме на эту вакансию!", "HeadEater");
                            check = false;
                            break;
                        }
                    }
            }

            if (check == true)
            {
                GRUD.NewVanacyR(vacr);
                MessageBox.Show("Резюме отправлено!", "HeadEater");
                WorkerMenu next_wpf = new WorkerMenu();
                next_wpf.Show();
                Close();

            }

        }

        private void Button_info_Click(object sender, RoutedEventArgs e)
        {
            ViewOrg next_wpf = new ViewOrg();
            next_wpf.Show();
        }
    }
}




        
    


