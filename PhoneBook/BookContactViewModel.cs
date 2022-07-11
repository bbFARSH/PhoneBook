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
    class BookContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Contact> names;
        Contact contact;
        IContactModel contactModel;

        public BookContactViewModel()
        {
            contact = new Contact();
            contactModel = new ContactBaseModel();
            if (contactModel.GetAllContact() != null)
            {
                names = new List<Contact>(contactModel.GetAllContact());
            }
            else
            {
                names = new List<Contact>();
            }
        }
        public List<Contact> Names
        {
            get { return names; }
            set
            {
                names = value;
                Notify("Names");
            }
        }
        public Contact SelectContact
        {
            get
            {
                if (contact.Name is null) return names[0];
                return contact;
            }
            set
            {
                contact = value;
                if (value == null)
                {
                    contact = new Contact();
                }
                Notify("SelectContact");
            }
        }
        public ICommand AddContact
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    AddContact addRecord = new AddContact();
                    addRecord.ShowDialog();
                    Names = new List<Contact>(contactModel.GetAllContact());
                }));
            }
        }
        public ICommand DeleteContact
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (contact.Name != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить контакт?",
                            "Удаление контакта " + contact.Name, MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                            contactModel.DeleteContact(contact);
                        Names = new List<Contact>(contactModel.GetAllContact());
                    }
                    else
                    {
                        MessageBox.Show("Необходимо выделить контакт!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }));
            }
        }
        public ICommand UpdateContact
        {
            get
            {
                return new ButtonCommand(new Action(() =>
                {
                    if (contact != null)
                    {
                        RedactorViewModel.Id = contact.Id;
                        ChangeContact changeContact = new ChangeContact();
                        changeContact.ShowDialog();
                        Names = new List<Contact>(contactModel.GetAllContact());
                    }
                }));
            }
        }
    }
}
