using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Windows.Input;

namespace PhoneBook
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        Persone persone;
        AuthorizationModel authorization;
        public Persone MyPersone
        {
            get { return persone; }
            set
            {
                persone = value;
                Notify("MyPersone");
            }

        }
        public MainViewModel()
        {
            authorization = new AuthorizationModel();
            persone = new Persone();
        }
        public ICommand ShowWindow
        {
            get
            {
                return new ButtonClick
                    (
                    new Action(()=>
                    {
                    authorization.Open(persone);
                    }));
            }
        }
    }
}
