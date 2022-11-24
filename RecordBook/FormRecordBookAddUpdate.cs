using MaterialSkin;
using MaterialSkin.Controls;
using RecordBook.Interaction;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RecordBook
{
    public partial class FormRecordBookAddUpdate : MaterialForm
    {
        private readonly ServicesUser servicesUser = new ServicesUser();
        private readonly InteractionDataUser interactionDataUser = new InteractionDataUser();

        private string stdName;
        private int numStu;
        private int numDis;
        private string type;

        //Перегруженный конструктор класса формы для добавления строки сданного предмета в зачетку
        public FormRecordBookAddUpdate(string name, int x, string t)
        {
            Program.formRecordBookAdd = this;

            InitializeComponent();

            stdName = name;
            numStu = x;
            type = t;

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

            this.Text = $"Редактирование зачетной книжки {stdName}";
            this.buttonRecordBookAdd.Text = "Добавить";
        }

        //Перегруженный конструктор класса формы для изменения строки сданного предмета в зачетке
        public FormRecordBookAddUpdate(string name, int x, int j, string t)
        {
            Program.formRecordBookAdd = this;

            InitializeComponent();

            stdName = name;
            numStu = x;
            numDis = j;
            type = t;

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

            this.Text = $"Редактирование зачетной книжки {stdName}";
            this.buttonRecordBookAdd.Text = "Изменить";
        }

        //Обработчик формы для выгрузки данных в textBox при изменение данных
        private void FormRecordBookAdd_Load(object sender, EventArgs e)
        {
            if (type == "Add")
                return;
            servicesUser.UnloadingTextBox(numStu, numDis);
        }

        //Обработчик кнопки добавления или изменения данных
        private void buttonRecordBookAdd_Click(object sender, EventArgs e)
        {
            if (type == "Add")
            {
                if (servicesUser.Discipline(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox18.Text)) == true)
                {
                    interactionDataUser.AddStudent("Exists" + type, numStu);
                    servicesUser.StudentInfoView(numStu, stdName);
                    return;
                }
                interactionDataUser.AddStudent(type, numStu);
            }
            else
            {
                if (servicesUser.Discipline(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox18.Text)) == true)
                {
                    interactionDataUser.UpdateStudent("Exists" + type, numStu, numDis);
                    servicesUser.StudentInfoView(numStu, stdName);
                    return;
                }
                interactionDataUser.UpdateStudent(type, numStu, numDis);
            }
            servicesUser.StudentInfoView(numStu, stdName);
        }

        //Лбработчик запрещающий писать текст в textBox для семестра
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}