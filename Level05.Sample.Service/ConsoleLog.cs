using Level05.Sample.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level05.Sample.Service
{
    public class ConsoleLog : ILog
    {
        public void Save(string message)
        {
            var content = $"{SystemTime.Now}，log內容：{message}";
            Console.WriteLine(content);
        }
    }
}