using System.Data.SqlClient;
using System.Windows.Forms;

namespace RecordBook.Interaction
{
    class InteractionTool
    {
        private readonly ServicesAdmin servicesAdmin = new ServicesAdmin();

        // Очищает все таблицы БД от данных кроме таблицы Autorization (она необходима для авторизации в приложении). 
        public void очиститьБазуДанныхToolStripMenuItem()
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите очистить базу данных?", "Удаление данных.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            using (SqlCommand sqlCommand = new SqlCommand("DeletedAll", FormMain.connection))
            {
                FormMain.connection.Open();
                sqlCommand.ExecuteNonQuery();
                FormMain.connection.Close();
            }
            servicesAdmin.ReloadEditingBD(Program.formMain.comboBox.Text);
            servicesAdmin.ClearStr();
            Program.formMain.toolStripStatusLabel2.Text = "База данных очищенна";
        }

        // Создает полную резерную копию всей БД.
        public void создатьРезервнуюКопиюToolStripMenuItem()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Tools.connSrring);

            string path = ServicesAdmin.saveFileDialogBack.FileName;
            string sql = $@"BACKUP DATABASE[{builder["Initial Catalog"]}] TO DISK = N'{path}' WITH NOFORMAT, NOINIT, NAME = N'{builder["Initial Catalog"]}-Полная База данных Резервное копирование', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            FormLoad formLoad = new FormLoad(sql, "back");
            formLoad.ShowDialog();
        }

        // Восстанавливает БД из выбранной резервной копии.
        public void восстановитьБазуДанныхToolStripMenuItem()
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите востановить базу данных?", "Восстановление базы данных.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            if (ServicesAdmin.openFileDialogRes.ShowDialog() == DialogResult.Cancel)
                return;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Tools.connSrring);

            string path = ServicesAdmin.openFileDialogRes.FileName;
            string sql = $@"USE master RESTORE DATABASE [{builder["Initial Catalog"]}] FROM  DISK = N'{path}' WITH REPLACE, FILE = 1,  NOUNLOAD,  STATS = 5";
            FormLoad formLoad = new FormLoad(sql, "res");
            formLoad.ShowDialog();
        }
    }
}
