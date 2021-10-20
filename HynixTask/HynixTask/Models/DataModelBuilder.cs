using System;
using System.Collections.Generic;

namespace HynixTask.Models
{
    public class DataModelBuilder
    {
        public readonly List<Action<DataModel>> Actions = new List<Action<DataModel>>();

        public DataModelBuilder HasFileName(string name)
        {
            Actions.Add(dm => { dm.FileName = name; });
            return this;
        }
        public DataModelBuilder HasNumberOfMatches(int number)
        {
            Actions.Add(dm => { dm.NumberOfMatches = number; });
            return this;
        }

        public DataModel Build()
        {
            var dm = new DataModel();
            Actions.ForEach(a => a(dm));
            return dm;
        }
    }
}