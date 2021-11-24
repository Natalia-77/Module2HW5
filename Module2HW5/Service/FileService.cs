using System.IO;
using Module2HW5.Service.Abstractions;

namespace Module2HW5.Service
{
    public class FileService : IFileService
    {
        private StreamWriter _streamWriter;
        private DirectoryInfo _directoryInfo;
        private int _capacity;

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
                    for (var i = files.Length - 1; i >= 2; i--)
                    {
                        files[i].Delete();
                    }
                }
            }

            _streamWriter = new StreamWriter($"{directoryPath}{fileName}{fileExtention}", true);
        }

        public void Write(string text)
        {
            _streamWriter.WriteLine(text);
        }
    }
}
