using MaterialSkin;
using MaterialSkin.Controls;
using RecordBook.Interaction;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RecordBook
{
    public partial class FormDebtors : MaterialForm
    {
        private readonly ServicesUser servicesUser = new ServicesUser();
        private readonly Tools tools = new Tools();

        public FormDebtors()
        {
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

            ExcelClass.saveFileDialogExp.DefaultExt = ".xlsx";
            ExcelClass.saveFileDialogExp.Filter = "Excel file(*xlsx)|*xlsx";
        }

        private void FormDebtors_Load(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            //Обновление comboBox при загрузки формы
            servicesUser.DataTableUserSpeciality(comboBox1);
            servicesUser.DataTableUserGroupName(comboBox1, comboBox2);
            dataGridView2.DataSource = servicesUser.StudentDebtors(comboBox2.Text);
            ExcelClass.saveFileDialogExp.FileName = $"Должники_{comboBox2.Text}";
        }

        //Обработчик изменений comboBox
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            servicesUser.DataTableUserGroupName(comboBox1, comboBox2);
        }

        //Обработчик вывода студентов в dataGriedView
        private void buttonSearchStud_Click(object sender, EventArgs e)
        {
            if (tools.Test() != true)
                return;
            dataGridView2.DataSource = servicesUser.StudentDebtors(comboBox2.Text);
        }

        //Обработчик экспорта данных в Excel об задолжниках из выбранной специальности и группы 
        private void buttonExel_Click(object sender, EventArgs e)
        {
            ExcelClass.saveFileDialogExp.FileName = $"Должники_{comboBox2.Text}";
            if (tools.Test() != true || ExcelClass.saveFileDialogExp.ShowDialog() == DialogResult.Cancel)
                return;
            ServicesUser.PanelLoad(comboBox2.Text);
            Program.formMain.toolStripStatusLabel2.Text = $"Данные о задолжностях группы {comboBox2.Text} экспортированны в {ExcelClass.saveFileDialogExp.FileName}";
        }
    }
}
