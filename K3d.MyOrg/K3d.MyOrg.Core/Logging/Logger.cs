
namespace K3d.MyOrg.Core.Logging
{
    public class LogMessageEventArgs : EventArgs
    {
        public string Message { get; }

        public LogMessageEventArgs(string message)
        {
            Message = message;
        }
    }

    public class Logger : ILogger
    {
        public event EventHandler<LogMessageEventArgs>? Message;

        public void Debug(string message, params object[] args)
        {
            Message?.Invoke(this, new LogMessageEventArgs(string.Format(message, args)));
        }

        public void Error(string message, params object[] args)
        {
            Message?.Invoke(this, new LogMessageEventArgs(string.Format(message, args)));
        }

        public void Info(string message, params object[] args)
        {
            Message?.Invoke(this, new LogMessageEventArgs(string.Format(message, args)));
        }

        public void Warning(string message, params object[] args)
        {
            Message?.Invoke(this, new LogMessageEventArgs(string.Format(message, args)));
        }
    }
}
