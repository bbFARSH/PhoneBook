using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhoneBook
{
    class RedactorViewModel: INotifyPropertyChanged // update
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static int Id;
        ContactBaseModel baseModel;
        Contact firstContact, secondContact;
        public Action CloseAction { get; set; }

        public RedactorViewModel()
        {
            baseModel = new ContactBaseModel();
            firstContact = baseModel.GetContact(Id);
            secondContact = new Contact()
            {
                Id = firstContact.Id,
                Name = firstContact.Name,
                Phone = firstContact.Phone,
                BDay = firstContact.BDay,
                ImageUri = firstContact.ImageUri,
                Note = firstContact.Note
            };
        }

        public Contact ChangeContact
        {
            get { return secondContact; }
            set
            {
                secondContact = value;
                Notify("ChangeContact");
            }
        }
        public ICommand ChangeConctactButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    baseModel.ChangeContact(firstContact, secondContact);
                    MessageBox.Show("Изменено!");
                    CloseAction();
                }));
            }
        }
    }
}
