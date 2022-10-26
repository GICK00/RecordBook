using MaterialSkin;
using MaterialSkin.Controls;
using RecordBook.Interaction;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace RecordBook
{
    public partial class FormMain : MaterialForm
    {
        public static SqlConnection connection;

        public static readonly MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private readonly InteractionData interactionData = new InteractionData();
        private readonly InteractionTool interactionTool = new InteractionTool();
        private readonly ServicesAdmin servicesAdmin = new ServicesAdmin();
        private readonly ServicesUser servicesUser = new ServicesUser();
        private readonly Tools tools = new Tools();

        private readonly FormRequest formRequest = new FormRequest();
        private readonly FormInfo formInfo = new FormInfo();
        private readonly FormLogin formLogin = new FormLogin();
        private readonly FormSettings formSettings = new FormSettings();
        private readonly FormDebtors formDebtors = new FormDebtors();

        public static bool SQLStat = false;
        public static string ver = "Ver. Alpha 0.1.0 R_B";

        public static bool flagUpdate = false;
        public static bool flagSelect = false;
        public static int n = 0;

        public FormMain()
        {
            Program.formMain = this;
            InitializeComponent();

            new Thread(() =>
            {
                Action action = () =>
                {
                    materialSkinManager.AddFormToManage(this);
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey300, Primary.Grey900, Primary.Grey200, Accent.LightBlue200, TextShade.BLACK);
                };
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }).Start();

            ServicesAdmin.saveFileDialogBack.Filter = "Bak files(*bak)|*bak";

            ServicesAdmin.openFileDialogSQL.Filter = "Sql files(*.sql)|*.sql| Text files(*.txt)|*.txt| All files(*.*)|*.*";
            ServicesAdmin.openFileDialogRes.Filter = "Bak files(*bak)|*bak";

            tools.UpdateApp();
            servicesAdmin.Visibl();
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (tools.CheckConfig() != true)
                return;
            ServicesAdmin.PanelLoad();
            if (tools.Test() != true)
                return;
            toolStripStatusLabel2.Text = "Готово к работе";
        }

        //
        //Кнопки формы на page для admin
        //

        //Обработчик проверки на привилегии учетной записи для переключения tabControl в режим для адимна (режим полного доступа над БД)
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tools.LoginAdmin() != true)
                e.Cancel = true;
        }

        //Обработчик обрабатывающий переключение таблиц в comboBox для дальнейшей работы с ними
        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            servicesAdmin.ClearStr();
            servicesAdmin.ReloadEditingBD(comboBox.Text);
            servicesAdmin.comboBoxFilter(comboBox.Text);
            servicesAdmin.Visibl();
        }

        //Обработчик добавления информации для выбранной таблицы в comboBox
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            interactionData.AddAndUpdate("Add");
        }

        //Обработчик изменения выбранной информации для выбранной таблицы в comboBox
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            interactionData.AddAndUpdate("Update");
        }

        //Обработчик поиска информации в выбранной таблицы в comboBox
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            FormDeletedAndSearch formDeletedAndSearch = new FormDeletedAndSearch("sea");
            formDeletedAndSearch.ShowDialog();
        }

        //Обработчик удаления информации в выбранной таблицы в comboBox
        private void buttonDeleted_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            FormDeletedAndSearch formDeletedAndSearch = new FormDeletedAndSearch("del");
            formDeletedAndSearch.ShowDialog();
        }

        //Обработчик обновления информации в dataGriedView (выгрузка информации из таблиц БД в dataGriedView)
        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            servicesAdmin.ReloadEditingBD(comboBox.Text);
        }

        //Обработчик очищения всех полей имеющихся на tabControl
        public void buttonClearStr_Click(object sender, EventArgs e) => servicesAdmin.ClearStr();

        //Обработчик фильтрации информации в таблице
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            servicesAdmin.Filter(comboBox.Text, comboBoxFilter.Text);
        }

        //
        //ToolStrip1 на page для admin
        //

        //Обработчик переподключения к БД
        private void buttonReconnection_Click(object sender, EventArgs e)
        {
            if (tools.CheckConfig() != true)
                return;
            Interaction.ServicesAdmin.PanelLoad();
            if (SQLStat != false)
            {
                MessageBox.Show("Подключение к базе данных установленно", "Проверка подключения", MessageBoxButtons.OK);
                toolStripStatusLabel2.Text = "Готово к работе";

                if (FormLogin.Login != null)
                {
                    servicesAdmin.DataTableAdmin();
                    servicesAdmin.Visibl();
                    servicesAdmin.ReloadEditingBD(comboBox.Text);
                    servicesUser.Reload();
                }
            }
            else
            {
                toolStripStatusLabel2.Text = $"Ошибка подключения к базе данных!";
                MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Обработчик открытия формы с информацией о приложени
        private void ButtonInfo_Click(object sender, EventArgs e) => formInfo.ShowDialog();

        //Обработчик проверки версии приложения (верся риложения находится на GitHub)
        private void ButtonUpdateApp_Click(object sender, EventArgs e) => tools.UpdateApp();

        //Обработчик открывает форму в которой можно выполнять запросы к БД (открывать существующие файлы или писать запрос в онне)
        private void выполнитьЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.CheckConfig() != true || tools.Test() != true)
                return;
            flagUpdate = false;
            n = 0;
            dataGridView1.ClearSelection();
            formRequest.ShowDialog();
        }

        //Обработчик очищающий строки данных во всех таблицах БД
        private void очиститьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.CheckConfig() != true || tools.Test() != true)
                return;
            flagUpdate = false;
            n = 0;
            dataGridView1.ClearSelection();
            interactionTool.очиститьБазуДанныхToolStripMenuItem();
        }

        //Обработчик создания полной резервной копии БД
        private void создатьРезервнуюКопиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServicesAdmin.saveFileDialogBack.FileName = "RecordBook.bak";
            if (tools.CheckConfig() != true || tools.Test() != true || ServicesAdmin.saveFileDialogBack.ShowDialog() == DialogResult.Cancel)
                return;
            interactionTool.создатьРезервнуюКопиюToolStripMenuItem();
        }

        //Обработчик восстановления резервной копии БД
        private void восстановитьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.CheckConfig() != true || tools.Test() != true)
                return;
            interactionTool.восстановитьБазуДанныхToolStripMenuItem();
        }

        //Обработчик открывающая форму авторизации
        private void войтиКакАдминистраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.CheckConfig() != true || tools.Test() != true)
                return;
            formLogin.ShowDialog();
        }

        //Обработчик выхода, полностью сбрасывает приложени (запрещает все функции) и производит выход из учетной записи
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormLogin.Login != null)
            {
                tabControl1.SelectTab(tabPage2);
                FormLogin.Login = null;
                this.Text = "Колледж инновационных технологий и предпринимательства";
                materialSkinManager.AddFormToManage(this);

                servicesAdmin.Visibl();

                comboBox.DataSource = null;
                comboBoxFilter.DataSource = null;
                dataGridView1.DataSource = null;
                flagUpdate = false;
                flagSelect = false;
                dataGridView1.ClearSelection();
                dataGridView1.Enabled = false;

                comboBox2.DataSource = null;
                comboBox3.DataSource = null;
                dataGridView2.DataSource = null;
                dataGridView2.ClearSelection();
                dataGridView2.Enabled = false;

                label2.Text = "Ф.И.О. Студента:";
                label1.Text = "Количество долгов:";
                label4.Text = "Количество сданных предметов:";

                toolStripStatusLabel2.Text = "Произведен выход из системы";
                return;
            }
            MessageBox.Show("Не выполнен вход в систему!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Обработчик открывающий форму настроек БД (в ней можно прописать строку подключения к БД)
        private void toolStripButtonSettings_Click(object sender, EventArgs e) => formSettings.ShowDialog();

        //
        //DataGridView1 на page для admin
        //

        //Обработчик обрабатывающий двойное нажатие на строку в dataGridView на tabControl для админов
        private void dataGridView1_MouseDoubleClick(object sender, EventArgs e)
        {
            servicesAdmin.TextViewTextBox(servicesAdmin.ArrayUpdate());
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            flagUpdate = true;

            toolStripStatusLabel2.Text = $"Выбрана строка № {(dataGridView1.CurrentRow.Index + 1)}";
        }

        //Обработчик который просто выделяет всю строку при выделени одной ячейи
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
            n = dataGridView1.CurrentRow.Index;
        }

        //
        //Кнопки формы на page для user
        //

        //Обработчик вызова формы в которой находятся все сведения об студенте по предметам
        private void buttonRecordBook_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true || tools.LoginGuest() != true || flagSelect != true)
                return;
            string stdName = $" {dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString().Trim()} {dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString().Trim()} {dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString().Trim()}";
            FormRecordBook formRecordBook = new FormRecordBook(stdName, Convert.ToInt32(dataGridView2[0, dataGridView2.CurrentRow.Index].Value));
            formRecordBook.ShowDialog();
        }

        //Обработчик обрабатывающий переключение специальностей в comboBox2 для сортировки студетов
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            servicesUser.DataTableUserGroupName(comboBox2, comboBox3);
        }

        //Обработчик фильтрации студентов 
        private void buttonSearchStud_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true || (tools.LoginGuest() != true))
                return;
            servicesUser.StudentSearch();
        }

        //
        //ToolStrip3 на page для user
        //

        //Обработчик откывает форму формирования отчета о должниках по специмальностям
        private void создатьСправкуОПересдачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true || (tools.LoginGuest() != true))
                return;
            formDebtors.ShowDialog();
        }

        //
        //DataGridView2 на page для user
        //

        //Обработчик обрабатывающий двойное нажатие на строку в dataGridView на tabControl для пользователей
        private void dataGridView2_MouseDoubleClick(object sender, EventArgs e)
        {
            string stdName = $"{dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString().Trim()} {dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString().Trim()} {dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString().Trim()}";
            int[] credit = new int[2];
            credit = servicesUser.StudentSelected(Convert.ToInt32(dataGridView2[0, dataGridView2.CurrentRow.Index].Value));

            label2.Text = $"Ф.И.О. Студента: {stdName}";
            label1.Text = $"Количество долгов: {credit[0]}";
            label4.Text = $"Количество сданных предметов: {credit[1]}";

            dataGridView2.Rows[dataGridView2.CurrentRow.Index].Selected = true;
            flagSelect = true;

            toolStripStatusLabel2.Text = $"Выбран студент {stdName}";
        }

        //Обработчик который просто выделяет всю строку при выделени одной ячейи
        private void dataGridView2_SelectionChanged(object sender, EventArgs e) => dataGridView2.Rows[dataGridView2.CurrentRow.Index].Selected = true;











        //Обработчик вызова диалогового окна при закрытие главной формы приложения
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}