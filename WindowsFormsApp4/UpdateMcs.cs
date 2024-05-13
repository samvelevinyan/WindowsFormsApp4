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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE students SET full_name = @student_name WHERE student_id = @studentID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@student_name", studentName);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "UPDATE parents SET full_name = @fio WHERE parent_id  = @parentID;";
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
                string query = "UPDATE teachers SET full_name = @fn WHERE teacher_id = @teacherID;";
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




    }
}
