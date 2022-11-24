using System;
using System.Windows.Forms;

namespace RecordBook
{
    static class Program
    {
        public static FormMain formMain;
        public static FormRecordBook formRecordBook;
        public static FormRecordBookAddUpdate formRecordBookAdd;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
