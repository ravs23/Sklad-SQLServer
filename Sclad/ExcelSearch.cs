using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{
    static class ExcelSearch
    {
        static DataTable ResultSearchXLSX { get; set; }

        static ExcelSearch()
        {
            ResultSearchXLSX = new DataTable();
            DataColumn codeColumn = new DataColumn("Code", typeof(string));
            DataColumn nameColumn = new DataColumn("Name", typeof(string));
            DataColumn dcColumn = new DataColumn("DC", typeof(string));
            DataColumn pcColumn = new DataColumn("PC", typeof(string));
            DataColumn discColumn = new DataColumn("Discont", typeof(string));
            DataColumn catalogPeriodColumn = new DataColumn("Period", typeof(string));
            ResultSearchXLSX.Columns.AddRange(new DataColumn[] {
                                                                codeColumn,
                                                                nameColumn,
                                                                dcColumn,
                                                                pcColumn,
                                                                discColumn,
                                                                catalogPeriodColumn,
            });
        }

        // Ищем продукт по Коду в прайс-листах
        public static DataTable Search(string fieldSearch, SearchBy searchBy)
        {
            ResultSearchXLSX.Clear();

            if (Settings.listXLSX == null || Settings.listXLSX.Count == 0 || fieldSearch == string.Empty)
                return ResultSearchXLSX;

            foreach (string file in Settings.listXLSX)
            {
                if (File.Exists(file))
                    try
                    {
                        switch (searchBy)
                        {
                            case SearchBy.Code:
                                SearchByCode(fieldSearch, file);
                                break;
                            case SearchBy.Name:
                                SearchByName(fieldSearch, file);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message,"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            return ResultSearchXLSX;
        }

        static void SearchByCode(string code, string file)
        {
            using (ExcelPackage excel = new ExcelPackage(new FileInfo(file)))
            {
                int startRow, startColumn;
                bool ExistStartCell = SearchStartCell(excel, out startRow, out startColumn);
                if (!ExistStartCell) return;

                ExcelWorksheet ws = excel.Workbook.Worksheets[1];
                int RowMax = ws.Dimension.End.Row;
                for (int i = startRow; i <= RowMax; i++)
                {
                    string currentRow = ws.Cells[i, startColumn].Value == null ? string.Empty : ws.Cells[i, startColumn].Value.ToString();
                    if (currentRow == code)
                    {
                        //добавляем инфу в дататейбл и выходим
                        DataRow newRow = ResultSearchXLSX.NewRow();
                        newRow[0] = ws.Cells[i, startColumn].Value == null ? string.Empty : ws.Cells[i, startColumn].Value.ToString();
                        newRow[1] = ws.Cells[i, startColumn + 3].Value == null ? string.Empty : ws.Cells[i, startColumn + 3].Value.ToString();
                        newRow[2] = ws.Cells[i, startColumn + 6].Value == null ? string.Empty : ws.Cells[i, startColumn + 6].Value.ToString();
                        newRow[3] = ws.Cells[i, startColumn + 7].Value == null ? string.Empty : ws.Cells[i, startColumn + 7].Value.ToString();
                        newRow[4] = ws.Cells[i, startColumn + 1].Value == null ? string.Empty : ws.Cells[i, startColumn + 1].Value.ToString();
                        newRow[5] = GetNumberCatalog(file);

                        ResultSearchXLSX.Rows.Add(newRow);
                        break;
                    }
                }
            }
        }

        static void SearchByName(string name, string file)
        {
            name = name.ToLower();
            using (ExcelPackage excel = new ExcelPackage(new FileInfo(file)))
            {
                int startRow, startColumn;
                bool ExistStartCell = SearchStartCell(excel, out startRow, out startColumn);
                if (!ExistStartCell) return;

                ExcelWorksheet ws = excel.Workbook.Worksheets[1];
                int RowMax = ws.Dimension.End.Row;
                for (int i = startRow; i <= RowMax; i++)
                {
                    string currentRow = ws.Cells[i, startColumn + 3].Value == null ? string.Empty : ws.Cells[i, startColumn + 3].Value.ToString().ToLower();
                    if (currentRow.Contains(name))
                    {
                        if (ws.Cells[i, startColumn].Value == null) continue; //если это не строка с продуктом (отсутствует код в первой ячейке) - пропускаем

                        //добавляем инфу в дататейбл и выходим
                        DataRow newRow = ResultSearchXLSX.NewRow();
                        newRow[0] = ws.Cells[i, startColumn].Value == null ? string.Empty : ws.Cells[i, startColumn].Value.ToString();
                        newRow[1] = ws.Cells[i, startColumn + 3].Value == null ? string.Empty : ws.Cells[i, startColumn + 3].Value.ToString();
                        newRow[2] = ws.Cells[i, startColumn + 6].Value == null ? string.Empty : ws.Cells[i, startColumn + 6].Value.ToString();
                        newRow[3] = ws.Cells[i, startColumn + 7].Value == null ? string.Empty : ws.Cells[i, startColumn + 7].Value.ToString();
                        newRow[4] = ws.Cells[i, startColumn + 1].Value == null ? string.Empty : ws.Cells[i, startColumn + 1].Value.ToString();
                        newRow[5] = GetNumberCatalog(file);

                        ResultSearchXLSX.Rows.Add(newRow);
                    }
                }
            }
        }

        public static bool SearchStartCell(ExcelPackage excel, out int startRow, out int startColumn)
        {
            bool found = false;

            ExcelWorksheet ws = excel.Workbook.Worksheets[1];

            ExcelAddressBase dimension = ws.Dimension;
            int maxRow = dimension.End.Row;

            startRow = 0;
            startColumn = 0;

            int tryCode;
            string currentCell = "";

            bool exit = false;
            for (int rows = 1; rows <= 5; rows++)
            {
                if (!exit)
                {
                    for (int cols = 1; cols <= 3; cols++)
                    {
                        try
                        {
                            currentCell = ws.Cells[rows, cols].Value.ToString();
                            if (int.TryParse(currentCell, out tryCode))
                            {
                                startRow = rows;
                                startColumn = cols;
                                exit = true;
                                found = true;
                                break;
                            }
                        }
                        catch
                        {
                        }

                    }
                }
                else
                    break;
            }
            return found;
        }

        static string GetNumberCatalog(string file)
        {
            file = Path.GetFileNameWithoutExtension(file);

            string pattern = @"\d{4}";
            Match match = Regex.Match(file, pattern);
            if (match.Success)
            {
                string period = match.Value.Substring(0, 2);
                string year = "20" + match.Value.Substring(2, 2);
                return year + " / " + period;
            }
            return "---- / --";
        }
    }
}
