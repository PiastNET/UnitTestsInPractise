using System;
using System.IO;

namespace SingletonIsBad
{
    public class Logger
    {
        //Read from configuration
        private const string _logPath = @"C:\Log.txt";

        private Logger()
        {
        }

        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                return _instance ?? (_instance = new Logger());
            }
        }

        public virtual void Log(string message)
        {
            var file = File.AppendText(_logPath);
            file.WriteLine(String.Format("{0}: {1}", DateTime.Now, message));
            file.Close();
        }

        public virtual void Log(Exception exception)
        {
            Log(exception.Message);
        }
    }
}
