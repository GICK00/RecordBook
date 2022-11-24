using System;
using System.Data;
using System.Data.SqlClient;

namespace RecordBook.Interaction
{
    internal class InteractionDataUser
    {
        private readonly ServicesUser servicesUser = new ServicesUser();

        public void AddStudent(string action, int numStu)
        {
            try
            {
                FormMain.connection.Open();
                string sql = "Data" + action;
                using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@DISCIPLINE_NAME", SqlDbType.NChar, 80));
                    sqlCommand.Parameters["@DISCIPLINE_NAME"].Value = Program.formRecordBookAdd.textBox1.Text.Trim();

                    sqlCommand.Parameters.Add(new SqlParameter("@DISCIPLINE_TEACHER", SqlDbType.NVarChar, 40));
                    sqlCommand.Parameters["@DISCIPLINE_TEACHER"].Value = Program.formRecordBookAdd.textBox2.Text.Trim();

                    sqlCommand.Parameters.Add(new SqlParameter("@CREDIT_DATE", SqlDbType.Date));
                    sqlCommand.Parameters["@CREDIT_DATE"].Value = Program.formRecordBookAdd.textBox3.Text.Trim();

                    sqlCommand.Parameters.Add(new SqlParameter("@DISCIPLINE_SEMESTER", SqlDbType.Int));
                    sqlCommand.Parameters["@DISCIPLINE_SEMESTER"].Value = Convert.ToInt32(Program.formRecordBookAdd.textBox18.Text);

                    sqlCommand.Parameters.Add(new SqlParameter("@CHANGE_GRADE", SqlDbType.NVarChar, 7));
                    sqlCommand.Parameters["@CHANGE_GRADE"].Value = Program.formRecordBookAdd.comboBox2.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@numStu", SqlDbType.Int));
                    sqlCommand.Parameters["@numStu"].Value = numStu;

                    sqlCommand.ExecuteNonQuery();
                    FormMain.connection.Close();

                    Program.formRecordBook.toolStripStatusLabel2.Text = $"Добавленна дисцеплина {Program.formRecordBookAdd.textBox1.Text}";
                }
            }
            catch (Exception ex)
            {
                Program.formMain.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
                Program.formRecordBook.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
                FormMain.connection.Close();
            }
        }

        public void UpdateStudent(string action, int numStu, int numDis)
        {
            try
            {
                FormMain.connection.Open();
                string sql = "Data" + action;
                using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@DISCIPLINE_NAME", SqlDbType.NChar, 80));
                    sqlCommand.Parameters["@DISCIPLINE_NAME"].Value = Program.formRecordBookAdd.textBox1.Text.Trim();

                    sqlCommand.Parameters.Add(new SqlParameter("@DISCIPLINE_TEACHER", SqlDbType.NVarChar, 40));
                    sqlCommand.Parameters["@DISCIPLINE_TEACHER"].Value = Program.formRecordBookAdd.textBox2.Text.Trim();

                    sqlCommand.Parameters.Add(new SqlParameter("@CREDIT_DATE", SqlDbType.Date));
                    sqlCommand.Parameters["@CREDIT_DATE"].Value = Program.formRecordBookAdd.textBox3.Text.Trim();

                    sqlCommand.Parameters.Add(new SqlParameter("@DISCIPLINE_SEMESTER", SqlDbType.Int));
                    sqlCommand.Parameters["@DISCIPLINE_SEMESTER"].Value = Convert.ToInt32(Program.formRecordBookAdd.textBox18.Text);

                    sqlCommand.Parameters.Add(new SqlParameter("@CHANGE_GRADE", SqlDbType.NVarChar, 7));
                    sqlCommand.Parameters["@CHANGE_GRADE"].Value = Program.formRecordBookAdd.comboBox2.Text;

                    sqlCommand.Parameters.Add(new SqlParameter("@numStu", SqlDbType.Int));
                    sqlCommand.Parameters["@numStu"].Value = numStu;
                    
                    sqlCommand.Parameters.Add(new SqlParameter("@numDis", SqlDbType.Int));
                    sqlCommand.Parameters["@numDis"].Value = numDis;

                    sqlCommand.ExecuteNonQuery();
                    FormMain.connection.Close();

                    Program.formRecordBook.toolStripStatusLabel2.Text = $"Обновленна дисцеплина {Program.formRecordBookAdd.textBox1.Text}";
                }
            }
            catch (Exception ex)
            {
                Program.formMain.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
                Program.formRecordBook.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
                FormMain.connection.Close();
            }
        }

        public void Remov(int numStu, int numDis)
        {
            try
            {
                FormMain.connection.Open(); 
                string sql = $"DELETE FROM Credit FROM Change\r\nWHERE DISCIPLINE_ID = @DisID AND Change.CREDIT_ID = Credit.CREDIT_ID AND Change.STUDENT_ID = @StuID";
                using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@DisID", SqlDbType.Int));
                    sqlCommand.Parameters["@DisID"].Value = numDis;

                    sqlCommand.Parameters.Add(new SqlParameter("@StuID", SqlDbType.Int));
                    sqlCommand.Parameters["@StuID"].Value = numStu;

                    sqlCommand.ExecuteNonQuery();
                }
                FormMain.connection.Close();

                Program.formRecordBook.toolStripStatusLabel2.Text = $"Данные удалены";
            }
            catch (Exception ex)
            {
                Program.formMain.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
                Program.formRecordBook.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
                FormMain.connection.Close();
            }
        }
    }
}