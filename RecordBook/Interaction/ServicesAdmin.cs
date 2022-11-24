﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RecordBook.Interaction
{
    internal class ServicesAdmin
    {
        public static SaveFileDialog saveFileDialogBack = new SaveFileDialog();
        public static OpenFileDialog openFileDialogSQL = new OpenFileDialog();
        public static OpenFileDialog openFileDialogRes = new OpenFileDialog();

        // Мктод получения списка всех таблиц в БД
        // Удаление из этого списка системной диаграммы и таблицы Autorization,
        // если пользователь не является администратором
        // Выгрузка списка в comboBox
        public void DataTableAdmin()
        {
            if (FormMain.SQLStat != true)
                return;

            const string sql = "SELECT name FROM sys.objects WHERE type in (N'U')";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    List<string> names = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                        names.Add(row["name"].ToString());
                    names.Remove("sysdiagrams");
                    Program.formMain.comboBox.DataSource = names;
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
            comboBoxFilter(Program.formMain.comboBox.Text);
        }

        //Метод отображение и скрытие панелий с элементами соответсвующими каждой таблице
        public void Visibl()
        {
            foreach (var ctrl in Program.formMain.panelDefault.Controls)
                if (ctrl is Panel) (ctrl as Panel).Visible = false;
            Program.formMain.panelBackround.Visible = true;
            Program.formMain.panelDefault.Visible = true;
            /*switch (Program.formMain.comboBox.Text)
            {
                case "Employee":
                    Program.formMain.panelEmployee.Visible = true;
                    break;
                case "Programmer":
                    Program.formMain.panelProgrammer.Visible = true;
                    break;
                case "Task":
                    Program.formMain.panelTask.Visible = true;
                    break;
                case "Departament":
                    Program.formMain.panelDepartament.Visible = true;
                    break;
                case "Employee_Task":
                    Program.formMain.panelEmployee_Task.Visible = true;
                    break;
                case "Task_Programmer":
                    Program.formMain.panelTask_Programmer.Visible = true;
                    break;
                case "Autorization":
                    Program.formMain.panelAutorization.Visible = true;
                    break;
            }
            Program.formMain.toolStripStatusLabel2.Text = $"Выбрана таблица {Program.formMain.comboBox.Text}";*/
        }

        //Метод вызова панели загрузки
        public static void PanelLoad()
        {
            FormLoad formLoad = new FormLoad(null, null);
            formLoad.progressBar.Value = 0;
            formLoad.ShowDialog();
        }

        //Метод вывода содержимого таблицы БД в таблицу dataGridView1
        //Выбранная таблица определяется пользователем или находится по стандарту в comboBox
        //Вызов обновляет данные в dataGridView1 и сбрасывает выделенную строку
        public void ReloadEditingBD(string comboBox)
        {
            string sql = $"SELECT * FROM [{comboBox}]";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    Program.formMain.dataGridView1.DataSource = dataTable;
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
            FormMain.flagUpdateAdmin = false;
            FormMain.n = 0;
            Program.formMain.dataGridView1.ClearSelection();
        }

        //Функция получает массив разбытых данных из строки которая была выделенна
        public string[] ArrayUpdate()
        {
            int index = Program.formMain.dataGridView1.CurrentRow.Index;
            string[] array = new string[Program.formMain.dataGridView1.ColumnCount];
            for (int i = 0; i < Program.formMain.dataGridView1.ColumnCount; i++)
                array[i] = Program.formMain.dataGridView1.Rows[index].Cells[i].Value.ToString();
            return array;
        }

        //Метод который выгружает массив разбытых данных по соответсвующем TextBox
        public void TextViewTextBox(string[] array)
        {
            /*switch (Program.formMain.comboBox.Text)
            {
                case "Employee":
                    Program.formMain.textBox1.Text = $"{array[1].Trim()} {array[2].Trim()} {array[3].Trim()}";
                    Program.formMain.textBox4.Text = array[4];
                    Program.formMain.textBox5.Text = array[5];
                    Program.formMain.textBox6.Text = array[6];
                    Program.formMain.textBox7.Text = array[7];
                    break;
                case "Programmer":
                    Program.formMain.textBox13.Text = $"{array[1].Trim()} {array[2].Trim()} {array[3].Trim()}";
                    Program.formMain.textBox11.Text = array[4];
                    Program.formMain.textBox10.Text = array[5];
                    Program.formMain.textBox2.Text = array[6];
                    break;
                case "Task":
                    Program.formMain.textBox15.Text = array[1];
                    Program.formMain.textBox14.Text = array[2];
                    Program.formMain.textBox12.Text = array[3];
                    Program.formMain.textBox17.Text = array[4];
                    Program.formMain.textBox16.Text = array[5];
                    break;
                case "Departament":
                    Program.formMain.textBox9.Text = array[1];
                    Program.formMain.textBox8.Text = array[2];
                    Program.formMain.textBox3.Text = array[3];
                    break;
                case "Employee_Task":
                    Program.formMain.textBox25.Text = array[1];
                    Program.formMain.textBox22.Text = array[2];
                    break;
                case "Task_Programmer":
                    Program.formMain.textBox20.Text = array[1];
                    Program.formMain.textBox19.Text = array[2];
                    break;
                case "Autorization":
                    Program.formMain.textBox23.Text = array[1];
                    Program.formMain.textBox21.Text = array[2];
                    Program.formMain.comboBox1.Text = array[3];
                    break;
            }*/
        }

        //Метод выводит название всех столбцов выбранной таблицы в comboBox
        public void comboBoxFilter(string comboBox)
        {
            string sql = $"SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('{comboBox}')";
            using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
            {
                FormMain.connection.Open();
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    List<string> names = new List<string>();
                    foreach (DataRow row in dataTable.Rows)
                        names.Add(row["name"].ToString());
                    Program.formMain.comboBoxFilter.DataSource = names;
                    dataReader.Close();
                }
                FormMain.connection.Close();
            }
        }

        //Метод выполняет фильтрацию по выбранному столбцу с вписанным текстом
        //Если в пользовател не указал слово для фильтрации то выводятся все записи
        public void Filter(string comboBox, string comboBoxFilter)
        {
            try
            {
                string start = null;
                string end = null;
                if (Program.formMain.checkBoxStart.Checked == true)
                    start = "%";
                if (Program.formMain.checkBoxEnd.Checked == true)
                    end = "%";
                string sql = $"SELECT * FROM {comboBox} WHERE {comboBoxFilter} LIKE'{end}{Program.formMain.textBox18.Text}{start}'";
                using (SqlCommand sqlCommand = new SqlCommand(sql, FormMain.connection))
                {
                    FormMain.connection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Program.formMain.dataGridView1.DataSource = dataTable;
                        dataReader.Close();
                    }
                    Program.formMain.toolStripStatusLabel2.Text = "Фильтрация выполнена";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.formMain.toolStripStatusLabel2.Text = $"Ошибка! {ex.Message}";
            }
            finally
            {
                FormMain.connection.Close();
            }
        }

        //Сетод очищяает все TextBox начиная с panelDefault и все включенные в нее Controls.
        public void ClearStr()
        {
            foreach (var panelDefault in Program.formMain.panelDefault.Controls)
                if (panelDefault is Panel)
                    foreach (var panData in (panelDefault as Panel).Controls)
                        if (panData is Panel)
                        {
                            foreach (var panTextBox in (panData as Panel).Controls)
                                if (panTextBox is TextBox) (panTextBox as TextBox).Clear();
                        }
                        else if (panData is ComboBox) (panData as ComboBox).Text = null;
            Program.formMain.textBox18.Text = null;
        }
    }
}