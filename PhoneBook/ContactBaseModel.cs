using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class ContactBaseModel : IContactModel // database
    {
        MySqlConnection connection;
        List<Contact> contacts;
        void ExecuteCommand(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddContact(Contact contact)
        {
            string query = "INSERT INTO contacts (name, phone, birthday, image, note)"
               + $"VALUES ('{contact.Name}', '{contact.Phone}', '{contact.BDay:yyyy-MM-dd}', '{contact.ImageUri}'," +
               $"'{contact.Note}')";
            ExecuteCommand(query);
        }

        public void DeleteContact(Contact contact)
        {
            string query = "DELETE FROM contacts WHERE id=" + contact.Id.ToString();
            ExecuteCommand(query);
        }

        public List<Contact> GetAllContact()
        {
            contacts = new List<Contact>();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM contacts", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                contacts.Add(new Contact()
                {
                    Id = (int)table.Rows[i].ItemArray[0],
                    Name = table.Rows[i].ItemArray[1].ToString(),
                    Phone = table.Rows[i].ItemArray[2].ToString(),
                    BDay = DateTime.Parse(table.Rows[i].ItemArray[3].ToString()),
                    ImageUri = table.Rows[i].ItemArray[4].ToString(),
                    Note = table.Rows[i].ItemArray[5].ToString()
                });
            }
            return contacts;
        }

        public Contact GetContact(int id)
        {
            string query = $"SELECT * FROM contacts WHERE id = {id}";
            Contact contact = new Contact();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                contact.Id = (int)table.Rows[0].ItemArray[0];
                contact.Name = table.Rows[0].ItemArray[1].ToString();
                contact.Phone = table.Rows[0].ItemArray[2].ToString();
                contact.BDay = DateTime.Parse(table.Rows[0].ItemArray[3].ToString());
                contact.ImageUri = table.Rows[0].ItemArray[4].ToString();
                contact.Note = table.Rows[0].ItemArray[5].ToString();
            }
            return contact;
        }

        public void ChangeContact(Contact contact, Contact result)
        {
            string query = $"UPDATE contacts SET name='{result.Name}', phone='{result.Phone}', " +
               $"birthday='{result.BDay:yyyy-MM-dd}', image='{result.ImageUri}', note='{result.Note}' WHERE id={contact.Id}";
            ExecuteCommand(query);
        }
    }
}
