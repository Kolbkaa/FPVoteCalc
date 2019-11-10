using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

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


