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
    /// Логика взаимодействия для OReq.xaml
    /// </summary>
    public partial class OReq : Window
    {
        HeContext db = new HeContext();
        public OReq()
        {
            InitializeComponent();
            var vac = db.VacancyData.ToList();

            db.VacancyRequests.Load();
            DataContext = db.VacancyRequests.Local.ToObservableCollection();
            VacancyRequest? V = List_Vac.SelectedItem as VacancyRequest;
            var vacancy = db.VacancyRequests.ToList();
            foreach (VacancyRequest i in vacancy)
            {
                if (i.Status == 1)
                {
                    foreach (VacancyDatum j in vac)
                    {
                        if(i.VacId == j.VacId && j.OrgId == GRUD.id)

                            List_Vac.Items.Add(i);
                     
                        
                    }
                }
            }
        }

        private void Button_vac_Click(object sender, RoutedEventArgs e)
        {
            OReqInfo next_wpf = new OReqInfo();
            next_wpf.Show();
            Close();
           
        }

        private void SC(object sender, SelectionChangedEventArgs e)
        {
            VacancyRequest p = List_Vac.SelectedItem as VacancyRequest;
            if (p != null)
            {
                GRUD.select_id = p.ReqId;
            }
        }

        private void Bclick(object sender, RoutedEventArgs e)
        {
            OrgMenu next_wpf = new OrgMenu();
            next_wpf.Show();
            Close();
        }
    }
}
