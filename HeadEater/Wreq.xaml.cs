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
using Microsoft.EntityFrameworkCore;

namespace HeadEater
{
    /// <summary>
    /// Логика взаимодействия для Wreq.xaml
    /// </summary>
    
    public partial class Wreq : Window
    {
        HeContext db = new HeContext();


        public Wreq()
        {
            InitializeComponent();
            db.VacancyRequests.Load();
            DataContext = db.VacancyRequests.Local.ToObservableCollection();
            VacancyRequest? V = List_Vac.SelectedItem as VacancyRequest;
            var vacancy = db.VacancyRequests.ToList();
            foreach (VacancyRequest i in vacancy)
            {
                if (i.WorkerId==GRUD.id)
                {
                    List_Vac.Items.Add(i);
                }
            }
        }

        private void select(object sender, RoutedEventArgs e)
        {
            WinfoReq next_wpf = new WinfoReq();
            next_wpf.Show();
           
        }

        private void SC(object sender, SelectionChangedEventArgs e)
        {
            VacancyRequest p = List_Vac.SelectedItem as VacancyRequest;
            if (p != null)
            {
                GRUD.select_id = p.ReqId;
            }
        }

        private void Button_vac_Click(object sender, RoutedEventArgs e)
        {
            WProfile next_wpf = new WProfile();
            next_wpf.Show();
            Close();
        }
    }
}
