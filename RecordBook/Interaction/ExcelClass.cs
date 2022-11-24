using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RecordBook.Interaction
{
    internal class ExcelClass
    {
        private readonly ServicesUser servicesUser = new ServicesUser();
        public static SaveFileDialog saveFileDialogExp = new SaveFileDialog();

        public void ExpExcel(string name_group)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            DataTable dataTable = new DataTable();

            dataTable = servicesUser.StudentDebtors(name_group);

            Excel.Range _excelCells1 = (Excel.Range)worksheet.get_Range("A1", "F1").Cells;
            _excelCells1.Merge(Type.Missing);

            List<string> names = new List<string>();
            List<string> number = new List<string>();
            List<string> debtors = new List<string>();

            foreach (DataRow row in dataTable.Rows)
            {
                names.Add(row["STUDENT_SURNAME"].ToString().Trim() + " " + row["STUDENT_NAME"].ToString().Trim() + " "
                    + row["STUDENT_PATRONUMIC"].ToString().Trim());
                number.Add(row["STUDENT_NUM_RECORD_BOOK"].ToString().Trim());
                debtors.Add("Количество задолжностей: " + row["Количество задолжностей"].ToString().Trim());
            }

            worksheet.Range["A1"].Value = $"Список должников группы {name_group} {DateTime.Now}";
            for (int i = 2; i < names.Count + 2; i++)
            {
                Excel.Range _excelCells2 = (Excel.Range)worksheet.get_Range($"B{i + 1}", $"E{i + 1}").Cells;
                _excelCells2.Merge(Type.Missing);
                worksheet.Cells[i + 1, 2].Value = names[i - 2];
                worksheet.Cells[i + 1, 6].Value = number[i - 2];
                worksheet.Cells[i + 1, 7].Value = debtors[i - 2];
            }

            worksheet.Columns.AutoFit();

            string path = saveFileDialogExp.FileName;
            workbook.SaveAs(path);
            workbook.Close();

            Marshal.ReleaseComObject(application);
        }
    }
}
