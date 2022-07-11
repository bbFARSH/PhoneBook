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
    class AddContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ContactBaseModel contactBaseModel;
        Contact contact;
        public Action CloseAction { get; set; }

        public AddContactViewModel()
        {
            contactBaseModel = new ContactBaseModel();
            contact = new Contact();
        }

        public ICommand AddContactButton
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (contactBaseModel.GetAllContact().Count >= 1)
                        contact.Id = contactBaseModel.GetAllContact()[contactBaseModel.GetAllContact().Count - 1].Id;
                    else
                    contact.Id = 0;
                    contact.Id += 1;
                    contactBaseModel.AddContact(contact);
                    MessageBox.Show("Контакт добавлен!");
                    CloseAction();
                }));
            }
        }


        public Contact AddContact
        {
            get { return contact; }
            set
            {
                contact = value;
                Notify("AddContact");
            }
        }

    }
}
