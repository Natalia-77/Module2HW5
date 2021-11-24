namespace Module2HW5.Service.Abstractions
{
    public interface IFileService
    {
        public void InitStream(string filename, string filextention, string directory);
        public void Write(string text);
    }
}
