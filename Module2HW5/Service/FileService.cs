using System;
using System.IO;
using Module2HW5.Helper;
using Module2HW5.Service.Abstractions;

namespace Module2HW5.Service
{
    public class FileService : IFileService
    {
        private DirectoryInfo _directoryInfo;
        private int _capacity;
        private string _path;

        public void InitStream(int capacity, string fileName, string fileExtention, string directoryPath)
        {
            _capacity = capacity;
            _directoryInfo = new DirectoryInfo(directoryPath);
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }
            else
            {
                var files = _directoryInfo.GetFiles();

                if (files.Length > _capacity)
                {
                    Array.Sort(files, new FileTimeCreateComparer());
                    for (var i = files.Length - 1; i >= 2; i--)
                    {
                        files[i].Delete();
                    }
                }
            }

            var fullname = fileName + fileExtention;
            var path = Path.Combine(directoryPath, fullname);
            _path = path;
        }

        public void Write(string text)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine(text);
            }
        }
    }
}
