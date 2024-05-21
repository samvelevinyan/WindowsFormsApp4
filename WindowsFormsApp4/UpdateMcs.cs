using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class UpdateMcs
    {
        private string connectionString;

        public UpdateMcs(string connString)
        {
            this.connectionString = connString;
        }

        public void Starosta(string starosta, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE groups SET starosta = @Starosta WHERE group_id = @GroupID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Starosta", starosta);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void note(string note, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE groups SET note = @note WHERE group_id = @GroupID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("note", note);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Fizorg(string fizorg, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE groups SET fizorg = @fizorg WHERE group_id = @GroupID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("fizorg", fizorg);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GroupYear(string year, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE groups SET year = @year WHERE group_id = @GroupID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GroupName(string groupName, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE groups SET group_name = @group_name WHERE group_id = @GroupID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@group_name", groupName);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentName(string studentName, int studentID)
        {
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите изменить имя выбранного студента(id{studentID}) на {studentName}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Обработка выбора пользователя
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE students SET name = @student_name WHERE student_id = @studentID;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@student_name", studentName);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (result == DialogResult.No)
            {
                return;
            }

        }

        public void StudentSurname(string studentSurname, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE students SET surname = @student_Surname WHERE student_id = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@student_Surname", studentSurname);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentPatronymic(string studentPatronymic, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE students SET patronymic = @student_patronymic WHERE student_id = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@student_patronymic", studentPatronymic);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены ", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentInfoDOB(DateTime dateTime, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE student_info SET dob = @dob WHERE student_id = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dob", dateTime);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentInfoGender(string gender, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE student_info SET gender = @gender WHERE student_id  = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentInfoAddress(string address, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE student_info SET address = @address WHERE student_id  = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentInfoPhone(string phone, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE student_info SET phone = @phone WHERE student_id  = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void StudentInfoNote(string note, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE student_info SET note = @note WHERE student_id  = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoFIO(string fio, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET name = @fio WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fio", fio);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoRole(string role, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET role = @role WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoAddress(string address, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET address = @adr WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@adr", address);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoWorkPlace(string workplace, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET workplace = @w WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@w", workplace);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoPosition(string position, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET position = @pos WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pos", position);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoWorkNumber(string workNumber, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET wokr_number = @wn WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@wn", workNumber);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoHomeNumber(string HomeNumber, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET home_phone = @hn WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hn", HomeNumber);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ParentInfoNote(string note, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE parents SET note = @note WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void WorkWithParentType(string type, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE workswithparents SET type = @t WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@t", type);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void WorkWithParentText(string text, int parentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE workswithparents SET text = @tt WHERE parent_id  = @parentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tt", text);
                cmd.Parameters.AddWithValue("@parentID", parentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PenaltDate(DateTime date, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE penaltiesandincentives SET date = @d WHERE student_id  = @sID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@sID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PenaltDescr(string descr, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE penaltiesandincentives SET description = @des WHERE student_id  = @sID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", descr);
                cmd.Parameters.AddWithValue("@sID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void IndividualDate(DateTime date, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE individual_work SET date = @d WHERE student_id  = @sID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@sID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void IndividualDescr(string descr, int studentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE individual_work SET description = @des WHERE student_id  = @sID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", descr);
                cmd.Parameters.AddWithValue("@sID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PlatDateStart(DateTime date, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE calendar_plan SET date_start = @des WHERE group_id  = @gID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", date);
                cmd.Parameters.AddWithValue("@gID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PlatDateEnd(DateTime date, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE calendar_plan SET date_end = @des WHERE group_id  = @gID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", date);
                cmd.Parameters.AddWithValue("@gID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PlanIspolnitel(string ispolnitel, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE calendar_plan SET ispolnitel = @des WHERE group_id  = @gID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", ispolnitel);
                cmd.Parameters.AddWithValue("@gID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PlanResult(string result, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE calendar_plan SET result = @des WHERE group_id  = @gID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", result);
                cmd.Parameters.AddWithValue("@gID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PlanProtokol(string protokol, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE calendar_plan SET protokol_number = @des WHERE group_id  = @gID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", protokol);
                cmd.Parameters.AddWithValue("@gID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PlanComment(string comment, int groupID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE calendar_plan SET comment = @des WHERE group_id  = @gID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@des", comment);
                cmd.Parameters.AddWithValue("@gID", groupID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TeacherFIO(string fio, int teacherID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE teachers SET name = @fn WHERE teacher_id = @teacherID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("fn", fio);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TeacherLogin(string login, int teacherID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE teachers SET username = @us WHERE teacher_id = @teacherID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("us", login);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TeacherPass(string pass, int teacherID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE teachers SET password = @p WHERE teacher_id = @teacherID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("p", pass);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TeacherRoleAdmin(bool admin, int teacherID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE roles SET isAdmin = @p WHERE teacher_id = @teacherID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("p", admin);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TeacherRoleModer(bool moder, int teacherID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE roles SET isModerator = @p WHERE teacher_id = @teacherID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("p", moder);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TeacherRoleViewer(bool viewer, int teacherID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE roles SET isViewer = @p WHERE teacher_id = @teacherID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("p", viewer);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdateStudentInfos(int studentID, string name, string surname, string patronymic, DateTime date, string gender, string address, string phonet, string telegram, string note)
        {
            bool hasStudentUpdates = false;
            bool hasStudentInfoUpdates = false;
            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string studentQuery = "UPDATE students SET ";
            MySqlCommand studentCmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(name))
            {
                studentQuery += "name = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", name);
                hasStudentUpdates = true;
                elementsToChange += "Имя, ";
            }
            if (!string.IsNullOrEmpty(surname))
            {
                studentQuery += "surname = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", surname);
                hasStudentUpdates = true;
                elementsToChange += "Фамилия, ";
            }
            if (!string.IsNullOrEmpty(patronymic))
            {
                studentQuery += "patronymic = @part, ";
                studentCmd.Parameters.AddWithValue("@part", patronymic);
                hasStudentUpdates = true;
                elementsToChange += "Отчество, ";
            }

            // Запрос для обновления таблицы student_info
            string studentInfoQuery = "UPDATE student_info SET ";
            MySqlCommand studentInfoCmd = new MySqlCommand();

            if (!IsToday(date))
            {
                studentInfoQuery += "dob = @date_of_birth, ";
                studentInfoCmd.Parameters.AddWithValue("@date_of_birth", date);
                hasStudentInfoUpdates = true;
                elementsToChange += "Дата рождения, ";
            }
            if (!string.IsNullOrEmpty(gender))
            {
                studentInfoQuery += "gender = @gender, ";
                studentInfoCmd.Parameters.AddWithValue("@gender", gender);
                hasStudentInfoUpdates = true;
                elementsToChange += "Пол, ";
            }
            if (!string.IsNullOrEmpty(address))
            {
                studentInfoQuery += "address = @address, ";
                studentInfoCmd.Parameters.AddWithValue("@address", address);
                hasStudentInfoUpdates = true;
                elementsToChange += "Адрес, ";
            }
            if (!string.IsNullOrEmpty(phonet))
            {
                studentInfoQuery += "phone = @phone, ";
                studentInfoCmd.Parameters.AddWithValue("@phone", phonet);
                hasStudentInfoUpdates = true;
                elementsToChange += "Телефон, ";
            }
            if (!string.IsNullOrEmpty(telegram))
            {
                studentInfoQuery += "telegram = @phone, ";
                studentInfoCmd.Parameters.AddWithValue("@phone", telegram);
                hasStudentInfoUpdates = true;
                elementsToChange += "Телеграм, ";
            }
            if (!string.IsNullOrEmpty(note))
            {
                studentInfoQuery += "note = @notes, ";
                studentInfoCmd.Parameters.AddWithValue("@notes", note);
                hasStudentInfoUpdates = true;
                elementsToChange += "Примечание, ";
            }

            if (hasStudentUpdates || hasStudentInfoUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у студента под номером {studentID} элементы: {elementsToChange}";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasStudentUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        studentQuery = studentQuery.Substring(0, studentQuery.Length - 2);
                        studentQuery += " WHERE student_id = @id";
                        studentCmd.Parameters.AddWithValue("@id", studentID);

                        studentCmd.CommandText = studentQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице students: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                    if (hasStudentInfoUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        studentInfoQuery = studentInfoQuery.Substring(0, studentInfoQuery.Length - 2);
                        studentInfoQuery += " WHERE student_id = @student_id";
                        studentInfoCmd.Parameters.AddWithValue("@student_id", studentID);

                        studentInfoCmd.CommandText = studentInfoQuery;
                        studentInfoCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentInfoCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице student_info: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            if (!hasStudentUpdates && !hasStudentInfoUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }

            bool IsToday(DateTime datee)
            {
                DateTime today = DateTime.Today;
                return datee.Date == today;
            }

           
        }

        public void UpdateGroupInfo(int groupID, string groupName, string acYear, string starosta, string fizOrg, string note)
        {
            bool hasGroupUpdates = false;

            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string groupsQuery = "UPDATE groups SET ";
            MySqlCommand studentCmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(groupName))
            {
                groupsQuery += "group_name = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", groupName);
                hasGroupUpdates = true;
                elementsToChange += "Название группы, ";
            }
            if (!string.IsNullOrEmpty(acYear))
            {
                groupsQuery += "year = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", acYear);
                hasGroupUpdates = true;
                elementsToChange += "Академ.Год, ";
            }
            if (!string.IsNullOrEmpty(starosta))
            {
                groupsQuery += "starosta = @part, ";
                studentCmd.Parameters.AddWithValue("@part", starosta);
                hasGroupUpdates = true;
                elementsToChange += "Страроста, ";
            }

            if (!string.IsNullOrEmpty(fizOrg))
            {
                groupsQuery += "fizorg = @partt, ";
                studentCmd.Parameters.AddWithValue("@partt", fizOrg);
                hasGroupUpdates = true;
                elementsToChange += "ФизОрг, ";
            }

            if (!string.IsNullOrEmpty(note))
            {
                groupsQuery += "note = @parts, ";
                studentCmd.Parameters.AddWithValue("@parts", note);
                hasGroupUpdates = true;
                elementsToChange += "Заметка, ";
            }


            if (hasGroupUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у группы под номером {groupID} элементы: {elementsToChange}";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasGroupUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        groupsQuery = groupsQuery.Substring(0, groupsQuery.Length - 2);
                        groupsQuery += " WHERE group_id = @id";
                        studentCmd.Parameters.AddWithValue("@id", groupID);

                        studentCmd.CommandText = groupsQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице groups: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    return;
                }
            }

            if (!hasGroupUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }


        }

        public void UpdateParentInfo(int parentID, string fio, string role, string address, string work, string dolj, string tel, string tel2, string telegram, string note)
        {
            bool hasGroupUpdates = false;

            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string groupsQuery = "UPDATE parents SET ";
            MySqlCommand studentCmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(fio))
            {
                groupsQuery += "name = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", fio);
                hasGroupUpdates = true;
                elementsToChange += "ФИО, ";
            }
            if (!string.IsNullOrEmpty(role))
            {
                groupsQuery += "role = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", role);
                hasGroupUpdates = true;
                elementsToChange += "Роль, ";
            }
            if (!string.IsNullOrEmpty(address))
            {
                groupsQuery += "address = @part, ";
                studentCmd.Parameters.AddWithValue("@part", address);
                hasGroupUpdates = true;
                elementsToChange += "Адрес, ";
            }

            if (!string.IsNullOrEmpty(work))
            {
                groupsQuery += "workplace = @partt, ";
                studentCmd.Parameters.AddWithValue("@partt", work);
                hasGroupUpdates = true;
                elementsToChange += "Место работы, ";
            }

            if (!string.IsNullOrEmpty(dolj))
            {
                groupsQuery += "position = @partsss, ";
                studentCmd.Parameters.AddWithValue("@partsss", dolj);
                hasGroupUpdates = true;
                elementsToChange += "Должность, ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                groupsQuery += "work_phone = @p, ";
                studentCmd.Parameters.AddWithValue("@p", tel);
                hasGroupUpdates = true;
                elementsToChange += "Рабочий телефон, ";
            }
            if (!string.IsNullOrEmpty(tel2))
            {
                groupsQuery += "home_phone = @parats, ";
                studentCmd.Parameters.AddWithValue("@parats", tel2);
                hasGroupUpdates = true;
                elementsToChange += "Дом.Телефон, ";
            }
            if (!string.IsNullOrEmpty(telegram))
            {
                groupsQuery += "telegram = @paarts, ";
                studentCmd.Parameters.AddWithValue("@paarts", telegram);
                hasGroupUpdates = true;
                elementsToChange += "Телеграм, ";
            }
            if (!string.IsNullOrEmpty(note))
            {
                groupsQuery += "note = @paarts, ";
                studentCmd.Parameters.AddWithValue("@paarts", note);
                hasGroupUpdates = true;
                elementsToChange += "Заметка, ";
            }


            if (hasGroupUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у родителя под номером {parentID} элементы: {elementsToChange}";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasGroupUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        groupsQuery = groupsQuery.Substring(0, groupsQuery.Length - 2);
                        groupsQuery += " WHERE parent_id = @id";
                        studentCmd.Parameters.AddWithValue("@id", parentID);

                        studentCmd.CommandText = groupsQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице parents: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    return;
                }
            }

            if (!hasGroupUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }

            bool IsMaskedTextBoxEmpty(MaskedTextBox maskedTextBox)
            {
                // Возвращаем формат только вводимого текста (без символов маски)
                maskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                // Проверяем, не пуст ли текст
                bool isEmpty = string.IsNullOrWhiteSpace(maskedTextBox.Text);

                // Восстанавливаем формат маски
                maskedTextBox.TextMaskFormat = MaskFormat.IncludeLiterals;

                return isEmpty;
            }

        }

        public void UpdateWorkWithParentsInfo(int workid, string type, string text)
        {
            bool hasGroupUpdates = false;

            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string groupsQuery = "UPDATE workswithparents SET ";
            MySqlCommand studentCmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(type))
            {
                groupsQuery += "type = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", type);
                hasGroupUpdates = true;
                elementsToChange += "Вид работы, ";
            }
            if (!string.IsNullOrEmpty(text))
            {
                groupsQuery += "text = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", text);
                hasGroupUpdates = true;
                elementsToChange += "Примечание, ";
            }


            if (hasGroupUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у записи под номером {workid} элементы: {elementsToChange}";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasGroupUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        groupsQuery = groupsQuery.Substring(0, groupsQuery.Length - 2);
                        groupsQuery += " WHERE work_id = @id";
                        studentCmd.Parameters.AddWithValue("@id", workid);

                        studentCmd.CommandText = groupsQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице groups: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    return;
                }
            }

            if (!hasGroupUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }



        }

        public void UpdatePenaltinfo(int infoid, int studentid, DateTime date, string text)
        {
            bool hasGroupUpdates = false;

            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string groupsQuery = "UPDATE penaltiesandincentives SET ";
            MySqlCommand studentCmd = new MySqlCommand();


            if (!IsToday(date))
            {
                groupsQuery += "date = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", date);
                hasGroupUpdates = true;
                elementsToChange += "Дата, ";
            }
            if (!string.IsNullOrEmpty(text))
            {
                groupsQuery += "description = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", text);
                hasGroupUpdates = true;
                elementsToChange += "Описание, ";
            }


            if (hasGroupUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у записи №{infoid} и студента №{studentid} элементы: {elementsToChange}?";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasGroupUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        groupsQuery = groupsQuery.Substring(0, groupsQuery.Length - 2);
                        groupsQuery += " WHERE work_id = @id AND student_id = @si";
                        studentCmd.Parameters.AddWithValue("@id", infoid);
                        studentCmd.Parameters.AddWithValue("@si", studentid);

                        studentCmd.CommandText = groupsQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице groups: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    return;
                }
            }

            if (!hasGroupUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }

            bool IsToday(DateTime datee)
            {
                DateTime today = DateTime.Today;
                return datee.Date == today;
            }


        }

        public void UpdateIndWorkinfo(int workid, int studentid, DateTime date, string text)
        {
            bool hasGroupUpdates = false;

            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string groupsQuery = "UPDATE individual_work SET ";
            MySqlCommand studentCmd = new MySqlCommand();


            if (!IsToday(date))
            {
                groupsQuery += "date = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", date);
                hasGroupUpdates = true;
                elementsToChange += "Дата, ";
            }
            if (!string.IsNullOrEmpty(text))
            {
                groupsQuery += "description = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", text);
                hasGroupUpdates = true;
                elementsToChange += "Описание, ";
            }


            if (hasGroupUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить у  студента №{studentid} элементы: {elementsToChange}?";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasGroupUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        groupsQuery = groupsQuery.Substring(0, groupsQuery.Length - 2);
                        groupsQuery += " WHERE work_id = @id AND student_id = @si";
                        studentCmd.Parameters.AddWithValue("@id", workid);
                        studentCmd.Parameters.AddWithValue("@si", studentid);

                        studentCmd.CommandText = groupsQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице groups: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    return;
                }
            }

            if (!hasGroupUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }

            bool IsToday(DateTime datee)
            {
                DateTime today = DateTime.Today;
                return datee.Date == today;
            }


        }

        public void UpdatePlanCalendar(int infoid, DateTime datestart, DateTime dateend, string isoplnitel, string descr, string result, string protokolnumber, string text)
        {
            bool hasGroupUpdates = false;

            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string groupsQuery = "UPDATE calendar_plan SET ";
            MySqlCommand studentCmd = new MySqlCommand();

            groupsQuery += "date_start = @first_name, ";
            studentCmd.Parameters.AddWithValue("@first_name", datestart);
            hasGroupUpdates = true;
            elementsToChange += "Дата(Начало), ";


            groupsQuery += "date_end = @first_namea, ";
            studentCmd.Parameters.AddWithValue("@first_namea", dateend);
            hasGroupUpdates = true;
            elementsToChange += "Дата(Конец), ";

            if (!string.IsNullOrEmpty(isoplnitel))
            {
                groupsQuery += "ispolnitel = @part, ";
                studentCmd.Parameters.AddWithValue("@part", isoplnitel);
                hasGroupUpdates = true;
                elementsToChange += "Исполнитель, ";
            }

            if (!string.IsNullOrEmpty(descr))
            {
                groupsQuery += "description = @partt, ";
                studentCmd.Parameters.AddWithValue("@partt", descr);
                hasGroupUpdates = true;
                elementsToChange += "Описание, ";
            }

            if (!string.IsNullOrEmpty(result))
            {
                groupsQuery += "result = @partsss, ";
                studentCmd.Parameters.AddWithValue("@partsss", result);
                hasGroupUpdates = true;
                elementsToChange += "Результат, ";
            }
            if (!string.IsNullOrEmpty(protokolnumber))
            {
                groupsQuery += "protokol_number = @p, ";
                studentCmd.Parameters.AddWithValue("@p", protokolnumber);
                hasGroupUpdates = true;
                elementsToChange += "Номер протокола, ";
            }
            if (!string.IsNullOrEmpty(text))
            {
                groupsQuery += "comment = @parats, ";
                studentCmd.Parameters.AddWithValue("@parats", text);
                hasGroupUpdates = true;
                elementsToChange += "Комментарий, ";
            }

            if (hasGroupUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у записи №{infoid} элементы: {elementsToChange}";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasGroupUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        groupsQuery = groupsQuery.Substring(0, groupsQuery.Length - 2);
                        groupsQuery += " WHERE plan_id = @id";
                        studentCmd.Parameters.AddWithValue("@id", infoid);

                        studentCmd.CommandText = groupsQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице parents: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    return;
                }
            }

            if (!hasGroupUpdates)
            {
                MessageBox.Show("Нет данных для обновления.");
            }
        }

            public void UpdateTeacherInfo(int tid, string fio, string login, string pass, bool admim, bool moder, bool viewer)
            {
            bool hasStudentUpdates = false;
            bool hasStudentInfoUpdates = false;
            string elementsToChange = "";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Запрос для обновления таблицы students
            string studentQuery = "UPDATE teachers SET ";
            MySqlCommand studentCmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(fio))
            {
                studentQuery += "name = @first_name, ";
                studentCmd.Parameters.AddWithValue("@first_name", fio);
                hasStudentUpdates = true;
                elementsToChange += "ФИО, ";
            }
            if (!string.IsNullOrEmpty(login))
            {
                studentQuery += "username = @last_name, ";
                studentCmd.Parameters.AddWithValue("@last_name", login);
                hasStudentUpdates = true;
                elementsToChange += "Логин, ";
            }
            if (!string.IsNullOrEmpty(pass))
            {
                studentQuery += "patronymic = @part, ";
                studentCmd.Parameters.AddWithValue("@part", pass);
                hasStudentUpdates = true;
                elementsToChange += "Пароль, ";
            }

            // Запрос для обновления таблицы student_info
            string studentInfoQuery = "UPDATE roles SET ";
            MySqlCommand studentInfoCmd = new MySqlCommand();

                studentInfoQuery += "isAdmin = @date_of_birth, ";
                studentInfoCmd.Parameters.AddWithValue("@date_of_birth", admim);
                hasStudentInfoUpdates = true;
                elementsToChange += "Роль Админа, ";
            
            
                studentInfoQuery += "isAdmin = @gender, ";
                studentInfoCmd.Parameters.AddWithValue("@gender", moder);
                hasStudentInfoUpdates = true;
                elementsToChange += "Роль на редактирование, ";
            
            
                studentInfoQuery += "isViewer = @address, ";
                studentInfoCmd.Parameters.AddWithValue("@address", viewer);
                hasStudentInfoUpdates = true;
                elementsToChange += "Роль на просмотр, ";
            
            
            if (hasStudentUpdates || hasStudentInfoUpdates)
            {
                elementsToChange = elementsToChange.Substring(0, elementsToChange.Length - 2);
                string confirmationMessage = $"Вы уверены, что хотите изменить следующие элементы у учителя под номером {tid} элементы: {elementsToChange}";
                DialogResult confirmationResult = MessageBox.Show(confirmationMessage, "Подтверждение изменений", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    if (hasStudentUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        studentQuery = studentQuery.Substring(0, studentQuery.Length - 2);
                        studentQuery += " WHERE teacher_id = @id";
                        studentCmd.Parameters.AddWithValue("@id", tid);

                        studentCmd.CommandText = studentQuery;
                        studentCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице students: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                    if (hasStudentInfoUpdates)
                    {
                        // Удаляем последнюю запятую и добавляем WHERE условие
                        studentInfoQuery = studentInfoQuery.Substring(0, studentInfoQuery.Length - 2);
                        studentInfoQuery += " WHERE teacher_id = @student_id";
                        studentInfoCmd.Parameters.AddWithValue("@student_id", tid);

                        studentInfoCmd.CommandText = studentInfoQuery;
                        studentInfoCmd.Connection = connection;

                        connection.Open();
                        try
                        {
                            studentInfoCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно обновлены.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при обновлении данных в таблице student_info: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            if (!hasStudentUpdates && !hasStudentInfoUpdates)
              MessageBox.Show("Нет данных для обновления.");
            

           

        }
    }
}
