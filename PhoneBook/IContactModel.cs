using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    interface IContactModel //record model
    {
        List<Contact> GetAllContact();
        Contact GetContact(int id);
        void AddContact(Contact Contact);
        void DeleteContact(Contact Contact);
        void ChangeContact(Contact Contact, Contact result);
    }
}
