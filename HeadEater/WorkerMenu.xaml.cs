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
    /// Логика взаимодействия для WorkerMenu.xaml
    /// </summary>
    public partial class WorkerMenu : Window
    {
        HeContext db = new HeContext();
        public WorkerMenu()
        {

            InitializeComponent();
            db.VacancyData.Load();
            DataContext = db.VacancyData.Local.ToObservableCollection();
            VacancyDatum? V = List_Vac.SelectedItem as VacancyDatum;
            var vacancy = db.VacancyData.ToList();
            foreach (VacancyDatum i in vacancy)
            {
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
            WProfile next_wpf = new WProfile();
            next_wpf.Show();
            Close();
        }

        private void select(object sender, RoutedEventArgs e)
        {
            Wvanacy next_wpf = new Wvanacy();
            next_wpf.Show();
            Close();
        }

    
        private void SC(object sender, SelectionChangedEventArgs e)
        {
            VacancyDatum p = List_Vac.SelectedItem as VacancyDatum;
            if (p != null)
            {
                GRUD.select_id = p.VacId;
            }
        }

        private void Button_OrgS_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_OrgName.Text == "")
            {
            }
            else
            {
                var vacancy = db.VacancyData.ToList();
                List_Vac.Items.Clear();
                foreach (VacancyDatum i in vacancy)
                {
                    if (i.Name == TextBox_OrgName.Text)
                    {
                        List_Vac.Items.Add(i);
                    }
                }
                if (List_Vac.Items.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено!", "HeadEater");
                }
            }
        }

        private void Button_PosS_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Position.Text == "")
            {
            }
            else
            {
                var vacancy = db.VacancyData.ToList();
                List_Vac.Items.Clear();
                foreach (VacancyDatum i in vacancy)
                {
                    if (i.Position == TextBox_Position.Text)
                    {
                        List_Vac.Items.Add(i);
                    }
                }
                if (List_Vac.Items.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено!", "HeadEater");
                }
            }
        }

        private void Button_SalS_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Salary.Text == "")
            {

            }
            else
            {
                var vacancy = db.VacancyData.ToList();
                List_Vac.Items.Clear();
                foreach (VacancyDatum i in vacancy)
                {
                    if (i.Salary == Convert.ToInt32(TextBox_Salary.Text))
                    {
                        List_Vac.Items.Add(i);
                    }
                }
                if (List_Vac.Items.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено!", "HeadEater");
                }
            }
        }

        private void Сlear_Click(object sender, RoutedEventArgs e)
        {
            var vacancy = db.VacancyData.ToList();
            List_Vac.Items.Clear();
            TextBox_Salary.Text = "";
            TextBox_Position.Text = "";
            TextBox_OrgName.Text = "";
            foreach (VacancyDatum i in vacancy)
            {

                List_Vac.Items.Add(i);

            }
        }
    }
}
