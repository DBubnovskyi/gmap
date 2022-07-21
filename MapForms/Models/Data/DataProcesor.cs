using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MapForms.Models.Data.SetOpenstreetmap;
using MapForms.Models.Data.SetUawardata;

namespace MapForms.Models.Data
{
    public class DataProcesor
    {
        private string _dataFolder = "DataSets";

        private static string _assemblyDirectoryBuf;
        private static string _assemblyDirectory
        {
            get
            {
                if (_assemblyDirectoryBuf == null)
                {
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string path = Uri.UnescapeDataString(uri.Path);
                    _assemblyDirectoryBuf = Path.GetDirectoryName(path);
                }
                return _assemblyDirectoryBuf;
            }
        }

        public List<DataSet> DataSets { get; set; } = new List<DataSet>();

        public void Load(string path)
        {
            string json = File.ReadAllText(path);
            DataSet dataSet;
            string fileName = Path.GetFileName(path);
            try
            {
                var data = UawardataDataProcessor.ParseActualLine(json);
                dataSet = new DataSet()
                {
                    Points = data,
                    Name = fileName
                };
            }
            catch (Exception)
            {
                try
                {
                    var data = UawardataDataProcessor.ParseLine240222(json);
                    dataSet = new DataSet()
                    {
                        Points = data,
                        Name = fileName
                    };
                }
                catch (Exception)
                {
                    var data = OpenstreetmapProvider.ParseLine(json);
                    dataSet = new DataSet()
                    {
                        Points = data,
                        Name = fileName
                    };
                }
            }
            DataSets.Add(dataSet);
        }

        public void LoadAll()
        {
            string[] files = Directory.GetFiles(
                $"{_assemblyDirectory}/{_dataFolder}", 
                "*.json",
                SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Load(file);
            }
        }
    }
}
