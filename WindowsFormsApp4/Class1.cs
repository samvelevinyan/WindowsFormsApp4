using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp4
{
    internal class Class1
    {
        private string connectionString;


        public Class1(string connString)
        {
            this.connectionString = connString;
        }
        // string connectionString = "server=localhost;uid=root;pwd=root;database=fr;";


        public void LoadGroupsForYear(ComboBox combox, string year)
        {
            string query = "SELECT group_name FROM groups WHERE year = @year;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);


                    string targetYear = year;
                    command.Parameters.AddWithValue("@year", targetYear);

                    MySqlDataReader reader = command.ExecuteReader();

                    combox.Items.Clear(); // Очищаем ComboBox перед загрузкой новых данных.

                    while (reader.Read())
                    {
                        string groupInfo = $"{reader["group_name"]}";
                        combox.Items.Add(groupInfo);
                    }

                    if (combox.Items.Count == 0)
                    {
                        MessageBox.Show($"Группы за год {targetYear} не найдены.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка загрузги академических лет: {ex.Message}");
            }
        }

        public void LoadYears(ComboBox comboBox)
        {
            string query = "SELECT DISTINCT year FROM groups ORDER BY year DESC;";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    comboBox.Items.Clear();

                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["year"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}");
            }
        }



        public void LoadStudentsForGroup(DataGridView dataGridView, string groupName)
        {
            string query = "SELECT student_id, name FROM students WHERE group_name = @GroupName;";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GroupName", groupName);

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);

                    dataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}");
            }
        }

        public DataTable GetInfoByGroup(string groupName)
        {
            // SQL запрос для получения списка студентов по идентификатору группы

            string query = @"
            SELECT
                g.group_id,
                g.group_name AS ИмяГруппы,
                g.year AS Год, 
                g.starosta AS Староста,
                g.fizorg AS ФизОрг,
                g.note AS Примечание
            FROM
                groups g
            WHERE
                g.group_name = @GroupName";



            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    // Параметризация запроса для защиты от SQL инъекций
                    command.Parameters.AddWithValue("@GroupName", groupName);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки студентов: {ex.Message}");
            }
            return dt;
        }



        public DataTable GetStudentsByGroup(string groupName)
        {
            // SQL запрос для получения списка студентов по идентификатору группы

            string query = @"
            SELECT
                s.student_id,
                s.name AS Имя,
                s.surname AS Фамилия,
                s.patronymic AS Отчество,
                sf.dob AS ДатаРождения,
                sf.gender AS Пол,
                sf.address AS Адрес,
                sf.phone AS Телефон,
                sf.telegram AS Телеграм,
                sf.note AS Примечание
            FROM
                students s
            JOIN
                student_info sf ON s.student_id = sf.student_id
            JOIN
                student_groups sg ON s.student_id = sg.student_id
            JOIN
                groups g ON sg.group_id = g.group_id
            WHERE
                g.group_name = @GroupName";



            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    // Параметризация запроса для защиты от SQL инъекций
                    command.Parameters.AddWithValue("@GroupName", groupName);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading students: {ex.Message}");
            }
            return dt;
        }

        public DataTable GetSrudentParents(string groupName)
        {
            // SQL запрос для получения списка студентов по идентификатору группы

            string query = "SELECT g.group_name, s.name+' 's.surname+' 's.patronymic FROM students s JOIN student_groups sg ON s.student_id = sg.student_id JOIN groups g ON sg.student.id = g.group_id WHERE g.group_name = @GroupName;";

            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    // Параметризация запроса для защиты от SQL инъекций
                    command.Parameters.AddWithValue("@GroupName", groupName);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading students: {ex.Message}");
            }
            return dt;
        }

        public void LoadStudents(ComboBox combox, string groupName)
        {

            string query = "SELECT s.student_id, CONCAT(s.surname, ' ', s.name, ' ', s.patronymic) AS FullName FROM students s JOIN student_groups sg ON s.student_id = sg.student_id WHERE sg.group_id = @GroupID;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Введите целевой год

                    command.Parameters.AddWithValue("@GroupName", groupName);

                    MySqlDataReader reader = command.ExecuteReader();

                    combox.Items.Clear(); // Очищаем ComboBox перед загрузкой новых данных.

                    while (reader.Read())
                    {
                        string groupInfo = $"{reader["FullName"]}";
                        combox.Items.Add(groupInfo);
                    }

                    if (combox.Items.Count == 0)
                    {

                        MessageBox.Show($"Ученики группы {groupName} не найдены.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        public void FillComboBoxWithStudents(ComboBox comboBox, string groupName)
        {

            string query = @"
              SELECT
              s.student_id,
              CONCAT(s.surname, ' ', s.name, ' ', s.patronymic) AS FullName,
              g.group_name
              FROM
              students s
              JOIN student_groups sg ON s.student_id = sg.student_id
              JOIN groups g ON sg.group_id = g.group_id
              WHERE g.group_name = @GroupID
              ORDER BY g.group_name;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GroupID", groupName);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox.DisplayMember = "FullName"; // отображаемое имя
                    comboBox.ValueMember = "student_id"; // значение
                    comboBox.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        comboBox.DataSource = null;
                        comboBox.Items.Clear();
                        comboBox.Text = "";
                        MessageBox.Show("Данные о студентах не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);

                }
            }
        }

        public void FillComboBoxWithTeachers(ComboBox comboBox)
        {
            string query = @"
        SELECT
        t.teacher_id,
        t.name
        FROM teachers t";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Очистка текущих данных перед заливкой новых.
                    comboBox.Items.Clear();

                    // Проверка, содержит ли DataTable строки.
                    if (dt.Rows.Count > 0)
                    {
                        comboBox.DisplayMember = "name"; // Отображаемое имя
                        comboBox.ValueMember = "teacher_id"; // Значение
                        comboBox.DataSource = dt;
                    }
                    else
                    {
                        // Если данных нет, устанавливаем DataSource в null и выводим сообщение.
                        comboBox.DataSource = null;
                        comboBox.Text = "";
                        MessageBox.Show("Данные об учителях не найдены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FillComboBoxWithStudentsName(ComboBox comboBox, string groupName)
        {


            string query = @"
              SELECT
              s.student_id,
              s.surname,
              s.name,
              s.patronymic,
              g.group_name
              FROM
              students s
              JOIN student_groups sg ON s.student_id = sg.student_id
              JOIN groups g ON sg.group_id = g.group_id
              WHERE g.group_name = @GroupID
              ORDER BY g.group_name;";  // Обновленный запрос


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GroupID", groupName);
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox.Items.Clear();
                        while (reader.Read())
                        {
                            // Формируем полное имя, объединяя три части
                            string fullName = reader["name"].ToString() + " " +
                                              reader["surname"].ToString() + " " +
                                              reader["patronymic"].ToString();

                            comboBox.Items.Add(fullName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }

        }


        public void DisplayParentInfo(DataGridView dataGridView, int studentId)
        {

            string query = @"
            SELECT 
           p.parent_id AS РодительID,
           p.name AS ФИО,
           p.role AS Роль,
           p.address AS Адрес,
           p.workplace AS МестоРаботы,
           p.position AS Должность,
           p.work_phone AS РабочийНомер,
           p.home_phone AS ДомашнийНомер,
           p.note AS Примечание
           FROM parents p
           JOIN studentparents sp ON p.parent_id = sp.ParentID
           WHERE sp.StudentID = @StudentID;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {

                        MessageBox.Show("Данные о родителе не найдеты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }
        }

        public void DisplayWorkWithParentInfo(DataGridView dataGridView, int parentId)
        {

            string query = @"
            SELECT 
           w.work_id AS НомерРаботы,
           w.student_id AS НомерСтудента,
           w.parent_id AS НомерРодителя,
           w.type AS ТипОбщения,
           w.text AS ЧтоОбсуждалось
           FROM workswithparents w 
           WHERE w.parent_id = @ParentID;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ParentID", parentId);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Данные о записях работе с родителями не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных о работе с родителями: " + ex.Message);
                }
            }
        }
        public void DisplayPenalties(DataGridView dataGridView, int studentId)
        {

            string query = @"
                     SELECT 
                        p.info_id AS НомерЗаписи,
                        p.student_id AS НомерСтудента,
                        p.date AS Дата,
                         p.description AS ОписаниеСобытия
                     FROM penaltiesandincentives p
                     WHERE p.student_id = @StudentID;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Данные о записях взыскания и поощрения не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных о взыскании и поощрении: " + ex.Message);
                }
            }


        }
        public void DisplayIndividual(DataGridView dataGridView, int studentId)
        {

            string query = @"
                     SELECT 
                        p.work_id AS НомерЗаписи,
                        p.student_id AS НомерСтудента,
                        p.date AS Дата,
                        p.description AS ОписаниеСобытия
                     FROM individual_work p
                     WHERE p.student_id = @StudentID;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Данные о записях индивидуальной работы не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных об индивидуальных работах: " + ex.Message);
                }
            }
        }

        public void DisplayTeachers(DataGridView dataGridView)
        {

            string query = @"
                     SELECT 
                        t.teacher_id AS НомерУчителя,
                        t.name AS ФИОУчителя,
                        t.username AS Логин,
                        t.password AS Пароль,
                        r.isAdmin AS Админ,
                        r.isModerator AS Редактор,
                        r.isViewer AS Просмотр
                     FROM teachers t
                     JOIN roles r ON t.teacher_id = r.teacher_id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Данные об учителях не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных об индивидуальных работах: " + ex.Message);
                }
            }
        }



        public void DisplayPlanCalendar(DataGridView dataGridView, int groupID)
        {

            string query = @"
                     SELECT 
                        p.plan_id AS НомерПлана,
                        p.group_id AS НомерГруппы,
                        p.date_start AS ДатаНачало,
                        p.date_end AS ДатаКонец,
                        p.ispolnitel AS Исполнитель,
                        p.description AS Описание,
                        p.result AS ОжидаемыйРезультат,
                        p.protokol_number AS НомерПротокола,
                        p.comment AS Комментарий
                     FROM calendar_plan p
                     WHERE p.group_id = @groupID;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@groupID", groupID);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Данные о записях плана-календаря не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных о планах-календаря работах: " + ex.Message);
                }
            }
        }

        public int GetGroupIdByName(string groupName)
        {
            string query = "SELECT group_id FROM groups WHERE group_name = @groupName;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@groupName", groupName);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Не найдено совпадений, можно вернуть -1 или генерировать исключение.
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                return -1; // В случае ошибки базы данных возвращаем -1 или можно выбросить исключение.
            }
        }

        public void FillComboBoxWithParents(ComboBox comboBox, int studentID)
        {

            string query = @"
        SELECT
        p.parent_id,
        p.name
        FROM
        parents p
        JOIN studentparents sp ON p.parent_id = sp.ParentID
        WHERE sp.StudentID = @StudentID
        ORDER BY p.name;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                try
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox.DisplayMember = "name"; // отображаемое имя
                    comboBox.ValueMember = "parent_id"; // значение
                    comboBox.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        comboBox.DataSource = null;
                        comboBox.Items.Clear();
                        comboBox.Text = "";
                        MessageBox.Show("Данные о родителях не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);

                }
            }
        }

        }
    }

