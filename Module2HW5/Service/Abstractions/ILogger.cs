using Module2HW5.Enum;

namespace Module2HW5.Service.Abstractions
{
    public interface ILogger
    {
        public void WriteMessage(LogType type, string text);
        public void Error(string text);
        public void Warning(string text);
        public void Info(string text);
    }
}
