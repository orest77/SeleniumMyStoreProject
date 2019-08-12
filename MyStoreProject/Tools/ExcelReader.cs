﻿using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using NLog;

namespace MyStoreProject.Tools
{
    class ExcelReader : AExternalReader
    {
        private const int DATA_SHEET = 1;
       

        public ExcelReader(string filename) : base(filename)
        {
            
        }

        public override IList<IList<string>> GetAllCells()
        {
            return GetAllCells(Path);
        }
        public Logger Logger = LogManager.GetCurrentClassLogger();

        public override IList<IList<string>> GetAllCells(string path)
        {
            Logger.Debug("Start GetAllCells(string path), path = " + path);
            Path = path;
            IList<IList<string>> allCells = new List<IList<string>>();
            //
            // Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[DATA_SHEET];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            //
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            // Iterate over the rows and columns and print to the console as it appears in the file excel is not zero based
            for (int i = 1; i <= rowCount; i++)
            {
                IList<string> rowCells = new List<string>();
                for (int j = 1; j <= colCount; j++)
                {
                    if ((xlRange.Cells[i, j] != null)
                        && (xlRange.Cells[i, j].Value2 != null))
                    {
                        string cell = xlRange.Cells[i, j].Value.ToString().Trim();
                        Logger.Trace("Start Add Cell = " + cell);
                        rowCells.Add(cell);
                        Logger.Trace("Done Add Cell = " + cell);
                    }
                }
                allCells.Add(rowCells);
            }
            // Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            // Quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            //
            Logger.Debug("Done GetAllCells(string path), path = " + path);
            return allCells;
        }

        public override string GetConnection()
        {
            return Path;
        }

    }
}
