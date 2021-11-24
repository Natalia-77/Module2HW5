using System.IO;
using Module2HW5.Service.Abstractions;

namespace Module2HW5.Service
{
    public class FileService : IFileService
    {
        private StreamWriter _streamWriter;
        private DirectoryInfo _directoryInfo;

        public void InitStream(string filename, string filextention, string directory)
        {
        }

        public void Write(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
