using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhoneBook
{
    class MainViewModel : INotifyPropertyChanged // vievmodel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        Person persone;
        PersonModel model;
        public Action CloseAction { get; set; }

        public MainViewModel()
        {
            persone = new Person();
            model = new PersonModel();
        }
        public ICommand EnterButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    Person persone1 = model.GetPerson(Login,Password);
                    if (persone1.Login  == Login && persone1.Password == Password && Login != null && Password != null)
                    {
                        Application.Current.MainWindow.Visibility = Visibility.Hidden;
                        PhoneBookContact phoneBookContact = new PhoneBookContact();
                        phoneBookContact.ShowDialog();
                        if (phoneBookContact.ShowDialog().Value == false)
                            CloseAction();
                    }
                    else
                        MessageBox.Show("Неверный логин или пароль");
                }));
            }
        }
        public string Login
        {
            get { return persone.Login; }
            set
            {
                persone.Login = value;
                Notify("Login");
            }
        }
        public string Password
        {
            get { return persone.Password; }
            set
            {
                persone.Password = value;
                Notify("Password");
            }
        }
    }
}
