using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PhoneBook
{
    class PersonModel
    {
        public Person GetPerson(string login, string password)
        {
            Person person = new Person();
            string connectString = "Server=localhost;Database=testdb;Uid=root;Pwd=root";
            MySqlConnection mySqlConnection = new MySqlConnection(connectString);
            mySqlConnection.Open();
            string query = $"SELECT * FROM users WHERE login = '{login}' AND pass = '{password}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                person.Id = (int)table.Rows[0].ItemArray[0];
                person.Login = table.Rows[0].ItemArray[1].ToString();
                person.Password = table.Rows[0].ItemArray[2].ToString();
                person.Date = table.Rows[0].ItemArray[3].ToString();
            }
            mySqlConnection.Close();
            return person;
        }
    }
}
