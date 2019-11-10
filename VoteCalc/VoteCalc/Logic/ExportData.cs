using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VoteCalc.Logic
{
    abstract class ExportData
    {
        protected readonly string FilePath;
        protected readonly StringBuilder StringBuilder;

        protected ExportData(string extension)
        {
            FilePath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"export.{extension}");
            StringBuilder = new StringBuilder();

        }

        public abstract void AddDataToFile(string dataName, string value);
        public abstract void AddDataToFile(Dictionary<string, string> data);
     

        public void Export()
        {
            try
            {
                File.WriteAllText(FilePath, StringBuilder.ToString(), Encoding.UTF8);
                MessageBox.Show($"Export to: {FilePath}");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error file export to csv", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

    }
}
