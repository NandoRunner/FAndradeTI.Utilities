using Aspose.Cells;
using Microsoft.Win32.SafeHandles;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
#if (!NO_OFFICE)
using Excel = Microsoft.Office.Interop.Excel;
#else
using Excel = Aspose.Cells;
#endif


namespace FAndradeTI.Util.Spreadsheet
{
    public class BaseExcel : IDisposable
    {
        private int numAba;
        private string planilha;
        private CultureInfo ci;
        private string msg;
        private int offSet;

#if (!NO_OFFICE)
        private Excel.Application myApp;
#endif
        private Excel.Worksheet worksheet;
        private Excel.Workbook workbook;

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        protected int NumAba { get => numAba; set => numAba = value; }
        public string Planilha { get => planilha; set => planilha = value; }
        public CultureInfo Ci { get => ci; set => ci = value; }
        public string Msg { get => msg; set => msg = value; }

#if (!NO_OFFICE)
        public Excel.Application MyApp { get => myApp; set => myApp = value; }
#endif
        public Excel.Workbook WorkBook { get => workbook; set => workbook = value; }
        public Excel.Worksheet WorkSheet { get => worksheet; set => worksheet = value; }
        public int OffSet { get => offSet; set => offSet = value; }

        public BaseExcel()
        {
            Ci = new CultureInfo("pt-BR");
#if (!NO_OFFICE)
            offSet = 0;
#else
            offSet = -1;
#endif
        }

        protected int ColumnLetterToColumnIndex(string columnLetter)
        {
            if (string.IsNullOrEmpty(columnLetter))
            {
                Console.WriteLine($">> {typeof(BaseExcel).Name} > columnLetter is null or empty");
                return 0;
            }

            try
            {
                columnLetter = columnLetter.ToUpper(CultureInfo.CurrentCulture);
                int sum = 0;

                for (int i = 0; i < columnLetter.Length; i++)
                {
                    sum *= 26;
                    sum += (columnLetter[i] - 'A' + 1);
                }
                return sum;
            }
            catch (ArgumentNullException ex)
            {
                Msg = ex.Message;
                return 0;
            }
        }

        protected bool InitExcel(string pwd)
        {
            bool ret = false;

            try
            {
                if (workbook == null)
                {
#if (!NO_OFFICE)
                    myApp = new Excel.Application();
                    workbook = myApp.Workbooks.Open(Planilha, 0, false, 5, pwd, "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
#else
                    var lo = new LoadOptions();
                    lo.Password = pwd;
                    
                    workbook = new Excel.Workbook(planilha, lo);
#endif
                }
                ret = true;
            }
            catch (COMException ex)
            {
                Msg = $"Planilha em uso, favor fechar para liberar o processamento\n\n{ex.Message}";
                //todo: mover mensagem de falha
                //StatusStripControl.UpdateLabel("Importar: Processamento cancelado.");
#if (!NO_OFFICE)
                if (myApp != null)
                {
                    workbook = null;
                    myApp.Quit();
                    myApp = null;
                }
#else
                workbook = null;

#endif
            }
            return ret;
        }

        protected void InitWorksheet(string codeName = null)
        {
            try
            {
#if (!NO_OFFICE)
                worksheet = (Excel.Worksheet)WorkBook.Sheets[NumAba];
#else
                worksheet = workbook.Worksheets[codeName];
#endif
            }
            catch
            {
                throw;
            }
        }

        protected void SaveWorkbook()
        {
            try
            {
#if (!NO_OFFICE)
                workbook.Save();
#else
                workbook.Save(planilha, Excel.SaveFormat.Xlsx);
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine("999" + ex.Message);
                throw;
            }
        }

        protected object GetCellValue(int row, string col)
        {
            return GetCellValue(row, ColumnLetterToColumnIndex(col));
        }

        protected object GetCellValue(int row, int col)
        {
#if (!NO_OFFICE)
            if (((Excel.Range)worksheet.Cells[row, col]).Value2 == null)
            return "";
            else
                return ((Excel.Range)worksheet.Cells[row, col]).Value2;
#else
            if ((worksheet.Cells[row + offSet, col + offSet]).Value == null)
                return "";
            else
                return (worksheet.Cells[row + offSet, col + offSet]).Value;
#endif
        }

        protected void SetCellValue(int row, string col, object value)
        {
            SetCellValue(row, ColumnLetterToColumnIndex(col), value);
        }

        protected void SetCellValue(int row, int col, object value)
        {
#if (!NO_OFFICE)
            ((Excel.Range)worksheet.Cells[row, col]).Value2 = value;
#else
            (worksheet.Cells[row + offSet, col + offSet]).Value = value;
#endif
        }

        protected void SetNumberFormat(int row, string col)
        {
#if (!NO_OFFICE)
            ((Microsoft.Office.Interop.Excel.Range)WorkSheet.Cells[row, col]).NumberFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
#else
            var myCol = ColumnLetterToColumnIndex(col);
            var ds = WorkSheet.Cells.GetCellStyle(row + offSet, myCol + offSet);
            ds.Custom = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            WorkSheet.Cells[row + offSet, myCol + offSet].SetStyle(ds);
#endif

        }

        protected void SetNoteText(int row, int col, string value)
        {
#if (!NO_OFFICE)
            ((Excel.Range)workSheet.Cells[row, col]).NoteText(value);
#else
            var commentIndex = WorkSheet.Comments.Add(row + offSet, col + offSet);
            var comment = worksheet.Comments[commentIndex];
            comment.Note = value;
#endif

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void CalculateWorkSheet()
        {
#if (!NO_OFFICE)
            workbook.Calculate();
#else
            workbook.CalculateFormula(true);
#endif

        }

        protected void CopyWorkSheet(int row, int colSource, int colTarget, string origem = null, string destino = null)
        {
#if (!NO_OFFICE)
           ((Excel.Range)WorkSheet.Cells[row, colSource]).Copy(
           ((Excel.Range)WorkSheet.Cells[row, colTarget]));
#else
            if (!WorkSheet.Cells[row + offSet, colSource + offSet].IsFormula) return;

            WorkSheet.Cells[row + offSet, colTarget + offSet].Formula = WorkSheet.Cells[row + offSet, colSource + offSet].Formula.Replace(origem.Substring(2, 4), destino.Substring(2, 4));

            //todo: alterar a coluna do COnfig (??)
#endif
        }

        protected void CopySpecialWorkSheet(int row, int col)
        {
#if (!NO_OFFICE)
            ((Excel.Range) WorkSheet.Cells[row, col]).Copy();
            ((Excel.Range) WorkSheet.Cells[row, col]).PasteSpecial(Excel.XlPasteType.xlPasteValuesAndNumberFormats);

#else
            if (!WorkSheet.Cells[row + offSet, col + offSet].IsFormula) return;

            var aux = WorkSheet.Cells[row + offSet, col + offSet].DoubleValue;
            WorkSheet.Cells[row + offSet, col + offSet].Formula = null;
            //WorkSheet.Cells[row + offSet, col + offSet].FormulaLocal = null;
            WorkSheet.Cells[row + offSet, col + offSet].Value = aux;
#endif
        }

        protected void WorksheetRemoveHyerlinks()
        {
            var options = new Aspose.Cells.PdfSaveOptions();

            worksheet.Hyperlinks.Clear();

            foreach (Aspose.Cells.Drawing.OleObject obj in worksheet.OleObjects)
                obj.RemoveHyperlink();

            foreach (Aspose.Cells.Drawing.Shape shape in worksheet.Shapes)
                shape.RemoveHyperlink();

            workbook.Save(planilha + ".out.pdf", Aspose.Cells.SaveFormat.Pdf);
        }

        protected string[] GetWorksheetNames()
        {

            string[] sNames = new string[workbook.Worksheets.Count];

            int loop = 0;

            foreach (Worksheet sheet in workbook.Worksheets)
            {
                sNames[loop++] = sheet.Name;
            }

            return sNames;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.

#if (!NO_OFFICE)
                workbook.Close();
                workbook = null;
                myApp.Quit();
                myApp = null;
#else
                if (workbook != null)
                {
                    workbook.Dispose();
                    workbook = null;
                }
#endif
            }

            disposed = true;
        }

        protected void CloseWorkbook()
        {
            try
            {
#if (!NO_OFFICE)
                workbook.Close();
                workbook = null;
                myApp.Quit();
                myApp = null;
#else
                workbook.Dispose();
                workbook = null;
#endif
            }
            catch
            {
                throw;
            }
        }

    }
}
