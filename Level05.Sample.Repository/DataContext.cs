using System;
using System.Collections.Generic;
using System.Text;

namespace Level05.Sample.Repository
{
    public class DataContext
    {
        public static Dictionary<string, string> Profiles;

        static DataContext()
        {
            Profiles = new Dictionary<string, string>
            {
                { "kevin", "654321" },
                { "eason", "123456" },
                { "wenfei", "223456" },
                { "josh", "323456" }
            };
        }

        public static string GetPassword(string key)
        {
            return Profiles[key];
        }
    }
}