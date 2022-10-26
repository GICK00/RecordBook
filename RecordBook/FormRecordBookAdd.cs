using MaterialSkin;
using MaterialSkin.Controls;
using RecordBook.Interaction;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RecordBook
{
    public partial class FormRecordBookAdd : MaterialForm
    {
        private readonly ServicesUser servicesUser = new ServicesUser();
        private readonly Tools tools = new Tools();

        private string stdName;
        private int n;

        public FormRecordBookAdd(string name, int x)
        {
            InitializeComponent();

            stdName = name;
            n = x;

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
        }

        private void FormRecordBookEdit_Load(object sender, EventArgs e)
        {
            servicesUser.DataTableUserDiscipline(comboBox1, "TEACHER");
            servicesUser.DataTableUserDiscipline(comboBox3, "NAME");
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}