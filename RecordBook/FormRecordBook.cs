using MaterialSkin;
using MaterialSkin.Controls;
using RecordBook.Interaction;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RecordBook
{
    public partial class FormRecordBook : MaterialForm
    {
        private readonly InteractionDataUser interactionDataUser = new InteractionDataUser();
        private readonly ServicesUser servicesUser = new ServicesUser();

        private string stdName;
        private int numStu;
        private int numDis;
        private bool flagEdit = false;

        public FormRecordBook(string name, int x)
        {
            Program.formRecordBook = this;

            InitializeComponent();

            stdName = name;
            numStu = x;

            new Thread(() =>
            {
                Action action = () =>
                {
                    var materialSkinManager = MaterialSkinManager.Instance;
                    materialSkinManager.AddFormToManage(this);
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey300, Primary.Grey900, Primary.Grey200, Accent.LightBlue200, TextShade.BLACK);
                };
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }).Start();
        }

        //Обработчик который выводит Ф.И.О. студента в поля при загрузке формы и количество сданных и не сданных дисцеплин
        private void FormRecordBook_Load(object sender, EventArgs e) => servicesUser.StudentInfoView(numStu, stdName);

        //Обработчик кнопки добавления строки в зачетку (вызов формы FromRecordBookAdd)
        private void buttonRecordBookAdd_Click(object sender, EventArgs e)
        {
            FormRecordBookAddUpdate formRecordBookAdd = new FormRecordBookAddUpdate(stdName, numStu, "Add");
            formRecordBookAdd.ShowDialog();
        }

        //Обработчик кнопки изменения выбранной строки в зачетки
        private void buttonRecordBookEdit_Click(object sender, EventArgs e)
        {
            if (flagEdit != true)
            {
                MessageBox.Show("Выберете дисцеплину для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormRecordBookAddUpdate formRecordBookEdit = new FormRecordBookAddUpdate(stdName, numStu, numDis, "Update");
            formRecordBookEdit.ShowDialog();
            flagEdit = false;
        }

        //Обработчик кнопки удаления выбранной строки в зачетке
        private void buttonRecordBookRemov_Click(object sender, EventArgs e)
        {
            if (flagEdit != true)
            {
                MessageBox.Show("Выберете дисцеплину для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            interactionDataUser.Remov(numStu, numDis);
            servicesUser.StudentInfoView(numStu, stdName);
            flagEdit = false;
        }

        //Обработчик вывоза формы для формироания зачетной книжки
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Обработчик двойного нажатия на строку с предметами в заечтке для ее выбора для дальнейшей работы с ней
        private void dataGridView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dataGridView3.Rows[dataGridView3.CurrentRow.Index].Selected = true;
            numDis = Convert.ToInt32(dataGridView3[0, dataGridView3.CurrentRow.Index].Value);
            flagEdit = true;
            toolStripStatusLabel2.Text = $"Выбранна дсицеплина {dataGridView3[1, dataGridView3.CurrentRow.Index].Value}";
        }

        //Обработчик выделеняи всей строки при нажатии на любую ячейку
        private void dataGridView3_SelectionChanged(object sender, MouseEventArgs e) => dataGridView3.Rows[dataGridView3.CurrentRow.Index].Selected = true;
    }
}