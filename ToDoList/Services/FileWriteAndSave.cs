using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Newtonsoft.Json;

namespace ToDoList.Services
{
    class FileWriteAndSave
    {
        private readonly string Path;
        public FileWriteAndSave(string path)
        {
            Path = path;
        }
        public BindingList<Model> LoadData()
        {
            var fileExist = File.Exists(Path);  // Check if the file exists
            if (!fileExist)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<Model>();
            }
            using (var reader = File.OpenText(Path)) // Read the information from the file
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Model>>(fileText);
            }
        }
        public void SaveData(object toDoDataList) // Write the information from the file
        {
            using (StreamWriter wr = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(toDoDataList);
                wr.Write(output);
            }

        }
    }
}
