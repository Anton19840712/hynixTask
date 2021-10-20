using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HynixTask.Models;

namespace HynixTask.Helpers
{
    public static class DataHelper
    {
        private static readonly string ItemMatch = ConfigurationHelper.GetSettingsElement();

        private static int _counter;

        /// <summary>
        /// Method gets paths
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetPathsFromDirectory(this string path)
        {
            var d = new DirectoryInfo(path);

            return d.GetFiles("*.txt")
                    .Select(file => file.FullName)
                    .ToList();
        }

        /// <summary>
        /// Method counts special elements
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataModel ReadFilesFromDirectory(this string path)
        {
            try
            {
                using (var file = new StreamReader(path))
                {
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        var parts = ln.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                        var result = parts.Select(x => x.Intersect(ItemMatch)).Count();

                        _counter += result;
                    }

                    file.Close();
                }

                if (_counter > 0)
                {
                    return CreateDataModel(path);
                }
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception {ex} was generated");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex} was generated");
            }
            finally
            {
                //not implemented;
            }

            return default;
        }

        /// <summary>
        /// Method creates data model
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static DataModel CreateDataModel(string path)
        {
            var dataModelBuilder = new DataModelBuilder();

            var dataModel = dataModelBuilder
                .HasFileName(Path.GetFileName(path))
                .HasNumberOfMatches(_counter)
                .Build();

            _counter = 0;

            return dataModel;
        }
    }
}