using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoggerKata
{
    public class FileLoggerTest
    {
        //unit tests.....
        string fileName = @".\log.txt";
        FileLogger fileLogger = new FileLogger();

        [Test]
        public void FileExists()
        {
            Assert.IsTrue(File.Exists(fileName));
        }

        [Test]
        public void ValidateMessage(string message)
        {
            Assert.IsTrue(message.StartsWith(DateTime.Today.ToString()));
        }

        [Test]
        public void ValidateFileName()
        {
            string date = DateTime.Today.ToString("YYYY-MM-DD:MM:SS");
            Assert.AreEqual("log" + date + ".txt", fileLogger.GetLogFileName());
        }

        [Test]
        public void checkIfWeekend()
        {
            DateTime lastSaturday = DateTime.Now.AddDays(-1);

            while (lastSaturday.DayOfWeek != DayOfWeek.Saturday)
                lastSaturday = lastSaturday.AddDays(-1);

            Assert.IsTrue(File.Exists("weekend" + lastSaturday + ".txt"));
        }
    }
}
