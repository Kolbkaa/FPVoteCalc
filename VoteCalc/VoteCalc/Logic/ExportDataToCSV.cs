using System.Collections.Generic;
using System.Text;

namespace VoteCalc.Logic
{
    class ExportDataToCsv : ExportData
    {
        public ExportDataToCsv() : base("csv")
        {
        }

        public override void AddDataToFile(string dataName, string value)
        {
            StringBuilder.AppendLine($"\"{dataName}\",\"{value}\"");
        }
        public override void AddDataToFile(Dictionary<string, string> data)
        {
            foreach (var d in data)
            {
                StringBuilder.AppendLine($"\"{d.Key}\",\"{d.Value}\"");
            }
        }

    }
}


