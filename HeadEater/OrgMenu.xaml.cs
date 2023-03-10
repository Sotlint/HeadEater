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
    /// Логика взаимодействия для OrgMenu.xaml
    /// </summary>
    public partial class OrgMenu : Window
    {
        HeContext db = new HeContext();
        public OrgMenu()
        {
            InitializeComponent();
            db.VacancyData.Load();
            DataContext = db.VacancyData.Local.ToObservableCollection();
            VacancyDatum? V = List_Vac.SelectedItem as VacancyDatum;
            var vacancy = db.VacancyData.ToList();
            foreach (VacancyDatum i in vacancy)
            {
                if(i.OrgId==GRUD.id)
                List_Vac.Items.Add(i);
            }
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow next_wpf = new MainWindow();
            next_wpf.Show();
            Close();
        }

        private void Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            OProfile next_wpf = new OProfile();
            next_wpf.Show();
            Close();
        }

        private void BReq_Click(object sender, RoutedEventArgs e)
        {
            OReq next_wpf = new OReq();
            next_wpf.Show();
            Close();
        }

        private void BNewVacancy_Click(object sender, RoutedEventArgs e)
        {
            CreateVacancy next_wpf = new CreateVacancy();
            next_wpf.Show();
            Close();
        }

        private void List_Vac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VacancyDatum p = List_Vac.SelectedItem as VacancyDatum;
            if (p != null)
            {
                GRUD.select_id = p.VacId;
            }
        }

        private void BSelect_Click(object sender, RoutedEventArgs e)
        {
            OViewVacancy next_wpf = new OViewVacancy();
            next_wpf.Show();
            Close();
        }
    }
}
