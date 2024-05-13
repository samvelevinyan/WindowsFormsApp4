using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{

    internal class DeleteM
    {
        private string connectionString;
        public DeleteM(string connString)
        {
            this.connectionString = connString;
        }
        public void RemoveStudent(int studentId)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    
                    using (var transaction = conn.BeginTransaction())
                    {
                        string queryStudentGroup = "DELETE FROM student_groups WHERE student_id = @StudentID;";
                        MySqlCommand cmdStudentGroup = new MySqlCommand(queryStudentGroup, conn);
                        cmdStudentGroup.Parameters.AddWithValue("@StudentID", studentId);
                        cmdStudentGroup.ExecuteNonQuery();

                        string queryStudentInfo = "DELETE FROM student_info WHERE student_id = @StudentID;";
                        MySqlCommand cmdStudentInfo = new MySqlCommand(queryStudentInfo, conn);
                        cmdStudentInfo.Parameters.AddWithValue("@StudentID", studentId);
                        cmdStudentInfo.ExecuteNonQuery();

                        string queryStudents = "DELETE FROM students WHERE student_id = @StudentID;";
                        MySqlCommand cmdStudents = new MySqlCommand(queryStudents, conn);
                        cmdStudents.Parameters.AddWithValue("@StudentID", studentId);
                        cmdStudents.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // В случае ошибки откат всех операций
                    conn.Close();
                    MessageBox.Show($"Произошла ошибка удаления студента: {ex.Message}");
                    throw;
                }
            }
        }

        public void RemoveParentById(int parentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryRemoveParentLinks = "DELETE FROM studentparents WHERE ParentID = @ParentID;";
                        MySqlCommand cmdRemoveParentLinks = new MySqlCommand(queryRemoveParentLinks, conn);
                        cmdRemoveParentLinks.Parameters.AddWithValue("@ParentID", parentId);
                        cmdRemoveParentLinks.ExecuteNonQuery();

                        string queryRemoveParent = "DELETE FROM parents WHERE parent_id = @ParentID;";
                        MySqlCommand cmdRemoveParent = new MySqlCommand(queryRemoveParent, conn);
                        cmdRemoveParent.Parameters.AddWithValue("@ParentID", parentId);
                        cmdRemoveParent.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Родитель успешно удален.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ошибка при удалении родителя: " + ex.Message);
                    }
                }
            }
        }

        public void RemoveGroup(int groupId)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        string query = "DELETE FROM groups WHERE group_id = @group_id;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        cmd.ExecuteNonQuery();

                        string query2 = "DELETE FROM groupinfo WHERE group_id = @group_id;";
                        MySqlCommand cmd1 = new MySqlCommand(query2, conn);
                        cmd1.Parameters.AddWithValue("@group_id", groupId);
                        cmd1.ExecuteNonQuery();

                        string query3 = "DELETE FROM student_groups WHERE group_id = @group_id;";
                        MySqlCommand cmd2 = new MySqlCommand(query3, conn);
                        cmd2.Parameters.AddWithValue("@group_id", groupId);
                        cmd2.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    // В случае ошибки откат всех операций
                    conn.Close();
                    MessageBox.Show($"Произошла ошибка удаления студента: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
