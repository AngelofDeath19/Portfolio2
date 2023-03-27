using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using ZxcCursed.Models;

namespace ZxcCursed.Services
{
    internal class FileSaveLoadService
    {
        private readonly string Path; 
        public FileSaveLoadService(string path)
        {
            Path = path;
        }

        public BindingList<ToDoModel> Load()
        {
            var fileExists = File.Exists(Path);
            if (!fileExists)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }
        }
        public void Save(object todoData)
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string? output = JsonConvert.SerializeObject(todoData);
                writer.Write(output);   
            }

        }
    }
}
