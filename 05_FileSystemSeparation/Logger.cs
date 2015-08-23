using System;
using System.IO;

namespace _05_FileSystemSeparation
{
    public class Logger
    {
        //Read from configuration
        private const string _logPath = @"X:\Log";
        private readonly int _overflow;
        public Logger(int overflow)
        {
            Counter = 0;
            _overflow = overflow;
        }

        private int logsCount = 0;

        public int Counter { get; private set; }

        public virtual void Log(string message)
        {
            var logPath = String.Join(".", _logPath, DateTime.Now.ToShortDateString(), logsCount.ToString(), "txt");

            var file = File.AppendText(logPath);
            file.WriteLine(String.Format("{2} - {0}: {1}", DateTime.Now, message, Counter++));
            file.Close();
            if (Counter >= _overflow)
            {
                logsCount++;
                Counter = 0;
            }
        }

        public virtual void Log(Exception exception)
        {
            Log(exception.Message);
        }
    }
}
