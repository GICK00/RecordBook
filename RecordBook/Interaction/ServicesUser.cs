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

        //Метод которой на основе выбранной сециальности в comboBox выгружает соответсвующие группы в comboBox
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

        //Метод поиска студетов в БД выбранной специальностью и группой в comboBox
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

        //Функиця вывода информации о студенте (Ф.И.О. количество сданных предметов, долгов) в поля при двойном нажатии на запись в таблице
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

        //Выводит информацию о студенте на форме зачетной книжки (FormRecordBook)
        public void StudentInfoView(int numStu, string stdName)
        {
            int[] credit = new int[2];
            credit = StudentSelected(numStu);

            Program.formRecordBook.label2.Text = $"Ф.И.О. Студента: {stdName}";
            Program.formRecordBook.label1.Text = $"Количество долгов: {credit[0]}";
            Program.formRecordBook.label4.Text = $"Количество сданных предметов: {credit[1]}";

            Program.formRecordBook.dataGridView3.DataSource = Disciplines(numStu);
            Program.formRecordBook.dataGridView3.ClearSelection();
        }

        //Функиця вывода всех дисцеплин которые соответсвуют указанному номеру студента в БД
        public DataTable Disciplines(int n)
        {
            DataTable dataTable;
            string sql = "SELECT Discipline.DISCIPLINE_ID, DISCIPLINE_NAME, DISCIPLINE_SEMESTER, DISCIPLINE_TEACHER, CHANGE_GRADE, CREDIT_DATE"
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

        //Функция которая возвращает true если в таблице с дисцеплина есть похожая запись (для не повторения их в таблице БД)
        public bool Discipline(string Name, string Teacher, int Semestr)
        {
            bool flag = true;
            string sql = $"SELECT * FROM Discipline WHERE '{Name.Trim()}' = DISCIPLINE_NAME AND '{Teacher.Trim()}' = DISCIPLINE_TEACHER AND {Semestr} = DISCIPLINE_SEMESTER";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dataReader.Close();
                    if (dataTable.Rows.Count == 0)
                        flag = false;
                }
                FormMain.connection.Close();
            }
            return flag;
        }

        //Метод вывода данные в textBox на форме FormRecordBookAdd при открытии формы для изменения
        public void UnloadingTextBox(int numStu, int numDis)
        {
            string sql = "SELECT DISCIPLINE_NAME, DISCIPLINE_SEMESTER, DISCIPLINE_TEACHER, CHANGE_GRADE, CREDIT_DATE"
                + " FROM Discipline, Student, Credit, Change"
                + " WHERE Student.STUDENT_ID = Change.STUDENT_ID AND Change.CREDIT_ID = Credit.CREDIT_ID AND Credit.DISCIPLINE_ID = Discipline.DISCIPLINE_ID"
                + $" AND Student.STUDENT_ID = {numStu} AND Discipline.DISCIPLINE_ID = {numDis}";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);

                    List<string> names = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                        names.Add(row["DISCIPLINE_NAME"].ToString() + "|"
                            + row["DISCIPLINE_SEMESTER"].ToString() + "|"
                            + row["DISCIPLINE_TEACHER"].ToString() + "|"
                            + row["CHANGE_GRADE"].ToString() + "|"
                            + row["CREDIT_DATE"].ToString());
                    dataReader.Close();

                    string[] dataMas = new string[5];
                    dataMas = names[0].Split('|');

                    Program.formRecordBookAdd.textBox1.Text = dataMas[0].Trim();
                    Program.formRecordBookAdd.textBox18.Text = dataMas[1].Trim();
                    Program.formRecordBookAdd.textBox2.Text = dataMas[2].Trim();
                    Program.formRecordBookAdd.comboBox2.Text = dataMas[3].Trim();
                    Program.formRecordBookAdd.textBox3.Text = dataMas[4].Trim();
                }
                FormMain.connection.Close();
            }
        }
    }
}
