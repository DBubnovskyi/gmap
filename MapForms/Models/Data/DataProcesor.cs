using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MapForms.Models.Data.SetOpenstreetmap;
using MapForms.Models.Data.SetUawardata;
using MapForms.Models.SetUawardata.Data;

namespace MapForms.Models.Data
{
    public class DataProcesor
    {
        private string _dataFolder = "DataSets";

        private static string _assemblyDirectoryBuf;
        public static string AssemblyDirectory
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

        public List<Data> DataSets { get; set; } = new List<Data>();

        public void Load(string path)
        {
            string json = File.ReadAllText(path);
            string fileName = Path.GetFileName(path);

            var data = UawardataDataProcessor.ToData<FeatureV1>(json) ??
                UawardataDataProcessor.ToData<FeatureV2>(json) ??
                OpenstreetmapProvider.ToData(json);
            if (data != null)
            {
                DataSets.Add(data);
            }
        }

        public void LoadAll()
        {
            DataSets.Clear();
            if (Directory.Exists($"{ AssemblyDirectory}/{ _dataFolder}")) { 
                string[] files = Directory.GetFiles(
                    $"{AssemblyDirectory}/{_dataFolder}", 
                    "*.json",
                    SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Load(file);
                }
            }
        }
    }
}
