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
    /// Логика взаимодействия для OReqInfo.xaml
    /// </summary>
    public partial class OReqInfo : Window
    {
        HeContext db = new HeContext();
        WorkerDatum worker = new WorkerDatum();
        OrganizationDatum org = new OrganizationDatum();
        VacancyDatum vacancy = new VacancyDatum();
        VacancyRequest Rvacancy = new VacancyRequest();

        public OReqInfo()
        {
            InitializeComponent();
            org = db.OrganizationData.Find(GRUD.id);
            Rvacancy = db.VacancyRequests.Find(GRUD.select_id);
            worker = db.WorkerData.Find(Rvacancy.WorkerId);
            vacancy = db.VacancyData.Find(Rvacancy.VacId);
           

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
            OReq next_wpf = new OReq();
            next_wpf.Show();
            Close();
        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {
            db.VacancyRequests.Remove(Rvacancy);
            db.SaveChanges();
            OReq next_wpf = new OReq();
            next_wpf.Show();
            Close();
        }

        private void Button_ch_Click(object sender, RoutedEventArgs e)
        {
            worker.Status = 1;
            db.WorkerData.Update(worker);
            db.SaveChanges();
            db.VacancyRequests.Remove(Rvacancy);
            db.SaveChanges();
            db.VacancyData.Remove(vacancy);
            db.SaveChanges();
            OReq next_wpf = new OReq();
            next_wpf.Show();
            Close();

        }


        private void Button_printt(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                
                Button_print.Visibility = Visibility.Hidden;

                // Напечатать элемент
                printDialog.PrintVisual(List_w,"Информация о кандидате");

                Button_print.Visibility = Visibility.Visible;
            }
        }
    }
}
