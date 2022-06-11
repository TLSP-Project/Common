
using System.ComponentModel;
using System.IO;

namespace TLSP.Common.Configuration
{
    public class ConfigModel<T> where T : INotifyPropertyChanged
    {

        public static T? Data { get; private set; }

        public string FilePath { get;  }

        public ConfigModel(string path)
        {
            FilePath = path;
            Flush();
        }

        public void Flush()
        {
            try
            {
                Data =  JsonHelper.ReadFormFile<T>(FilePath);
                Data.PropertyChanged += (sender, args) => Save();
            }
            catch 
            {
                Data = default(T);
            }
        }

        public void Save()
        {
            if(Data != null)
                JsonHelper.WriteToFile(FilePath, Data);
            else
                File.WriteAllText(FilePath, "");

        }
    }
}
