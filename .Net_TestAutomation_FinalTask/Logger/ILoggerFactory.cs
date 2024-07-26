namespace TA_FinalTask;

public interface ILoggerFactory
{
    enum LoggerType
    {
        FILE,
        CONSOLE,
        NONE
    };
    ILogger CreateLogger(LoggerType type);
}