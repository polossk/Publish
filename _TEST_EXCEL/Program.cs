using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal.Global;
using Microsoft.Office.Interop.Excel;

namespace _TEST_EXCEL
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelOperator excel = new ExcelOperator();
            excel.CreateExcel();
            for (int indexColumn = 0; indexColumn < 5; indexColumn++)
            {
                Range range = excel[1, indexColumn + 1];
                range.Value2 = "列" + (1 + indexColumn).ToString();
            }
            for (int indexRow = 0; indexRow < 10; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 5; indexColumn++)
                {
                    Range range = excel[2 + indexRow, 1 + indexColumn];
                    Random rnd = new Random();
                    range.Value2 = rnd.Next() % 10000;
                }
            }

            excel.SaveExcel(Directory.GetCurrentDirectory() + "\\test.xls");
            excel.QuitExcel();
        }
    }
}
