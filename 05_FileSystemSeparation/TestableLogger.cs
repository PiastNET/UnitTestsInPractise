using System;
using System.IO;
using System.IO.Abstractions;

namespace _05_FileSystemSeparation
{
    public class TestableLogger
    {
        //Read from configuration
        private const string _logPath = @"C:\123\Log";
        private readonly int _overflow;
        private int logsCount = 0;
        private readonly IFileSystem filesystem;


        #region Constructors
        public TestableLogger(int overflow, IFileSystem filesystem)
        {
            Counter = 0;
            _overflow = overflow;
            this.filesystem = filesystem;
        }

        public TestableLogger(int overflow) : this(overflow, new FileSystem()) { }
        #endregion

        public int Counter { get; private set; }

        public virtual void Log(string message)
        {
            var logPath = String.Join(".", _logPath, DateTime.Now.ToShortDateString(), logsCount.ToString(), "txt");

            var file = filesystem.File.AppendText(logPath);
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
