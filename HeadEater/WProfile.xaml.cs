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
    /// Логика взаимодействия для WProfile.xaml
    /// </summary>
    public partial class WProfile : Window
    {
        HeContext db = new HeContext();
        public WProfile()
        {
            InitializeComponent();

            WorkerDatum worker = new WorkerDatum();
            worker=db.WorkerData.Find(GRUD.id);

            lName.Content=worker.Name; 
            lSurname.Content=worker.Surname;
            lPatronomic.Content = worker.Patronymic;
            lMail.Content = worker.Mail;
            lTelephone.Content = worker.Telephone;
            if(worker.Status==0)
            {
                lStatus.Content = "Безработный";
            }
            if (worker.Status == 1)
            {
                lStatus.Content = "Работает";
            }

        }

        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            WSetting next_wpf = new WSetting();
            next_wpf.Show();
            Close();
        }

        private void Button_Ex_Click(object sender, RoutedEventArgs e)
        {
            WorkerMenu next_wpf = new WorkerMenu();
            next_wpf.Show();
            Close();
        }

        private void Button_vac_Click(object sender, RoutedEventArgs e)
        {
            Wreq next_wpf = new Wreq();
            next_wpf.Show();
            Close();
        }
    }
}
