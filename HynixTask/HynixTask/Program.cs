using System;
using System.Linq;
using HynixTask.Helpers;

namespace HynixTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            args[0].GetPathsFromDirectory()
                .Select(item => item
                .ReadFilesFromDirectory())
                .Where(d => d != null)
                .PrintMeResults();
        }
    }
}
