using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RecordBook.Interaction
{
    internal class ServicesUser
    {
        //Написать нывый sql запрос на вывод информации о студенте без
        //оценок и т.п. для ознакомления последних добавленных студентов.

        //Метод обновления информации в таблицах
        public void Reload()
        {
            string sql = $"SELECT Student.STUDENT_ID, Student.STUDENT_SURNAME, Student.STUDENT_NAME, Student.STUDENT_PATRONUMIC, STUDENT_NUM_RECORD_BOOK, GROUP_NAME, GROUP_SPECIALITIY"
                + " FROM Student, [Group], Train"
                + " WHERE Student.STUDENT_ID = Train.STUDENT_ID AND [Group].GROUP_ID = Train.GROUP_ID";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    Program.formMain.dataGridView2.DataSource = dataTable;
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
            Program.formMain.dataGridView2.ClearSelection();
        }

        //Метод который выгружает список специальностей c номерами в comboBox
        public void DataTableUserSpeciality(ComboBox comboBox)
        {
            if (FormMain.SQLStat != true)
                return;

            const string sql1 = "SELECT GROUP_SPECIALITIY, GROUP_NUMBER FROM [Group]";
            using (SqlCommand sqlCommand = new SqlCommand(sql1, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    List<string> names = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                        names.Add(row["GROUP_NUMBER"].ToString().Trim() + " | " + row["GROUP_SPECIALITIY"].ToString().Trim());
                    comboBox.DataSource = names.Distinct().ToList();
                    dataReader.Close();
                }
                FormMain.connection.Close();

            }
        }

        //Метод которой на основе выбранной сециальности в comboBox2 выгружает соответсвующие группы в cxomboBox
        public void DataTableUserGroupName(ComboBox comboBox, ComboBox comboBox1)
        {
            Regex regex = new Regex(@"\d\d.\d\d.\d\d\s[|]\s");
            string special = regex.Replace(comboBox.Text, "");

            string sql2 = $"SELECT GROUP_NAME FROM [Group] WHERE GROUP_SPECIALITIY = '{special}'";
            using (SqlCommand sqlCommand = new SqlCommand(sql2, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    List<string> names = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                        names.Add(row["GROUP_NAME"].ToString().Trim());
                    comboBox1.DataSource = names;
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
        }

        //Метод который выгружает список дисциплин в comboBox
        public void DataTableUserDiscipline(ComboBox comboBox, string type)
        {
            if (FormMain.SQLStat != true)
                return;

            string sql1 = $"SELECT DISCIPLINE_{type} FROM Discipline";
            using (SqlCommand sqlCommand = new SqlCommand(sql1, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    List<string> names = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                        names.Add(row[$"DISCIPLINE_{type}"].ToString().Trim());
                    comboBox.DataSource = names.Distinct().ToList();
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
        }

        //Метод поиска студетов в БД 
        public void StudentSearch()
        {
            Regex regex = new Regex(@"\d\d.\d\d.\d\d\s[|]\s");
            string special = regex.Replace(Program.formMain.comboBox2.Text, "");
            string sql = $"SELECT Student.STUDENT_ID, Student.STUDENT_SURNAME, Student.STUDENT_NAME, Student.STUDENT_PATRONUMIC, STUDENT_NUM_RECORD_BOOK, GROUP_NAME, GROUP_SPECIALITIY"
                + " FROM Student, [Group], Train"
                + $" WHERE Student.STUDENT_ID = Train.STUDENT_ID AND[Group].GROUP_ID = Train.GROUP_ID AND GROUP_NAME = '{Program.formMain.comboBox3.Text}' AND GROUP_SPECIALITIY = '{special}'";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    Program.formMain.dataGridView2.DataSource = dataTable;
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
        }

        //Функиця вывода информации о студенте в поля при двойном нажатии на запись в таблице
        public int[] StudentSelected(int n)
        {
            int[] credit = new int[2];
            string sql1 = "SELECT  COUNT(*) FROM Student, Change, Credit, Discipline"
                + " WHERE Student.STUDENT_ID = Change.STUDENT_ID AND Change.CREDIT_ID = Credit.CREDIT_ID AND Credit.DISCIPLINE_ID = Discipline.DISCIPLINE_ID"
                + $" AND Change.CHANGE_GRADE = 'Незачет' AND Student.STUDENT_ID = {n}";
            using (SqlCommand sqlCommand = new SqlCommand(sql1, FormMain.connection))
            {
                FormMain.connection.Open();
                credit[0] = Convert.ToInt32(sqlCommand.ExecuteScalar());
                FormMain.connection.Close();
            }

            string sql2 = "SELECT  COUNT(*)"
                + " FROM Student, Change, Credit, Discipline"
                + " WHERE Student.STUDENT_ID = Change.STUDENT_ID AND Change.CREDIT_ID = Credit.CREDIT_ID AND Credit.DISCIPLINE_ID = Discipline.DISCIPLINE_ID"
                + $" AND(Change.CHANGE_GRADE = '3' OR Change.CHANGE_GRADE = '4'  OR Change.CHANGE_GRADE = '5') AND Student.STUDENT_ID = {n}";
            using (SqlCommand sqlCommand = new SqlCommand(sql2, FormMain.connection))
            {
                FormMain.connection.Open();
                credit[1] = Convert.ToInt32(sqlCommand.ExecuteScalar());
                FormMain.connection.Close();
            }
            return credit;
        }

        //Функция вывода студентов у которых иммеются заодлжности с указанием их колличества
        public DataTable StudentDebtors(string name_group)
        {
            string sql = "SELECT Student.STUDENT_ID, Student.STUDENT_SURNAME, Student.STUDENT_NAME, Student.STUDENT_PATRONUMIC, Student.STUDENT_NUM_RECORD_BOOK, COUNT(*) AS 'Количество задолжностей'"
                + " FROM Student, Change, Credit, Discipline, [Group], Train"
                + " WHERE Student.STUDENT_ID = Change.STUDENT_ID AND Change.CREDIT_ID = Credit.CREDIT_ID AND Credit.DISCIPLINE_ID = Discipline.DISCIPLINE_ID"
                + " AND Student.STUDENT_ID = Train.STUDENT_ID AND Train.GROUP_ID = [Group].GROUP_ID"
                + $" AND Change.CHANGE_GRADE = 'Незачет' AND[Group].GROUP_NAME = '{name_group}'"
                + " GROUP BY Student.STUDENT_ID, Student.STUDENT_SURNAME, Student.STUDENT_NAME, Student.STUDENT_PATRONUMIC, Student.STUDENT_NUM_RECORD_BOOK";
            DataTable dataTable = new DataTable();
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    dataTable.Load(dataReader);
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
            return dataTable;
        }

        //Метод вызывает панель загрузки с параметрами для создания и документа
        public static void PanelLoad(string name_group)
        {
            FormLoad formLoad = new FormLoad(name_group, "excel");
            formLoad.progressBar.Value = 0;
            formLoad.ShowDialog();
        }

        //Функиця вывода всех дисцеплин которые соответсвуют указанному номеру студента в БД
        public DataTable Disciplines(int n)
        {
            DataTable dataTable;
            string sql = "SELECT DISCIPLINE_NAME, DISCIPLINE_SEMESTER, DISCIPLINE_TEACHER, CHANGE_GRADE"
                + " FROM Discipline, Student, Credit, Change"
                + " WHERE Student.STUDENT_ID = Change.STUDENT_ID AND Change.CREDIT_ID = Credit.CREDIT_ID AND Credit.DISCIPLINE_ID = Discipline.DISCIPLINE_ID"
                + $" AND Student.STUDENT_ID = {n}";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
            return dataTable;
        }
    }
}
