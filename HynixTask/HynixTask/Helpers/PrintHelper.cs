using System;
using System.Collections.Generic;
using HynixTask.Framers;
using HynixTask.Models;

namespace HynixTask.Helpers
{
    /// <summary>
    /// Contains methods to print database info differently.
    /// </summary>
    public static class PrinterHelper
    {
        public static void PrintMeResults(this IEnumerable<DataModel> elements)
        {
            Console.WriteLine("The whole list of files and matches\n");

            var table = new TableFramer("File", "Number of matches");

            foreach (var dataModel in elements)
            {
                table.AddRow("#" + dataModel.FileName, dataModel.NumberOfMatches);
            }

            table.Write();
        }
    }
}