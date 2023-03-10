using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeadEater
{
    internal static class GRUD
    {
        public static long? id;
        public static long? select_id;
        public static bool RegisterWorker(string login, string password, string patronomic, string surname, string name, string e_mail, string telephone)
        {
            bool check = true;
            using (HeContext db = new HeContext())
            {

                var orgs = db.OrganizationData.ToList();
                var workers = db.WorkerData.ToList();
                var users = db.Auths.ToList();

                WorkerDatum newWorker = new WorkerDatum();
                Auth newUser = new Auth();

                int login_id = users.Count + 1;
                int loginw_id = workers.Count + 1;


                foreach (WorkerDatum i in workers)
                {
                    if (i.Telephone == telephone)
                    {

                        MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                        check = false;


                    }
                    if (i.Mail == e_mail)
                    {

                        MessageBox.Show("Такой почтовый адрес уже используется!", "HeadEater");
                        check = false;

                    }


                }



                foreach (OrganizationDatum i in orgs)
                {
                    if (i.Telephone == telephone)
                    {

                        MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                        check = false;


                    }
                    if (i.Mail == e_mail)
                    {

                        MessageBox.Show("Такой почтовый адрес уже используется!", "HeadEater");
                        check = false;

                    }

                }


                foreach (Auth i in users)
                {
                    if (i.Login == login)
                    {

                        MessageBox.Show("Такой логин уже используется!", "HeadEater");
                        check = false;
                        break;
                    }
                }


                if (check == true)
                {
                    newUser.LoginId = login_id;
                    newUser.Login = login;
                    newUser.Password = password;
                    newUser.Role = 2;

                    newWorker.Name = name;
                    newWorker.LoginId = login_id;
                    newWorker.WorkerId = loginw_id;
                    newWorker.Telephone = telephone;
                    newWorker.Mail = e_mail;
                    newWorker.Patronymic = patronomic;
                    newWorker.Surname = surname;



                    db.Auths.Add(newUser);
                    db.SaveChanges();
                    db.WorkerData.Add(newWorker);
                    db.SaveChanges();
                }

            }

            return check;
        }
        public static bool RegisterOrg(string login, string password, string name, string e_mail, string telephone, string address, string description)
        {
            bool check = true;
            using (HeContext db = new HeContext())
            {

                var orgs = db.OrganizationData.ToList();
                var users = db.Auths.ToList();
                var workers = db.WorkerData.ToList();

                OrganizationDatum org = new OrganizationDatum();
                Auth newUser = new Auth();

                int login_id = users.Count + 1;
                int loginw_id = orgs.Count + 1;


                foreach (OrganizationDatum i in orgs)
                {
                    if (i.Telephone == telephone)
                    {

                        MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                        check = false;

                    }
                    if (i.Mail == e_mail)
                    {

                        MessageBox.Show("Такой почтовый адрес уже используется!", "HeadEater");
                        check = false;

                    }
                    if (i.Telephone == telephone)
                    {

                        MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                        check = false;

                    }
                }

                foreach (WorkerDatum i in workers)
                {
                    if (i.Telephone == telephone)
                    {

                        MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                        check = false;


                    }
                    if (i.Mail == e_mail)
                    {

                        MessageBox.Show("Такой почтовый адрес уже используется!", "HeadEater");
                        check = false;

                    }

                }

                foreach (Auth i in users)
                {
                    if (i.Login == login)
                    {

                        MessageBox.Show("Такой логин уже используется!", "HeadEater");
                        check = false;
                        break;
                    }
                }


                if (check == true)
                {
                    newUser.LoginId = login_id;
                    newUser.Login = login;
                    newUser.Password = password;
                    newUser.Role = 1;

                    org.Name = name;
                    org.LoginId = login_id;
                    org.OrgId = loginw_id;
                    org.Telephone = telephone;
                    org.Mail = e_mail;
                    org.Addres = address;
                    org.Description = description;

                    db.Auths.Add(newUser);
                    db.SaveChanges();
                    db.OrganizationData.Add(org);
                    db.SaveChanges();
                }

            }

            return check;
        }
        public static int Enter(string login, string password)
        {
            int role = -1;


            using (HeContext db = new HeContext())
            {
                var users = db.Auths.ToList();
                var orgs = db.OrganizationData.ToList();
                var workers = db.WorkerData.ToList();

                foreach (Auth i in users)
                {
                    if (i.Login == login && i.Password == password && i.Role == 0)
                    {
                        id = i.LoginId;
                        role = 0;
                    }

                    if (i.Login == login && i.Password == password)
                    {
                        foreach (WorkerDatum j in workers)
                        {
                            if (j.LoginId == i.LoginId)
                            {
                                id = j.WorkerId;
                                role = 2;
                                break;
                            }
                        }


                        foreach (OrganizationDatum j in orgs)
                        {
                            if (j.LoginId == i.LoginId)
                            {
                                id = j.OrgId;
                                role = 1;
                                break;
                            }
                        }

                        break;
                    }
                }
            }


            return role;
        }
        public static void WDelete(Auth user)
        {
            using (HeContext db = new HeContext())
            {

                db.Auths.Remove(user);
                db.SaveChanges();

            }
        }
        public static void WUpdate(Auth user, WorkerDatum worker)
        {
            using (HeContext db = new HeContext())
            {

                try
                {
                    db.Auths.Update(user);
                    db.SaveChanges();
                    db.WorkerData.Update(worker);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность данных!", "HeadEater");
                }
            }
        }

        public static void NewVanacyR(VacancyRequest vr)
        {
            using (HeContext db = new HeContext())
            {
                try
                {
                    var list = db.VacancyRequests.ToList();
                    int id = list.Count + 1;


                    vr.ReqId = id;
                    db.VacancyRequests.Add(vr);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность данных!", "HeadEater");
                }
            }

        }


        public static void ODelete(Auth user)
        {
            using (HeContext db = new HeContext())
            {

                db.Auths.Remove(user);
                db.SaveChanges();

            }
        }

        public static void OUpdate(Auth user, OrganizationDatum org)
        {
            using (HeContext db = new HeContext())
            {

                try
                {
                    db.Auths.Update(user);
                    db.SaveChanges();
                    db.OrganizationData.Update(org);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность данных!", "HeadEater");
                }
            }
        }

        public static void ONewVacancy(VacancyDatum vacancy)
        {
            using (HeContext db = new HeContext())
            {
                try
                {
                    var list = db.VacancyData.ToList();
                    int id = list.Count + 1;

                    vacancy.VacId = id;
                    db.VacancyData.Add(vacancy);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Проверьте корректность данных!", "HeadEater");
                }
            }
        }

        public static void OUpdateVacancy(VacancyDatum vacancy)
        {
            using (HeContext db = new HeContext())
            {
                try
                {
                    db.VacancyData.Update(vacancy);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность данных!", "HeadEater");
                }
            }
        }
    }
}
