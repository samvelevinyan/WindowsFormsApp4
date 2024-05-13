using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class PersonalData
    {
        private string connectionString;

        public int? UserId { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool IsEditor { get; private set; }
        public bool IsViewer { get; private set; }

        public PersonalData(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void LoadUser(string login)
        {
            UserId = GetUserIdByLogin(login);
            if (UserId.HasValue)
            {
                LoadRoles(UserId.Value);
            }
        }
       
        private int? GetUserIdByLogin(string login)
        {
            int? userId = null; // null значит, что пользователь не найден
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT teacher_id FROM teachers WHERE username = @Login";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);

                        // Выполняем запрос и читаем результат
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader.GetInt32("teacher_id"); // Извлекаем teacher_id
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
            return userId;
        }

        private void LoadRoles(int userId)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT isAdmin, isModerator, isViewer FROM roles WHERE teacher_id = @teacherId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@teacherId", userId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsAdmin = reader.GetBoolean("isAdmin");
                                IsEditor = reader.GetBoolean("isModerator");
                                IsViewer = reader.GetBoolean("isViewer");
                            }
                            else
                            {
                                ResetRoles();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка подключения: " + ex.Message);
            }
        }

        private void ResetRoles()
        {
            IsAdmin = false;
            IsEditor = false;
            IsViewer = false;
        }
    }

}

