using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Threading;
using RecordBook.Interaction;

namespace RecordBook
{
    public partial class FormRecordBook : MaterialForm
    {
        private readonly ServicesUser servicesUser = new ServicesUser();
        private string stdName;
        private int n;

        public FormRecordBook(string name, int x)
        {
            stdName = name;
            n = x;

            InitializeComponent();

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

        private void FormRecordBook_Load(object sender, EventArgs e)
        {
            //Выводит ФИО студента в поля при загрузке формы и выводит все его экзамены
            int[] credit = new int[2];
            credit = servicesUser.StudentSelected(n);

            label2.Text = $"Ф.И.О. Студента: {stdName}";
            label1.Text = $"Количество долгов: {credit[0]}";
            label4.Text = $"Количество сданных предметов: {credit[1]}";

            dataGridView3.DataSource = servicesUser.Disciplines(n);
            dataGridView3.ClearSelection();
        }

        //Обработчик вывоза формы для формироания зачетной книжки
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonRecordBookAdd_Click(object sender, EventArgs e)
        {
            FormRecordBookAdd formRecordBookEdit = new FormRecordBookAdd(stdName, n);
            formRecordBookEdit.ShowDialog();
        }
    }
}