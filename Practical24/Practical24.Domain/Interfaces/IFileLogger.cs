namespace Practical24.Domain.Interfaces;

public interface IFileLogger
{
    void Log(string message);
    void LogError(string message, Exception? ex);
}
