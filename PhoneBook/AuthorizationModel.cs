using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBook
{
    class AuthorizationModel
    {
        MySqlConnection _mySqlConnection;
        Persone _persone;
        public AuthorizationModel()
        {
            _mySqlConnection = new MySqlConnection("Server=localhost;" +
                "database=testdb;uid=root;pwd=root");
            _persone = new Persone();
        }
        public void Open(Persone persone)
        {
            _mySqlConnection.Open();
            string query = $"SELECT *FROM users where login='{persone.Login}'" +
                $"and pass ='{persone.Password}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _mySqlConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                MessageBox.Show(table.Rows[0].ItemArray[0].ToString());
            else
                MessageBox.Show("Неверные данные");
            _mySqlConnection.Close();
        }
    }
}
