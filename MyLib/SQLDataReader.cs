using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MyLib
{
    public class SQLDataReader
    {
        private string MyConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=tasks";
        public BindingList<TaskItem> ReadData()
        {
            BindingList<TaskItem> result = new BindingList<TaskItem>();
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                const string quary = "SELECT id, description, due_date from tasks";
                MySqlCommand command = new MySqlCommand(quary, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32("id");
                        string Description = reader.GetString("description");
                        DateTime Due_date = reader.GetDateTime("due_date");
                        TaskItem ti = new TaskItem(Id, Description, Due_date);
                        result.Add(ti);
                    }
                }
            }

            catch (MySqlException ex)
            {
                return result;
            }
            return result;
        }

    }
}
