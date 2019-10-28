﻿using System;
using NPOI.SS.UserModel;
using NPOI.SS;

namespace TestCases.SS
{
    /// <summary>
    /// Encapsulates a provider of test data for common HSSF / XSSF tests.
    /// </summary>
    public interface ITestDataProvider
    {
        /// <summary>
        /// Override to provide HSSF / XSSF specific way for re-serialising a workbook
        /// </summary>
        /// <param name="wb">the workbook to re-serialize.</param>
        /// <returns>the re-serialized workbook</returns>
        IWorkbook WriteOutAndReadBack(IWorkbook wb);

        /// <summary>
        /// Override to provide way of loading HSSF / XSSF sample workbooks
        /// </summary>
        /// <param name="sampleFileName"> the file name to load.</param>
        /// <returns>an instance of Workbook loaded from the supplied file name</returns>
        IWorkbook OpenSampleWorkbook(String sampleFileName);

        /// <summary>
        /// Override to provide way of creating HSSF / XSSF workbooks
        /// </summary>
        /// <returns>an instance of Workbook</returns>
        IWorkbook CreateWorkbook();

        /// <summary>
        /// Only matters for SXSSF - enables tracking of the column
        /// widths so that autosizing can work. No-op on others.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="columns"></param>
        void TrackColumnsForAutosizing(ISheet sheet, params int[] columns);

        /// <summary>
        /// Creates the corresponding {@link FormulaEvaluator} for the
        /// type of Workbook handled by this Provider. 
        /// </summary>
        /// <param name="wb">The workbook to base the formula evaluator on.</param>
        /// <returns>A new instance of a matching type of formula evaluator. </returns>
        IFormulaEvaluator CreateFormulaEvaluator(IWorkbook wb);

        /// <summary>
        ///Opens a sample file from the standard HSSF test data directory
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>an open InputStream for the specified sample file</returns>
        byte[] GetTestDataFileContent(String fileName);

        SpreadsheetVersion GetSpreadsheetVersion();

        string StandardFileNameExtension { get; }
        
    }
}
