using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

                const string quary = "SELECT id, description, due_date, status from tasks";
                MySqlCommand command = new MySqlCommand(quary, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32("id");
                        string Description = reader.GetString("description");
                        DateTime Due_date = reader.GetDateTime("due_date");
                        bool status = reader.GetBoolean("status");
                        TaskItem ti = new TaskItem(Id, Description, Due_date);
                        ti.isCompleted_ = status;
                        result.Add(ti);
                    }
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
            return result;
        }

        public bool DeleteTask(int id)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "DELETE FROM tasks WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool AddTask(TaskItem task)  // Метод для добавления пользователя
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "INSERT INTO tasks (id, description, due_date) " +
                               "VALUES (@id, @description, @due_date)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", task.id_);
                command.Parameters.AddWithValue("@description", task.description_);
                command.Parameters.AddWithValue("@due_date", task.dueDate_);

                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Возвращает true, если добавление прошло успешно
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateTask(TaskItem task) 
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "UPDATE tasks SET status = 1" +
                               " WHERE id = @id";  
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", task.id_); 

                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteCompletedTasks()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "DELETE FROM tasks WHERE status = 1";
                MySqlCommand command = new MySqlCommand(query, conn);

                int rowsAffected = command.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
