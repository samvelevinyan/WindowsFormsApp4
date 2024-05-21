using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class InsertM
    {
        private string connectionString;
        public InsertM(string connString)
        {
            this.connectionString = connString;
        }
        public void AddNewGroup(string groupName, string year)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO groups (group_name, year, starosta, fizorg, note) VALUES (@GroupName, @year, 'Отсуствует', 'Отсуствует', 'Отсуствует')", connection);
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                cmd.Parameters.AddWithValue("@year", year);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Группа добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении группы: " + ex.Message);
                }
            }
        }

        public void AddNewYear(string groupName, string year)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO groups (group_name, year) VALUES (@GroupName, @year)", connection);
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                cmd.Parameters.AddWithValue("@year", year);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Группа добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении группы: " + ex.Message);
                }
            }
        }

        public void AddStudent(string firstName, string lastName, string middleName, DateTime dateOfBirth, string gender, string address, string phone, string note, string telegram, int groupId)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string queryStudents = "INSERT INTO students (name, surname, patronymic) VALUES (@FirstName, @LastName, @MiddleName); select last_insert_id();";
                    string queryStudentInfo = "INSERT INTO student_info (student_id, dob, gender, address, phone, telegram, note) VALUES (@Student_ID, @DateOfBirth, @Gender, @Address, @Phone, @telegram, @Note);";
                    string queryStudentGroup = "INSERT INTO student_groups (student_id, group_id) VALUES (@Student_ID, @Group_ID);";

                    MySqlCommand cmd = new MySqlCommand(queryStudents, conn);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    int studentId = Convert.ToInt32(cmd.ExecuteScalar());

                    MySqlCommand cmdInfo = new MySqlCommand(queryStudentInfo, conn);
                    cmdInfo.Parameters.AddWithValue("@Student_ID", studentId);
                    cmdInfo.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmdInfo.Parameters.AddWithValue("@Gender", gender);
                    cmdInfo.Parameters.AddWithValue("@Address", address);
                    cmdInfo.Parameters.AddWithValue("@Phone", phone);
                    cmdInfo.Parameters.AddWithValue("@telegram", telegram);
                    cmdInfo.Parameters.AddWithValue("@Note", note);
                    cmdInfo.ExecuteNonQuery();

                    MySqlCommand cmdGroup = new MySqlCommand(queryStudentGroup, conn);
                    cmdGroup.Parameters.AddWithValue("@Student_ID", studentId);
                    cmdGroup.Parameters.AddWithValue("@Group_ID", groupId);
                    cmdGroup.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении студента и информации о нём: " + ex.Message);
                }
                conn.Close();
            }

        }

        public void AddParentToStudent(int studentId, string fullName, string role, string address, string workplace, string position, string workPhone, string homePhone, string telegram, string note)
        {
            // Строка подключения к базе даных
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // Открыть соединение
                conn.Open();

                // Создание нового родителя в таблице 'parents'
                string queryAddParent = @"
            INSERT INTO parents (name, role, address, workplace, position, work_phone, home_phone, telegram, note)
            VALUES (@FullName, @role, @Address, @Workplace, @Position, @WorkPhone, @HomePhone, @tell, @Note);
            SELECT LAST_INSERT_ID();"; // Получить ID нового родителя

                MySqlCommand cmdAddParent = new MySqlCommand(queryAddParent, conn);
                cmdAddParent.Parameters.AddWithValue("@FullName", fullName);
                cmdAddParent.Parameters.AddWithValue("@role", role);
                cmdAddParent.Parameters.AddWithValue("@Address", address);
                cmdAddParent.Parameters.AddWithValue("@Workplace", workplace);
                cmdAddParent.Parameters.AddWithValue("@Position", position);
                cmdAddParent.Parameters.AddWithValue("@WorkPhone", workPhone);
                cmdAddParent.Parameters.AddWithValue("@HomePhone", homePhone);
                cmdAddParent.Parameters.AddWithValue("@tell", telegram);
                cmdAddParent.Parameters.AddWithValue("@Note", note);

                int parentId;
                try
                {
                    // Выполнить команду и получить ID родителя
                    parentId = Convert.ToInt32(cmdAddParent.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении родителя: " + ex.Message);
                    return;
                }

                // Связывание нового родителя со студентом в таблице 'studentparents'
                string queryLinkParentToStudent = @"
            INSERT INTO studentparents (StudentID, ParentID)
            VALUES (@StudentID, @ParentID);";

                MySqlCommand cmdLinkParentToStudent = new MySqlCommand(queryLinkParentToStudent, conn);
                cmdLinkParentToStudent.Parameters.AddWithValue("@StudentID", studentId);
                cmdLinkParentToStudent.Parameters.AddWithValue("@ParentID", parentId);

                try
                {
                    // Выполнить команду для связывания
                    cmdLinkParentToStudent.ExecuteNonQuery();
                    MessageBox.Show("Родитель успешно добавлен и связан со студентом.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при связывании родителя со студентом: " + ex.Message);
                }
            }
        }

        public void Teacher(string fio, string login, string pass, bool admin, bool moderator, bool viewer)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query1 = @"
              INSERT INTO teachers (name, username, password)
              VALUES (@fs, @un, @p);
              SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                cmd.Parameters.AddWithValue("@fs", fio);
                cmd.Parameters.AddWithValue("@un", login);
                cmd.Parameters.AddWithValue("@p", pass);


                int ttId;


                try
                {
                    ttId = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                    return;
                }

                string queryLink = @"
            INSERT INTO roles (teacher_id, isAdmin, isModerator, isViewer)
            VALUES (@ti, @a, @m, @v);";

                MySqlCommand cmdLink = new MySqlCommand(queryLink, connection);
                cmdLink.Parameters.AddWithValue("@ti", ttId);
                cmdLink.Parameters.AddWithValue("@a", admin);
                cmdLink.Parameters.AddWithValue("@m", moderator);
                cmdLink.Parameters.AddWithValue("@v", viewer);

                try
                {
                    // Выполнить команду для связывания
                    cmdLink.ExecuteNonQuery();
                    MessageBox.Show("Родитель успешно добавлен и связан со студентом.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при связывании родителя со студентом: " + ex.Message);
                }
            }
        }

        public void WorkWithParent(int parentID, int studentID, string type, string text)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO workswithparents (parent_id, student_id, type, text) VALUES (@parentid, @studentid, @type, @text)", connection);
                cmd.Parameters.AddWithValue("@parentid", parentID);
                cmd.Parameters.AddWithValue("@studentid", studentID);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@text", text);


                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                }
            }
        }

        public void Penalties(int studentID, DateTime date, string description)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO penaltiesandincentives (student_id, date, description) VALUES (@studentid, @date, @des)", connection);
                cmd.Parameters.AddWithValue("@studentid", studentID);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@des", description);


                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                }
            }
        }

        public void Individual(int studentID, DateTime date, string description)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO individual_work (student_id, date, description) VALUES (@studentid, @date, @des)", connection);
                cmd.Parameters.AddWithValue("@studentid", studentID);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@des", description);


                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                }
            }
        }

        public void PlanCalendar(int groupID, DateTime dateStart, DateTime dateEnd, string ispolnitel, string description, string result, string protokol, string comment)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO calendar_plan (group_id, date_start, date_end, ispolnitel, description, result, protokol_number, comment) VALUES (@gid, @dates, @datee, @is, @des, @res, @pr, @com)", connection);
                cmd.Parameters.AddWithValue("@gid", groupID);
                cmd.Parameters.AddWithValue("@dates", dateStart);
                cmd.Parameters.AddWithValue("@datee", dateEnd);
                cmd.Parameters.AddWithValue("@is", ispolnitel);
                cmd.Parameters.AddWithValue("@des", description);
                cmd.Parameters.AddWithValue("@res", result);
                cmd.Parameters.AddWithValue("@pr", protokol);
                cmd.Parameters.AddWithValue("@com", comment);


                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                }
            }
        }

        
    }
}
